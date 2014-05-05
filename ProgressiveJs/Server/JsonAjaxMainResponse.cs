using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgressiveJs.Enums;

namespace ProgressiveJs.Server
{
    /// <summary>
    /// An encapsulation of json response from an ajax call.
    /// </summary>
    public class JsonAjaxMainResponse
    {
        /// <summary>
        /// The string that will be passed back to the page to update the target as defined by the ajax call.
        /// Default: ""
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The type of manipulation that should be used to update the target content in the calling page.
        /// Default: "html"
        /// </summary>
        public string Manipulation { get; set; }

        /// <summary>
        /// The status of the response.
        /// </summary>
        public MessageStatus Status { get; set; }

        public JsonAjaxMainResponse(string message = "", string manipulation = "html", MessageStatus status = MessageStatus.Default)
        {
            Message = message;
            Manipulation = manipulation;
            Status = status;
        }
    }
}