using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgressiveJs.Enums;

namespace ProgressiveJs.Server
{
    public class JsonAjaxResponse
    {
        /// <summary>
        /// The encapsulated main response that will be used to replace the target as specified from the ajax call.
        /// </summary>
        public JsonAjaxMainResponse MainResponse { get; set; }

        /// <summary>
        /// A list of additional items that can be used to update various portions of the page from which the ajax call was made.
        /// </summary>
        public List<JsonAjaxResponseItem> Items { get; set; }

        /// <summary>
        /// A status code message that can be used to take subsequent action.
        /// </summary>
        public string StatusCode { get; set; }

        public JsonAjaxResponse(string message = "", string manipulation = "html", MessageStatus status = MessageStatus.Default)
        {
            MainResponse = new JsonAjaxMainResponse(message, manipulation, status);
            Items = new List<JsonAjaxResponseItem>();
        }
    }
}