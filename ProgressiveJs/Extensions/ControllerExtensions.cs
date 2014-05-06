using System.IO;
using System.Web.Mvc;

namespace ProgressiveJs.Extensions
{
    public static class ControllerExtensions
    {
        #region RenderSimpleMessage
        public static void SetSimpleMessageData(this Controller controller, bool success, string successMessage, string failureMessage)
        {
            controller.SetSimpleMessageData(success, success ? successMessage : failureMessage);
        }

        public static void SetSimpleMessageData(this Controller controller, bool success, string message)
        {
            controller.TempData["success"] = success;
            controller.TempData["message"] = message;
        }

        /// <summary>
        /// A controller extension method to modularize the setting of the TempData values used in the "_SimpleMessage" view.
        /// </summary>
        /// <param name="controller">The controller class that is being extended.</param>
        /// <param name="success">A boolean indication of whether or not a successful or unsuccesful message is to be printed.</param>
        /// <param name="successMessage">The message to be if the result was successful.</param>
        /// <param name="failureMessage">The message to be if the result was unsuccessful.</param>
        /// <returns>
        /// A rendering of the _SimpleMessage partial view that makes use of the TempData dictionary to provide a
        /// modularized alert style message to users.
        /// </returns>
        public static string RenderSimpleMessage(this Controller controller, bool success, string successMessage, string failureMessage)
        {
            return controller.RenderSimpleMessage(success, success ? successMessage : failureMessage);
        }

        /// <summary>
        /// A controller extension method to modularize the setting of the TempData values used in the "_SimpleMessage" view.
        /// </summary>
        /// <param name="controller">The controller class that is being extended.</param>
        /// <param name="success">A boolean indication of whether or not a successful or unsuccesful message is to be printed.</param>
        /// <param name="message">The message to be printed.</param>
        /// <returns>
        /// A rendering of the _SimpleMessage partial view that makes use of the TempData dictionary to provide a
        /// modularized alert style message to users.
        /// </returns>
        public static string RenderSimpleMessage(this Controller controller, bool success, string message)
        {
            controller.SetSimpleMessageData(success, message);
            return controller.RenderPartialViewToString("_SimpleMessage");
        }
        #endregion

        #region RenderPartialViewToString
        // From http://craftycodeblog.com/2010/05/15/asp-net-mvc-render-partial-view-to-string/
        // Allows contents of a partial view to be returned as a string
        public static string RenderPartialViewToString(this Controller controller)
        {
            return controller.RenderPartialViewToString(null, null);
        }

        public static string RenderPartialViewToString(this Controller controller, string viewName)
        {
            return controller.RenderPartialViewToString(viewName, null);
        }

        public static string RenderPartialViewToString(this Controller controller, object model)
        {
            return controller.RenderPartialViewToString(null, model);
        }

        public static string RenderPartialViewToString(this Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");

            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
        #endregion
    }
}
