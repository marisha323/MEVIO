﻿using MEVIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace MEVIO.Controllers
{
    public class ZapTeacherController : Controller
    {
        public MEVIOContext context;
        User user { get; set; }

        int selectedUserId = 0;
        int selectedStudentId = 0;

        public ZapTeacherController(MEVIOContext db)
        {
            this.context = db;
        }
        public IActionResult Teacher(int id)
        {
            
            ViewBag.Useres = context.Users.Where(o=>o.Id == id).FirstOrDefault();


            return View();
        }
        public IActionResult student(int id)
        {
            
            ViewBag.Students = context.Students.Where(o => o.Id == id).FirstOrDefault();


            return View();
        }
        public IActionResult profileBoss()
        {
            return View();
        }
        public IActionResult Index()
        {
            /*context.Users.Add(user);
            await context.SaveChangesAsync();*/
            //ViewBag.Students3 = context.Clients.AsNoTracking().ToList();
            /* return View(context.Users.FirstOrDefault());*/
            //ViewBag.Students = context.Students.AsNoTracking().ToList();

            return View();
        }
        public async Task<IActionResult> ZapTeacher([Bind] User user) {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return Redirect("/ZapTeacher/Index");
        }
    }

}
