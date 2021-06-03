
using Microsoft.AspNetCore.Mvc;
using BasicASP.NETMvc.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace BasicASP.NETMvc.Controllers
{
    [AllowAnonymous]
    public class ActionResultController : Controller
    {
        // GET: ActionResult
        public ActionResult Index()
        {
            //basic points 1 change "null" to correct value.
            return View();
        }

        public ActionResult Baidu()
        {
            //basic points 2 change "" to Redirect to www.baidu.com
            var result = new RedirectResult("http://www.baidu.com");
            return result;
        }

        public ActionResult Page()
        {
            //basic points 3 change "" to correct value.
            string str = "this is content";
            return Content(str);
        }

        public ActionResult EmptyAction()
        {
            //basic points 4 change "null" to correct value.
            return new EmptyResult();
        }

        public RedirectToActionResult Redirect2Action()
        {
            //basic points 5 change null : Redirect to Baidu Action
            return RedirectToAction("Baidu");
        }

        public RedirectToRouteResult Redirect2Route()
        {
            //basic points 6 change null : Redirect to Page Route
            return RedirectToRoute(@"~\ActionResult\Page");
        }

        public ActionResult JsonResult()
        {
            var result = new JsonObject("ActionResultController", "JsonResult");
            //basic points 7  change null to return a json obj
            return Json(result);
        }

        public ContentResult ScriptResult()
        {
            var returnData=new ContentResult();
            var result = "<script><alert>hi,welcome to .net</alert></script>";
            returnData.Content = result;
            //basic points 8 change null to return a script code
            returnData.ContentType = "application/x-javascript";
            return returnData;
        }

        public ActionResult HttpUnauthorizedResult()
        {
            //basic points 9 change "null" to correct value.
            return new UnauthorizedResult();
        }

        public ActionResult HttpNotFoundResult()
        {
            
            //basic points 10 change "null" to correct value.
            return NotFound();
        }

        public ActionResult HttpStatusCodeResult()
        {
            //basic points 11 change "null" to correct value.
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        }

    }
}