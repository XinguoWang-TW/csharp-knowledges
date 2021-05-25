
using Microsoft.AspNetCore.Mvc;
using BasicASP.NETMvc.Models;
using Xunit;
using BasicASP.NETMvc.Controllers;

namespace BasicASP.NETCoreMvcTest
{
    public class ActionResultControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            ActionResultController controller = new ActionResultController();
            ActionResult result = controller.Index();
            Assert.NotNull(result);
        }

        [Fact]
        public void BaiduTest()
        {
            ActionResultController controller = new ActionResultController();
            var result = controller.Baidu() as RedirectResult;
            Assert.Equal("http://www.baidu.com", result.Url);
        }

        [Fact]
        public void PageTest()
        {
            ActionResultController controller = new ActionResultController();
            var result = controller.Page() as ContentResult;
            Assert.Equal("this is content", result.Content);
        }

        [Fact]
        public void EmptyActionTest()
        {
            var controller = new ActionResultController();
            var result = controller.EmptyAction() as EmptyResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void Redirect2ActionTest()
        {
            var controller = new ActionResultController();
            var result = controller.Redirect2Action() as RedirectToActionResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void Redirect2RouteTest()
        {
            var controller = new ActionResultController();
            var result = controller.Redirect2Route() as RedirectToRouteResult;
            Assert.Equal(@"~\ActionResult\Page", result.RouteName);
        }

        [Fact]
        public void JsonResultTest()
        {
            var controller = new ActionResultController();
            var result = controller.JsonResult() as JsonResult;
            var data = new JsonObject("ActionResultController", "JsonResult");
            Assert.Equal(data.ToString(), result.Value.ToString());
        }

        [Fact]
        public void ScriptResultTest()
        {
            var controller = new ActionResultController();
            var result = controller.ScriptResult() as ContentResult;
            Assert.Equal("<script><alert>hi,welcome to .net</alert></script>", result.Content);
        }

        [Fact]
        public void HttpUnauthorizedResultTest()
        {
            var controller = new ActionResultController();
            var result = controller.HttpUnauthorizedResult();
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public void HttpNotFoundResultTest()
        {
            var controller = new ActionResultController();
            var result = controller.HttpNotFoundResult();
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void HttpStatusCodeResultTest()
        {
            var controller = new ActionResultController();
            var result = controller.HttpStatusCodeResult();
            Assert.IsType<StatusCodeResult>(result);
        }
    }
}