using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.notifications
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
