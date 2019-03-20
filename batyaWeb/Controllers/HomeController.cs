using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using batyaNet;
using batyaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace batyaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index ()
        {
            return View ();
        }

        public ActionResult BlockAll ()
        {
            Handler handler = new Handler ();
            handler.BlockAll ();
            ViewBag.Message = "Blocked Everything";
            return View ("Index");
        }

        public ActionResult UnblockAll ()
        {
            Handler handler = new Handler ();
            handler.UnblockAll ();
            ViewBag.Message = "Unblocked Everything";
            return View ("Index");
        }

        public ActionResult Status ()
        {
            Handler handler = new Handler ();
            ViewBag.Message = handler.GetStatus ();
            return View ();
        }

        public ActionResult IPAddr ()
        {
            Handler handler = new Handler ();
            ViewBag.Message = handler.GetIP ();
            return View ("Index");
        }

        public ActionResult Preferences ()
        {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error ()
        {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
