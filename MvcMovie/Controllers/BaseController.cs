using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Helpers;

namespace MvcMovie.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            //Attempt to read culture cookie from request
            HttpCookie cultureCookie = Request.Cookies["culture"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                //Optain it form HTTP header AcceptLanguages
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0
                    ? Request.UserLanguages[0]
                    : null;             
            }
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName);

            // Modif current thread's cultures
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }

    }
}