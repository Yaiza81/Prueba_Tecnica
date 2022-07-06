using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Helper;
using Web.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        EmpleadoApi api_ = new EmpleadoApi();

        public async Task<IActionResult> Index()
        {
            List<EmpleadoDatos> empleados = new List<EmpleadoDatos>();
            HttpClient cliente = api_.Initial();
            HttpResponseMessage res = await cliente.GetAsync("empleado");
            if (res.IsSuccessStatusCode)
            {
                var resultados = res.Content.ReadAsStringAsync().Result;
                empleados = JsonConvert.DeserializeObject<List<EmpleadoDatos>>(resultados);
            }

            return View(empleados);
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(EmpleadoDatos empleado)
        {
            HttpClient cliente = api_.Initial();

            var postTask = cliente.PostAsJsonAsync<EmpleadoDatos>("empleado", empleado);
            postTask.Wait();

            var resultado = postTask.Result;
            if (resultado.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EmpleadoDatos empleado = await GetEmpleadoId(id);
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmpleadoDatos empleado)
        {
            HttpClient cliente = api_.Initial();

            var postTask = cliente.PutAsJsonAsync<EmpleadoDatos>("empleado", empleado);
            postTask.Wait();

            var resultado = postTask.Result;
            if (resultado.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View();
        }

        private static async Task<EmpleadoDatos> GetEmpleadoId(int id)
        {
            EmpleadoDatos empleado = new EmpleadoDatos();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:5000/api/");
            HttpResponseMessage res = await cliente.GetAsync($"empleado/{id}");
            if (res.IsSuccessStatusCode)
            {
                var resultados = res.Content.ReadAsStringAsync().Result;
                var c = resultados.ToString();
                c = string.Join("", c.Split('[', ']'));

                empleado = JsonConvert.DeserializeObject<EmpleadoDatos>(c);
            }

            return empleado;
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
