using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Models;
using static WebApplication1.Models.Api;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string Problema1(string a)
        {
            try
            {
                
                return Math.Pow(Convert.ToInt32(a), 2).ToString();
            }
            catch (OverflowException)
            {
                return "Error, debe ingresar un numero entero";
            }
            catch (FormatException)
            {
                return "Error, debe ingresar un numero";
            }
            catch (ArgumentNullException)
            {
                return "Error, campos vacios";
            }

        }

        public string Problema2(string a, string b)
        {
            try
            {

                return (Convert.ToInt32(a) / Convert.ToInt32(b)).ToString();
            }
            catch (DivideByZeroException)
            {
                return "Error, divición por 0";
            }
            catch (OverflowException)
            {
                return "Error, debe ingresar un numero entero";
            }
            catch (FormatException)
            {
                return "Error, debe ingresar un numero";
            }
            catch (ArgumentNullException)
            {
                return "Error, campos vacios";
            }
        }

        public string Problema3()
        {
            try
            {
                string listadoProv = "";
                List<Provincia> provincias = Api.GetApi();

                foreach (var provincia in provincias)
                {
                    listadoProv += $"{provincia.nombre} Id = {provincia.id} \n";
                }

                return listadoProv;
            }
            catch (NullReferenceException)
            {
                return "La lista no se copio correctamente";
            }
        }

        public string Problema4(string km, string litros)
        {
            try
            {
                return " Uso " + (float.Parse(litros)/ Convert.ToInt32(km)).ToString() + "l por km ";
            }
            catch (DivideByZeroException)
            {
                return "Error, divición por 0";
            }
            catch (OverflowException)
            {
                return "Error, debe ingresar un numero entero";
            }
            catch (FormatException)
            {
                return "Error, debe ingresar un numero";
            }
            catch (ArgumentNullException)
            {
                return "Error, campos vacios";
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
                
    }
        
}
