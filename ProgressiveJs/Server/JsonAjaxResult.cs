using ProgressiveJs.Enums;
using ProgressiveJs.Helpers;
using System.Collections.Generic;

namespace ProgressiveJs.Server
{
    public class JsonAjaxResult : JsonNetResult
    {
        public JsonAjaxResult(string message = "", string manipulation = "html", MessageStatus status = MessageStatus.Default)
        {
            Data = new JsonAjaxResponse(message, manipulation, status);
        }

        public JsonAjaxResult Attr(string selector, string attr, string value)
        {
            return AddItem(selector, new List<object> { attr, value }, "attr");
        }

        public JsonAjaxResult After(string selector, string content)
        {
            return AddContent(selector, content, "after");
        }

        public JsonAjaxResult Before(string selector, string content)
        {
            return AddContent(selector, content, "before");
        }

        public JsonAjaxResult Html(string selector, string html)
        {
            return AddContent(selector, html);
        }

        public JsonAjaxResult Refresh(string selector, string attr)
        {
            return AddContent(selector, attr, "refresh");
        }

        public JsonAjaxResult RemoveAttr(string selector, string attr)
        {
            return AddContent(selector, attr, "removeAttr", false);
        }

        public JsonAjaxResult ReplaceWith(string selector, string content)
        {
            return AddContent(selector, content, "replaceWith");
        }

        public JsonAjaxResult SetValue(string key, object value)
        {
            return AddContent("#" + key, value, "refresh");
        }

        public JsonAjaxResult Text(string selector, string text)
        {
            return AddContent(selector, text, "text");
        }

        public JsonAjaxResult AddContent(string selector, object content, string manipulation = "html", bool reinitializeJs = true)
        {
            return AddItem(selector, new List<object> { content }, manipulation, reinitializeJs);
        }

        public JsonAjaxResult AddItem(string selector = ".response", List<object> args = null, string manipulation = "html", bool reinitializeJs = true)
        {
            var data = Data as JsonAjaxResponse;
            if (data != null)
                data.Items.Add(new JsonAjaxResponseItem(args, selector, manipulation, reinitializeJs));
            return this;
        }

        public JsonAjaxResult SetMessage(string message = "", string manip = "html", MessageStatus status = MessageStatus.Default)
        {
            var data = Data as JsonAjaxResponse;
            if (data != null)
            {
                data.MainResponse.Message = message;
                data.MainResponse.Manipulation = manip;
                data.MainResponse.Status = status;
            }
            return this;
        }

        public JsonAjaxResult SetStatusCode(string status, string message = null)
        {
            var data = Data as JsonAjaxResponse;
            if (data != null)
            {
                data.StatusCode = status;
                if (!string.IsNullOrEmpty(message))
                    data.MainResponse.Message = message;
            }
            return this;
        }
    }
}