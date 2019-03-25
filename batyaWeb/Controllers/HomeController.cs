using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

        public IActionResult DataBase ()
        {
            SiteContext db = new SiteContext ();

            return View (db.Sites.ToList ());
        }

        public IActionResult DBAdd ()
        {
            return View ();
        }

        [HttpPost]
        public IActionResult DBAdd (string site)
        {

            try
            {
                using (SiteContext db = new SiteContext ())
                {
                    db.Sites.Add (new Site
                    {
                        Domain = site.ToString ()
                    });
                    db.SaveChanges ();
                }

                ViewBag.Message = $"Succesfully Added '{site}' [{Dns.GetHostAddresses (site)[0].ToString ()}]";
                return View ();
            }
            catch
            {
                ViewBag.Message = $"An Error Occured!";
                return View ();
            }
        }

        public IActionResult DBRM (int? id)
        {
            using (SiteContext db = new SiteContext ())
            {
                db.Sites.Remove (db.Sites.ToList ().FirstOrDefault (s => s.ID == id));
                db.SaveChanges ();
            }
            return RedirectToAction ("DataBase");
        }

        public IActionResult BlockAll ()
        {
            Handler handler = new Handler ();
            handler.BlockAll ();
            ViewBag.Message = "Blocked Everything";
            return View ("Index");
        }

        public IActionResult UnblockAll ()
        {
            Handler handler = new Handler ();
            handler.UnblockAll ();
            ViewBag.Message = "Unblocked Everything";
            return View ("Index");
        }

        public IActionResult Unblock ()
        {
            Handler handler = new Handler ();
            SiteContext db = new SiteContext ();
            foreach (Site site in db.Sites.ToList ())
            {
                handler.Unblock (Dns.GetHostAddresses (site.Domain) [0].ToString ());
            }

            return RedirectToAction ("DataBase");
        }

        public IActionResult Status ()
        {
            Handler handler = new Handler ();
            ViewBag.Message = handler.GetStatus ();
            return View ();
        }

        public IActionResult IPAddr ()
        {
            Handler handler = new Handler ();
            ViewBag.Message = HttpContext.Connection.RemoteIpAddress.MapToIPv4 ().ToString (); //handler.GetIP ();

            return View ("Index");
        }

        public IActionResult Preferences ()
        {
            return View ();
        }

        public IActionResult IpOf ()
        {
            return View ();
        }

        [HttpPost]
        public IActionResult IpOf (string site)
        {
            try
            {
                if (site == null)
                    ViewBag.Message = "Value cannot be null!";
                else
                {
                    ViewBag.ipv4 = Dns.GetHostAddresses (site) [0].ToString ();
                    ViewBag.ipv6 = Dns.GetHostAddresses (site) [1].ToString ();
                }
                return View ();
            }
            catch
            {
                ViewBag.Message = "Input a valid string!";
                return View ();
            }
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error ()
        {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
