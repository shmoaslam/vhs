using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace VHS.App_Start
{
    public class CustomSelectorAction : ActionNameSelectorAttribute
    {
        public string Name { get; set; }
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var value = controllerContext.Controller.ValueProvider.GetValue(Name);
            if (value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}