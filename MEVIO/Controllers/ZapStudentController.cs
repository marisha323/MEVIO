using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEVIO.Controllers
{
    public class ZapStudentController : Controller
    {
        public MEVIOContext context;
        User user { get; set; }
        Student students { get; set; }

        public ZapStudentController(MEVIOContext db)
        {
            this.context = db;
        }
        public  IActionResult ZapClient(string ClientName,string DocumentNumber)
        {
            context.Clients.Add(new Client() { ClientName =ClientName });
            context.Clients.Add(new Client() { PassportNumber = DocumentNumber });
            //var clietStatus = Request.Form["ClientStatus"];
            //var statusId=context?.ClientStatuses?.FirstOrDefault(o=>o.StatusName.Equals(clietStatus))?.Id;
            //var zap = new Client();
            //zap.ClientStatusId = statusId;
            //context.Add(zap);
            //var category = Request.Form["Category"];
            // var catId = context?.Categories?.FirstOrDefault(o => o.Name.Equals(category)).Id;
            //product1.CategoryId = catId;
            context.SaveChanges();
            ViewBag.Categorya = context.Clients.AsNoTracking().ToList();
            return Redirect("/ZapStudent/Index");
        }
        public async Task<IActionResult> ZapContract([Bind] Contract contract)
        {
            return View();
        }
        public async Task<IActionResult> ZapTeacher([Bind] User user)
        {
            return View();
        }

        public async Task<IActionResult> ZapStudent([Bind("Id,StudentName,Phone,Email,MyStatLogin,MyStatPassword,Login365,StudentCode,PersonDocumentNumber,DateOfIssuePassport,TIN,IsDicount,Discount_Description,DiscountSum,Birthdate,PathImgAVA")] Student student)
        {
            //var contract = Request.Form["EducationForm"];
            //var catId = context?.EducationForms?.FirstOrDefault(o => o.EducationFormName.Equals(contract)).Id;
            //product1.CategoryId = catId;
           
           


            //await context.SaveChangesAsync();

            IFormFileCollection files = Request.Form.Files;

            var passrom = $@"{Directory.GetCurrentDirectory()}/wwwroot/Imeg2/{student.StudentName.Replace(" ", "-")}";
            Directory.CreateDirectory(passrom);
            student.PathImgAVA = $"{files[0].FileName}";
            //using (var fs = new FileStream(product1.PathLong, FileMode.Create))
            //{
            //    await files[0].CopyToAsync(fs);
            //}
            //product1.PathLong = product1.PathLong.Split("wwwroot")[1];
            //context.Students.Add(student);
            //await context.SaveChangesAsync();

            //product1 = context.Products.Where(o => o.Name == product1.Name).AsNoTracking().FirstOrDefault();
            // context.Imegs.Add(new Imeg() { Pass = files[0].FileName, ProductId = product1.Id });
            // context.AddAsync(product1);

            //await context.SaveChangesAsync();

            //for (int i = 1; i < files.Count; i++)
            //{}
            var path = $@"{Directory.GetCurrentDirectory()}/wwwroot/Imeg2/{student.StudentName.Replace(" ", "-")}";
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

                imeg.PathImgAVA = file.FileName; /*imeg.Pass.Split("wwwroot")[1];*/
                //await context.AddAsync(imeg);
            }



            



            context.Students.Add(student);
            await context.SaveChangesAsync();
           // ViewBag.Students = context.Students.AsNoTracking().ToList();
            return Redirect("/ZapStudent/Index");
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Status = context.ClientStatuses.AsNoTracking().ToList();
            ViewBag.ClientID = context.Clients.AsNoTracking().ToList();
            ViewBag.Students = context.Students.AsNoTracking().ToList();

            //ViewBag.Students = context.Students.AsNoTracking().ToList();
            //ViewBag.Students = context.Students.FirstOrDefault().StudentName;
            //ViewBag.Students=context.Students.AsNoTracking().Where(s => s.StudentName != null).ToList();
            // ViewBag.StudentID = context.Students
            //.Where(s => s.ContractId != null) 
            //.AsNoTracking()
            //.ToList();
            //List<Student> students = context.Students.ToList();
            // ViewBag.StudentID = students;

            //if (Request.ContentType != null && Request.ContentType.StartsWith("multipart/form-data"))
            //{
            //    ViewBag.Students = context?.Students?.Where(o => o.StudentName=)).To;
            //    // ... остальной код
            //}
            //else
            //{
            //    throw new Exception("Incorrect Content-Type: " + Request.ContentType);
            //}

            //обнова записи в студента
            //foreach (var contract in contracts)
            //{
            //    var student = context.Students.Single(s => s.Id == contract.StudentId);
            //    student.ContractId = contract.Id;
            //}
            //context.SaveChanges();

            ViewBag.EducationFormId = context.EducationForms.AsNoTracking().ToList();
            ViewBag.AcademiID = context.Academys.AsNoTracking().ToList();
            ViewBag.SeasonID = context.SeasonOfBeginning.AsNoTracking().ToList();
            return View();
        }
    }
}
