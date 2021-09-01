using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebApplication1.Models;
using static WebApplication1.Models.Api;
using NLog;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Logger log = LogManager.GetCurrentClassLogger();
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
            catch (Exception ex)
            {
                log.Error(ex.Message);                
                return "Error, " + ex.Message.ToString().ToLower();
            }

        }

        public string Problema2(string a, string b)
        {
            try
            {

                return (Convert.ToInt32(a) / Convert.ToInt32(b)).ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return "Error, " + ex.Message.ToString().ToLower();
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return "Error, " + ex.Message.ToString().ToLower();
            }
        }

        public string Problema4(string km, string litros)
        {
            try
            {
                return " Uso " + (float.Parse(litros)/ Convert.ToInt32(km)).ToString() + "l por km ";
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return "Error, " + ex.Message.ToString().ToLower();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
                
    }
        
}
