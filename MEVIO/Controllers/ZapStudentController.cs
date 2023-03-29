using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using static System.Net.Mime.MediaTypeNames;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Math;
using Path = System.IO.Path;
using System.IO;
using NuGet.Packaging.Signing;

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
        public IActionResult ZapClient(string ClientName, string PassportNumber, DateTime DateOfPassportIssue)
        {

            var clietStatus = Request.Form["StatusName"];
            var statusId = context?.ClientStatuses?.FirstOrDefault(o => o.StatusName.Equals(clietStatus))?.Id;


            //context.Add(zap);
            context.Clients.Add(new Client() { ClientName = ClientName, PassportNumber = PassportNumber, ClientStatusId = statusId, DateOfPassportIssue = DateOfPassportIssue });
            //var category = Request.Form["Category"];
            // var catId = context?.Categories?.FirstOrDefault(o => o.Name.Equals(category)).Id;
            //product1.CategoryId = catId;
            context.SaveChanges();
            ViewBag.Categorya = context.Clients.AsNoTrackingWithIdentityResolution().ToList();
            return Redirect("/ZapStudent/Index");
        }
        public IActionResult ZapContract(DateTime DateStamp, string Payment_Form)
        {
            var clientId = int.Parse(Request.Form["ClientId"]);
            
            var Clid = context?.Clients.FirstOrDefault(o => o.Id.Equals(clientId))?.Id;

            var studId = int.Parse(Request.Form["Studentsid"]);
            var Stid = context?.Students.FirstOrDefault(o => o.Id.Equals(studId))?.Id;

            var EducForm = int.Parse(Request.Form["EducationForm"]);
            var EducId = context?.EducationForms.FirstOrDefault(o => o.Id.Equals(EducForm))?.Id;

            var Acadid = int.Parse(Request.Form["Academyid"]);
            var AcId = context?.Academys.FirstOrDefault(o => o.Id.Equals(Acadid))?.Id;

            var Seasonid = int.Parse(Request.Form["Seasonid"]);
            var SeaId = context?.SeasonOfBeginning.FirstOrDefault(o => o.Id.Equals(Seasonid))?.Id;

            context.Add(new Contract() { ClientId = Clid, StudentId = Stid, DateStamp = DateStamp, EducationFormId = EducId, AcademyId = AcId, SeasonOfBeginningId = SeaId, Payment_Form = Payment_Form });
            context.SaveChanges();
            ViewBag.Contractik = context.Academys.AsNoTrackingWithIdentityResolution().ToList();
            
            //// Создание файла
            //System.IO.File.Create(passrom2).Close();
            var Stname = context?.Students.FirstOrDefault(o => o.Id.Equals(studId))?.StudentName;

            var passrom2 = $@"{Directory.GetCurrentDirectory()}\wwwroot\Contract\{Stname}\{Stid}\Contract_{Stname}.docx";

            // Создание директории, если ее нет
            Directory.CreateDirectory(Path.GetDirectoryName(passrom2));

            // Создание файла
            System.IO.File.Create($"\\Contract_{studId}.docx").Close();


            var sourceFilePath = $@"{Directory.GetCurrentDirectory()}/wwwroot/document/Contract.docx";
            var destFilePath = $@"{Directory.GetCurrentDirectory()}/wwwroot/Contract/{Stname}/{Stid}/Contract_{Stname}.docx";

            // Создание директории, если её ещё нет


            // Копирование документа
            System.IO.File.Copy(sourceFilePath, destFilePath, true);

            // Открытие документа Word
            //using (var document2 = WordprocessingDocument.Open($@"{Directory.GetCurrentDirectory()}/wwwroot/document/Contract.docx", true))
            //{
            //    // Копирование документа
            //    var sourceFilePath = $@"{Directory.GetCurrentDirectory()}/wwwroot/document/Contract.docx";
            //    var destFilePath = $@"{Directory.GetCurrentDirectory()}\wwwroot\Contract\{studId}\Contract_{studId}.docx";
            //    System.IO.File.Copy(sourceFilePath, destFilePath, true);

            //    // Закрытие документа
            //    document2.Close();
            //}

            // Открытие созданного документа Word
            using (var document = WordprocessingDocument.Open($@"{Directory.GetCurrentDirectory()}\wwwroot\Contract\{Stname}\{Stid}\Contract_{Stname}.docx", true))
            {
                var body = document.MainDocumentPart.Document.Body;

                
                // Замена текста в документе
                foreach (var text in body.Descendants<Text>())
                {
                    var nameAcad = context.Academys.Where(o=>o.Id== AcId).FirstOrDefault().AcademyName;
                    var AdresAcad = context.Academys.Where(o => o.Id == AcId).FirstOrDefault().Address;
                    var RequisitesId = context.Academys.Where(o => o.Id == AcId).FirstOrDefault().RequisitesId;
                    var OKPO=context.Requisites.Where(o => o.Id == RequisitesId).FirstOrDefault().OKPO;
                    var CheckingAccount = context.Requisites.Where(o => o.Id == RequisitesId).FirstOrDefault().CheckingAccount;
                    var BankName = context.Requisites.Where(o => o.Id == RequisitesId).FirstOrDefault().BankName;
                    var MFO = context.Requisites.Where(o => o.Id == RequisitesId).FirstOrDefault().MFO;


                    var ClientName = context.Clients.Where(o=>o.Id== Clid).FirstOrDefault().ClientName;
                    var PassportNumber = context.Clients.Where(o => o.Id == Clid).FirstOrDefault().PassportNumber;
                    var DateOfPassportIssue = context.Clients.Where(o => o.Id == Clid).FirstOrDefault().DateOfPassportIssue.ToString();
                    var TIN = context.Clients.Where(o => o.Id == Clid).FirstOrDefault().TIN;


                    //var direc = context.Academys.Where(o => o.Id == AcId).FirstOrDefault().UserId;
                    //var roleDirector = context.UserRoles.Where(o => o.Id == 2).FirstOrDefault().Id;
                    //var UserName2 = context.Users.Where(a=>a.UserRoleId==roleDirector).FirstOrDefault().Id;
                    //var UserName = context.Users.Where(o => o.Id == UserName2).FirstOrDefault().UserName;


                    var userId = context.Academys.Where(o => o.Id == AcId).FirstOrDefault().UserId;

                    // Получить идентификатор роли "Директор"
                    var roleId = context.UserRoles.Where(o => o.Id == 2).FirstOrDefault().Id;

                    // Получить имя пользователя-директора с указанным идентификатором роли
                    var UserName = context.Users.Where(u => u.Id == userId && u.UserRoleId == roleId).Select(u => u.UserName).FirstOrDefault();

                    var DateStamp2 = context.Contracts.FirstOrDefault().DateStamp.ToString();
                    var PaymentForm = context.Contracts.FirstOrDefault().Payment_Form;

                    

                    var Price = context.EducationForms.Where(o=>o.Id== EducId).FirstOrDefault().Price.ToString();

                    var studName = context.Students.Where(o => o.Id == Stid).FirstOrDefault().StudentName; 
                    var studCode = context.Students.Where(o=>o.Id== Stid).FirstOrDefault().StudentCode;
                    var DiscountSum = context.Students.Where(o => o.Id == Stid).FirstOrDefault().DiscountSum.ToString();
                    var Discount_Description = context.Students.Where(o => o.Id == Stid).FirstOrDefault().Discount_Description;

                    if (text.Text.Contains("Address"))
                    {
                        text.Text = text.Text.Replace("Address", AdresAcad);
                    }
                    if (text.Text.Contains("AcademyName"))
                    {
                        text.Text = text.Text.Replace("AcademyName", nameAcad);
                    }
                    if (text.Text.Contains("OKPO"))
                    {
                        text.Text = text.Text.Replace("OKPO", OKPO);
                    }
                    if (text.Text.Contains("CheckingAccount"))
                    {
                        text.Text = text.Text.Replace("CheckingAccount", CheckingAccount);
                    }
                    if (text.Text.Contains("BankName"))
                    {
                        text.Text = text.Text.Replace("BankName", BankName);
                    }
                    if (text.Text.Contains("MFO"))
                    {
                        text.Text = text.Text.Replace("MFO", MFO);
                    }


                    if (text.Text.Contains("ClientName"))
                    {
                        text.Text = text.Text.Replace("ClientName", ClientName);
                    }
                    if (text.Text.Contains("StudentCode"))
                    {
                        text.Text = text.Text.Replace("StudentCode", studCode);
                    }
                    if (text.Text.Contains("DateStamp"))
                    {
                        text.Text = text.Text.Replace("DateStamp", DateStamp2);
                    }
                    if (text.Text.Contains("StudentName"))
                    {
                        text.Text = text.Text.Replace("StudentName", studName);
                    }
                    if (text.Text.Contains("Price"))
                    {
                        text.Text = text.Text.Replace("Price", Price);
                    }
                    if (text.Text.Contains("Price"))
                    {
                        text.Text = text.Text.Replace("Price", Price);
                    }
                    if (text.Text.Contains("UserName"))
                    {
                        text.Text = text.Text.Replace("UserName", UserName);
                    }

                    if (text.Text.Contains("PassportNumber"))
                    {
                        text.Text = text.Text.Replace("PassportNumber", PassportNumber);
                    }
                    if (text.Text.Contains("DateOfPassportIssue"))
                    {
                        text.Text = text.Text.Replace("DateOfPassportIssue", DateOfPassportIssue);
                    }
                    if (text.Text.Contains("TIN"))
                    {
                        text.Text = text.Text.Replace("TIN", TIN);
                    }
                    if (text.Text.Contains("Payment_Form"))
                    {
                        text.Text = text.Text.Replace("Payment_Form", PaymentForm);
                    }
                    if (text.Text.Contains("DiscountSum"))
                    {
                        text.Text = text.Text.Replace("DiscountSum", DiscountSum);
                    }
                    if (text.Text.Contains("Discount_Description"))
                    {
                        text.Text = text.Text.Replace("Discount_Description", Discount_Description);
                    }



                    // Сохранение изменений в документе
                    document.Save();
                }

                // Возвращение файла в ответе
                return File($"~/Contract/{Stname}/{Stid}/Contract_{Stname}.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"Contract_{Stname}.docx");
            }

            //return File($"~/Contract/{studId}/Contract_{studId}.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"Contract_{studId}.docx");
            //}

        }

            public IActionResult ZapTeacher([Bind] User user)
            {


                var roleId = Request.Form["UserRoleId"];
                var UserRole = context?.UserRoles.FirstOrDefault(o => o.UserRoleName.Equals(roleId))?.Id;






                var files = Request.Form.Files;


                //var passrom = $@"{Directory.GetCurrentDirectory()}/wwwroot/Imeg1/{user.UserName.Replace(" ", "-")}";
                //Directory.CreateDirectory(passrom);

                //user.PathImgAVA = $"{files[0].FileName}";

                var passrom2 = $@"{Directory.GetCurrentDirectory()}/wwwroot/Imeg1/{user.UserName.Replace(" ", "-")}";
                Directory.CreateDirectory(passrom2);
                user.PathImgAVA = $"{files[0].FileName.Replace(" ", "")}";

                // Loop through files collection

                var path = $@"{Directory.GetCurrentDirectory()}/wwwroot/Imeg1/{user.UserName.Replace(" ", "-")}";
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

                    imeg.PathImgAVA = file.FileName.Replace(" ","-"); /*imeg.Pass.Split("wwwroot")[1];*/
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
                ViewBag.Userses = context.Users.AsNoTrackingWithIdentityResolution().ToList();
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
                student.PathImgAVA = $"{files[0].FileName.Replace(" ", "-")}";
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

                    imeg.PathImgAVA = file.FileName.Replace(" ", "-"); /*imeg.Pass.Split("wwwroot")[1];*/
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
                ViewBag.Status = context.ClientStatuses.AsNoTrackingWithIdentityResolution().ToList();
                ViewBag.ClientID = context.Clients.AsNoTrackingWithIdentityResolution().ToList();
                //ViewBag.Students = context.Students.AsNoTracking().ToList();
                ViewBag.RoleId = context.UserRoles.AsNoTrackingWithIdentityResolution().ToList();
                ViewBag.Students = context.Students.AsNoTrackingWithIdentityResolution().ToList();
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

                ViewBag.EducationFormId = context.EducationForms.AsNoTrackingWithIdentityResolution().ToList();
                ViewBag.AcademiID = context.Academys.AsNoTrackingWithIdentityResolution().ToList();
                ViewBag.SeasonID = context.SeasonOfBeginning.AsNoTrackingWithIdentityResolution().ToList();
                return View();
            }
        }
    }


