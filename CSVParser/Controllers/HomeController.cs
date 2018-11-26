/*
    HomeController.cs
    Author: Brandon Ward
    Last update: 11/26/2018

    This Home Controller returns the view and contains
    the logic for uploadeing a csv file and adding the
    data to the two tables in the database.
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSVParser.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data;
using LumenWorks.Framework.IO.Csv;
using System.Web;

namespace CSVParser.Controllers
{
    public class HomeController : Controller
    {
        private readonly CSVDataContext _ticketContext;
        private readonly CSVDataContext _orderContext;

        public HomeController(CSVDataContext ticketContext, CSVDataContext orderContext)
        {
            _ticketContext = ticketContext;
            _orderContext = orderContext;
        }
        public ActionResult Index()         {
             return View();         } 

        /// <summary>
        /// The following method reads the uploaded .csv file
        /// and adds them to the Orders and Tickets tables within
        /// the database. This method also displays a table of the
        /// newly uploaded data from the .csv
        /// </summary>
        /// <returns>The index.</returns>
        /// <param name="upload">The file uploaded.</param>         [HttpPost]         [ValidateAntiForgeryToken]         public ActionResult Index(IFormFile upload)         {             if (ModelState.IsValid)             {                  if (upload != null && upload.Length > 0)                 {                      if (upload.FileName.EndsWith(".csv", StringComparison.Ordinal))                     {                         Stream stream = upload.OpenReadStream();                         DataTable csvTable = new DataTable();                         using (CsvReader csvReader =                             new CsvReader(new StreamReader(stream), true))                         {                             csvTable.Load(csvReader);                              //Add to database                             foreach(DataRow row in csvTable.Rows)                             {
                                Orders order = new Orders();
                                Tickets ticket = new Tickets();                                 order.FirstName = row[1].ToString();                                 order.LastName = row[2].ToString();                                 ticket.TicketNumber = row[3].ToString();                                 ticket.EventDate = DateTime.Parse(row[4].ToString()); 
                                //Add to order table                                 _orderContext.Add(order);                                 _orderContext.SaveChangesAsync();

                                //Add to ticket table
                                _ticketContext.Add(ticket);
                                _ticketContext.SaveChangesAsync();                             }                         }
                        //Return data to the view.                         return View(csvTable);                     }                     else                     {                         ModelState.AddModelError("File", "This file format is not supported. Try again.");                         return View();                     }                 }                 else                 {                     ModelState.AddModelError("File", "Please Upload Your file");                 }             }             return View();         } 

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
