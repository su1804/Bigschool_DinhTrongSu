﻿using Bigschool_DinhTrongSu.Models;
using Bigschool_DinhTrongSu.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bigschool_DinhTrongSu.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
      [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Palce = viewModel.Place,
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}