using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projecta.DataAceess;
using Projecta.Entity;
using Projecta.Models;
using Projecta.ViewModels.loanmodel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projecta.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(IndexVM model)
        {
            MyDbContext context = new MyDbContext();
            model.Items = context.Loans.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(LoanVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            MyDbContext context = new MyDbContext();
            Loan item = new Loan();
            //    model.Loans = context.Loans.ToList();
            
            item.EGN = model.EGN;
            item.FirstName = model.FirstName;
            item.Amount = model.Amount;
         
            item.LastName = model.LastName;
            context.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {

            MyDbContext context = new MyDbContext();

            Loan item = new Loan();
            item.Id = id;

            context.Loans.Remove(item);


            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            MyDbContext context = new MyDbContext();

            Loan item = context.Loans
                                .Where(u => u.Id == id)
                                .FirstOrDefault();
            if (item == null)
                return RedirectToAction("Index", "Home");

            EditVM model = new EditVM();


            model.Id = item.Id;
            model.EGN = item.EGN;
            model.Amount = item.Amount;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            MyDbContext context = new MyDbContext();
          //  model.Loans = context.Loans.ToList();
           

            Loan item = new Loan();
            item.Id = model.Id;
            item.EGN = model.EGN;
            item.Amount = model.Amount;
           if (item.Amount >= 10000)
            {
                return RedirectToAction("Index", "Home");
            }
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            context.Loans.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
