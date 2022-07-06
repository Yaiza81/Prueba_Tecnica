using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Web.Helper
{
    public class EmpleadoApi
    {
        public HttpClient Initial()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            return client;

        }

    }
}
