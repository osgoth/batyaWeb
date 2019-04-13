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

        public ViewResult Index ()
        {
            return View ();
        }

        public IActionResult DataBase ()
        {
            SiteContext db = new SiteContext ();

            return View (db.Sites.ToList ());
        }

        public ViewResult DBAdd ()
        {
            return View ();
        }

        [HttpPost]
        public IActionResult DBAdd (string site)
        {

            try
            {
                ViewBag.Message = $"Succesfully Added '{site}' [{Dns.GetHostAddresses (site)[0].ToString ()}]";

                using (SiteContext db = new SiteContext ())
                {
                    db.Sites.Add (new Site
                    {
                        Domain = site.ToString ()
                    });
                    db.SaveChanges ();
                }

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

        public string BlockAll ()
        {
            Handler handler = new Handler ();
            handler.BlockAll ();
            return "Blocked Everything";
        }

        public string UnblockAll ()
        {
            Handler handler = new Handler ();
            handler.UnblockAll ();
            return "Unblocked Everything";
        }

        public string Unblock ()
        {
            Handler handler = new Handler ();
            SiteContext db = new SiteContext ();
            foreach (Site site in db.Sites.ToList ())
            {
                handler.Unblock (Dns.GetHostAddresses (site.Domain) [0].ToString ());
            }

            return "blacklist - active";
        }

        public IActionResult Status ()
        {
            Handler handler = new Handler ();
            ViewBag.Message = handler.GetStatus ();
            return View ();
        }

        public string IPAddr ()
        {
            Handler handler = new Handler ();
            return handler.GetIP ();
        }

        public ViewResult Preferences ()
        {
            return View ();
        }

        public ViewResult IpOf ()
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
