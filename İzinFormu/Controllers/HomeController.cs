using İzinFormu.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace İzinFormu.Controllers
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



        public IActionResult Login()
        {

        }

        [HttpPost]
        public IActionResult Login()
        {

        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(User data)
        {



            if (!ModelState.IsValid)
            {
                return View(data);
            }




            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {

                var userTable = db.GetCollection<User>("users");


                var results = userTable.Query()
                    .Where(user => user.UserName.Contains(data.UserName))
                    .FirstOrDefault();

                if (results != null)
                {
                    ViewBag.Hata = "Bu kullanıcı adı kullanılıyor";

                    return View(data);
                }



                userTable.Insert(data);

                userTable.EnsureIndex(x => x.UserName);

            }


            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
                );
        }
    }
}
