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
           
            var clietStatus = Request.Form["StatusName"];
            var statusId = context?.ClientStatuses?.FirstOrDefault(o => o.StatusName.Equals(clietStatus))?.Id;
           
            
            //context.Add(zap);
            context.Clients.Add(new Client() { ClientName = ClientName, PassportNumber = DocumentNumber , ClientStatusId = statusId});
            //var category = Request.Form["Category"];
            // var catId = context?.Categories?.FirstOrDefault(o => o.Name.Equals(category)).Id;
            //product1.CategoryId = catId;
            context.SaveChanges();
            ViewBag.Categorya = context.Clients.AsNoTracking().ToList();
            return Redirect("/ZapStudent/Index");
        }
        public IActionResult ZapContract(DateTime DateStamp)
        {
            var clientId = Request.Form["ClientId"];
            var Clid = context?.Clients.FirstOrDefault(o => o.ClientName.Equals(clientId))?.Id;

            var studId = Request.Form["Studentsid"];
            var Stid = context?.Students.FirstOrDefault(o => o.StudentName.Equals(studId))?.Id;

            var EducForm = Request.Form["EducationForm"];
            var EducId = context?.EducationForms.FirstOrDefault(o=>o.EducationFormName.Equals(EducForm))?.Id;

            var Acadid = Request.Form["Academyid"];
            var AcId=context?.Academys.FirstOrDefault(o => o.AcademyName.Equals(Acadid))?.Id;

            var Seasonid = Request.Form["Seasonid"];
            var SeaId = context?.SeasonOfBeginning.FirstOrDefault(o => o.SeasonName.Equals(Seasonid))?.Id;
           
            context.Add(new Contract() { ClientId=Clid,StudentId=Stid,DateStamp=DateStamp,EducationFormId=EducId,AcademyId=AcId,SeasonOfBeginningId=SeaId });
            context.SaveChanges();
            ViewBag.Contractik = context.Contracts.AsNoTracking().ToList();

            return Redirect("/ZapStudent/Index");
        }
        
        
        
        
        
        public IActionResult ZapTeacher([Bind] User user)
        {
            

            var roleId = Request.Form["UserRoleId"];
            var UserRole = context?.UserRoles.FirstOrDefault(o => o.UserRoleName.Equals(roleId))?.Id;





            
            var files = Request.Form.Files;
            

            //var passrom = $@"{Directory.GetCurrentDirectory()}/wwwroot/Imeg1/{user.UserName.Replace(" ", "-")}";
            //Directory.CreateDirectory(passrom);

            //user.PathImgAVA = $"{files[0].FileName}";

            var passrom2 = $@"{Directory.GetCurrentDirectory()}/wwwroot/Img1/{user.UserName.Replace(" ", "-")}";
            Directory.CreateDirectory(passrom2);
            user.PathImgAVA = $"{files[0].FileName}";

            // Loop through files collection

            var path = $@"{Directory.GetCurrentDirectory()}/wwwroot/Img1/{user.UserName.Replace(" ", "-")}";
            Directory.CreateDirectory(path);
            foreach (var file in files)
            {


                //imeg = new Imeg();
                //imeg.ProductId = context.Products.Where(o => o.Name == product1.Name).FirstOrDefault().Id;

                //imeg.Pass = $"{file.FileName}";
                string FullPath = $"{path}/{file.FileName}";
                using (var fs = new FileStream(FullPath, FileMode.Create))
                {
                     file.CopyTo(fs);
                }
                var imeg = new User();

                imeg.PathImgAVA = file.FileName; /*imeg.Pass.Split("wwwroot")[1];*/
                //await context.AddAsync(imeg);
            }




            //var path2 = $@"{Directory.GetCurrentDirectory()}/wwwroot/Imeg1/{user.UserName.Replace(" ", "-")}";
            //Directory.CreateDirectory(path2);
            //foreach (var file in files)
            //{


                
            //    string FullPath = $"{path2}/{file.FileName}";
            //    using (var fs = new FileStream(FullPath, FileMode.Create))
            //    {
            //        await file.CopyToAsync(fs);
            //    }
            //    var imeg = new User();

            //    imeg.PathImgAVA = file.FileName; 
            //}

          
            user.UserRoleId = UserRole;
            context.Users.Add(user);

            context.SaveChanges();
            ViewBag.Userses = context.Users.AsNoTracking().ToList();
            return Redirect("/ZapStudent/Index");
        }



       
        //Marina

        //////////////////////////////////////////////////////////////////////////////////////////
        ///
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


        //////////////////////////////////////////////////////////////////////////////////////////




        public async Task<IActionResult> Index()
        {
            ViewBag.Status = context.ClientStatuses.AsNoTracking().ToList();
            ViewBag.ClientID = context.Clients.AsNoTracking().ToList();
            //ViewBag.Students = context.Students.AsNoTracking().ToList();
            ViewBag.RoleId=context.UserRoles.AsNoTracking().ToList();
            ViewBag.Students = context.Students.AsNoTracking().ToList();
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
