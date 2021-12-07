using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicios.Unidad2.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ejercicios.Unidad2.Filter
{
    public class IsCustomer : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetInt32("UserExist") == 1)
            {
                context.Result = new RedirectResult("/Movies");
                return;
            }

            if (context.HttpContext.Session.GetInt32("TypeUser") != (int)TypeUser.Customer)
            {
                context.Result = new RedirectResult("/Movies");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
