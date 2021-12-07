using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ejercicios.Unidad2.Filter
{
    public class NotLogged : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetInt32("UserExist") == 1)
            {
                context.Result = new RedirectResult("/Movies");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
