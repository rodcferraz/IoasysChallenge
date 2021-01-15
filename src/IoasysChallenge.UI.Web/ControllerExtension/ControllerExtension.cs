using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoasysChallenge.UI.Web.ControllerExtensions
{
    public static class ControllerExtension
    {
        public static JsonResult ModelErrors(this ControllerBase controller)
        {

            controller.ControllerContext.HttpContext.Response.StatusCode = 422;

            JsonResult json = new JsonResult(
              controller
              .ControllerContext
              .ModelState
              .Values
              .SelectMany(c => c.Errors)
              .Select(c => c.ErrorMessage)
              .ToArray()
              );

            return json;

        }
    }
}
