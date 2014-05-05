using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgressiveJs.Enums;

namespace ProgressiveJs.Server
{
    public class AlertMessage
    {
        public AlertMessage(MvcHtmlString message = null, MessageStatus status = MessageStatus.Default)
        {
            Message = message;
            Status = status;
        }

        public AlertMessage(string message = null, MessageStatus status = MessageStatus.Default)
        {
            Message = new MvcHtmlString(message);
            Status = status;
        }

        public MvcHtmlString Message { get; set; }

        public MessageStatus Status { get; set; }

        public string AlertClass
        {
            get
            {
                switch (Status)
                {
                    case MessageStatus.Success:
                        return "alert-box--success";
                    case MessageStatus.Warning:
                        return "alert-box--warning";
                    case MessageStatus.Error:
                        return "alert-box--error";
                    default:
                        return ""; // alert-box
                }
            }
        }
    }
}