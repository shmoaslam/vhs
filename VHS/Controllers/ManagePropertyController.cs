﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VHS.Interface;
using VHS.Services.ViewModel;

namespace VHS.Controllers
{
    public class ManagePropertyController : Controller
    {
        private IManageProperty _manageProperty;
        // GET: ManageProperty
        public ManagePropertyController(IManageProperty manageProperty)
        {
            _manageProperty = manageProperty;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Approve()
        {
            return View();
        }
        public ActionResult Waiting()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Assign()
        {
            var assignProperty = _manageProperty.GetAssignedProperty();
            return View(assignProperty);
        }
        [HttpGet]
        public ActionResult Assigned()
        {
            var assignProperty = _manageProperty.GetAssignedProperty();
            return View(assignProperty);
        }
        [HttpPost]
        public ActionResult Assign(PropertyRMViewModel proprmView)
        {
            var result = _manageProperty.SetPropertyToRm(proprmView);
            if (result)
            {
                return Json("1");
            }
            else
            {
                return Json("2");
            }


        }
       
    }
}