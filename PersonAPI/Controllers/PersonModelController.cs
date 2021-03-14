using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonModelController : Controller
    {

        private readonly ILogger<PersonModelController> _logger;

        public PersonModelController(ILogger<PersonModelController> logger)
        {
            _logger = logger;
        }

        // GET: PersonModelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
