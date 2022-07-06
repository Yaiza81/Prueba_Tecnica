using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmpleadoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from empleado";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DatabaseAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection connect = new MySqlConnection("Server=localhost;Database=empresa1;Uid=root;Pwd=ponchito"))
            {
                connect.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, connect))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    connect.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"
                              select * from empleado
                              where empleado.id_empleado = @id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DatabaseAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection connect = new MySqlConnection("Server=localhost;Database=empresa1;Uid=root;Pwd=ponchito"))
            {
                connect.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, connect))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    connect.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Empleado emp)
        {
            string query = @"
                              insert into empleado(dpi,nombre,apellidos,sueldo,cod_puesto,cod_depto) 
                        values (@dpi,@nombre,@apellidos,@sueldo,@cod_puesto,@cod_depto)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DatabaseAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection connect = new MySqlConnection("Server=localhost;Database=empresa1;Uid=root;Pwd=ponchito"))
            {
                connect.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, connect))
                {

                    myCommand.Parameters.AddWithValue("@dpi", emp.dpi);
                    myCommand.Parameters.AddWithValue("@nombre", emp.nombre);
                    myCommand.Parameters.AddWithValue("@apellidos", emp.apellidos);
                    myCommand.Parameters.AddWithValue("@sueldo", emp.sueldo);
                    myCommand.Parameters.AddWithValue("@cod_puesto", emp.cod_puesto);
                    myCommand.Parameters.AddWithValue("@cod_depto", emp.cod_depto);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    connect.Close();
                }
            }

            return new JsonResult("Agregado exitosamente");
        }

        [HttpPut]
        public JsonResult Put(Empleado emp)
        {
            string query = @"
                              update empleado set 
                              dpi = @dpi,
                              nombre = @nombre,
                              apellidos = @apellidos,
                              sueldo = @sueldo,
                              cod_puesto = @cod_puesto,
                              cod_depto = @cod_depto
                              where id_empleado = @id_empleado";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DatabaseAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection connect = new MySqlConnection("Server=localhost;Database=empresa1;Uid=root;Pwd=ponchito"))
            {
                connect.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, connect))
                {
                    myCommand.Parameters.AddWithValue("@id_empleado", emp.id_empleado);
                    myCommand.Parameters.AddWithValue("@dpi", emp.dpi);
                    myCommand.Parameters.AddWithValue("@nombre", emp.nombre);
                    myCommand.Parameters.AddWithValue("@apellidos", emp.apellidos);
                    myCommand.Parameters.AddWithValue("@sueldo", emp.sueldo);
                    myCommand.Parameters.AddWithValue("@cod_puesto", emp.cod_puesto);
                    myCommand.Parameters.AddWithValue("@cod_depto", emp.cod_depto);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    connect.Close();
                }
            }

            return new JsonResult("Se actualizo correctamente");
        }
    }
}
