using DocumentFormat.OpenXml.InkML;
using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MEVIO.Controllers
{
    public class HistoryMeasureController : Controller
    {

        public MEVIOContext context;
        public HistoryMeasureController(MEVIOContext db)
        {
            this.context = db;



        }
        public IActionResult Index()
        {
            User user = null;
            string UserLoggedIn = HttpContext.Request.Cookies["UserLoggedIn"];
            if (UserLoggedIn != null && UserLoggedIn != "")
            {
                user = JsonSerializer.Deserialize<User>(UserLoggedIn);
                ViewBag.NameUser = user.UserName;
                ViewBag.UsersId = user.Id;
                ViewBag.CurrentRole = user.UserRoleId;
            }
            ViewBag.Useres = context.Users.ToList();

            ViewBag.MeasureUsers = context.MeasuresUsers.ToList();
            ViewBag.UserAccept = context.UserAcceptStatuses.ToList();
            ViewBag.Measures = context.Measures.Where(m => m.End < DateTime.Now).ToList();
            //ViewBag.Measures2 = context.Measures.Where(m => m.End < DateTime.Now).ToList();



            return View();
        }
        public async Task<IActionResult> AddImgMeasure([Bind] MeasurePhotos measurePhotos, string MeasureName)
        {
            //string MeasureName = Request.Form["MeasureName"];
            var meas = context.Measures.Where(o => o.MeasureName == MeasureName).FirstOrDefault().Id;
            var measName = context.Measures.Where(o => o.MeasureName == MeasureName).FirstOrDefault().MeasureName;

            IFormFileCollection files = Request.Form.Files;


            var passrom = $@"{Directory.GetCurrentDirectory()}/wwwroot/MeasurePhoto/{meas}/{measName.Replace(" ", "-")}";

            Directory.CreateDirectory(passrom);
            measurePhotos.PhotoPath = $"{files[0].FileName.Replace(" ", "-")}";


            var path = $@"{Directory.GetCurrentDirectory()}/wwwroot/MeasurePhoto/{meas}/{measName.Replace(" ", "-")}";
            Directory.CreateDirectory(path);
            foreach (var file in files)
            {


                //imeg = new Imeg();
                //imeg.ProductId = context.Products.Where(o => o.Name == product1.Name).FirstOrDefault().Id;

                //imeg.Pass = $"{file.FileName}";
                string FullPath = $"{path}/{file.FileName}";
                using (var fs = new FileStream(FullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
                var imeg = new Student();
                
                measurePhotos.PhotoPath = file.FileName.Replace(" ", "-"); /*imeg.Pass.Split("wwwroot")[1];*/
                //await context.AddAsync(imeg);
            }


            measurePhotos.MeasureId = meas;
            context.MeasuresPhotos.Add(measurePhotos);
            context.SaveChanges();


            return Redirect("/HistoryMeasure/Index");
        }
        public async Task<IActionResult> AddVideoMeasure([Bind] MeasureVideos measureVideos, string MeasureName)
        {
            //string MeasureName = Request.Form["MeasureName"];
            var meas = context.Measures.Where(o => o.MeasureName == MeasureName).FirstOrDefault().Id;
            var measName = context.Measures.Where(o => o.MeasureName == MeasureName).FirstOrDefault().MeasureName;

            IFormFileCollection files = Request.Form.Files;


            var passrom = $@"{Directory.GetCurrentDirectory()}/wwwroot/MeasureVideo/{meas}/{measName.Replace(" ", "-")}";

            Directory.CreateDirectory(passrom);
            measureVideos.VideoPath = $"{files[0].FileName.Replace(" ", "-")}";


            var path = $@"{Directory.GetCurrentDirectory()}/wwwroot/MeasureVideo/{meas}/{measName.Replace(" ", "-")}";
            Directory.CreateDirectory(path);
            foreach (var file in files)
            {


                //imeg = new Imeg();
                //imeg.ProductId = context.Products.Where(o => o.Name == product1.Name).FirstOrDefault().Id;

                //imeg.Pass = $"{file.FileName}";
                string FullPath = $"{path}/{file.FileName}";
                using (var fs = new FileStream(FullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
                var imeg = new Student();

                measureVideos.VideoPath = file.FileName.Replace(" ", "-"); /*imeg.Pass.Split("wwwroot")[1];*/
                //await context.AddAsync(imeg);
            }


            measureVideos.MeasureId = meas;
            context.MeasuresVideos.Add(measureVideos);
            context.SaveChanges();


            return Redirect("/HistoryMeasure/Index");
        }
    }
}
