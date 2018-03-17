using System;
using System.Reflection;
using System.Web.Mvc;

namespace Fishbay.Core
{
    public class GuidMethodSelectorAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            var idStr = controllerContext.RouteData.Values["id"];
            if (idStr == null)
                return false;
            Guid a;
            var result = Guid.TryParse(idStr.ToString(), out a);
            return result;
        }
    }
}