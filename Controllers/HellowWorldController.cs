using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcFirst.Controllers;

public class HelloWorldController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
    
    // GET: /HelloWorld/Welcome/ 
    // Requires using System.Text.Encodings.Web;
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["message"] = "Hello" + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}

    
