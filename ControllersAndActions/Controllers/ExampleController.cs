using Microsoft.AspNetCore.Mvc;
using System;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;            
            return View();
        }   

        public ViewResult Result() => View((object)"Hello, world");

        public RedirectToActionResult Redirect() => RedirectToAction(nameof(Index));

        public JsonResult IndexJson() => Json(new[] { "Alice", "Bob", "Joe" });

        public ContentResult IndexContent() => Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");

        public VirtualFileResult IndexFile() => File("/lib/bootstrap/dist/css/bootstrap.css", "text/css");
    }
}