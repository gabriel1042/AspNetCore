using erp_usitronic.business.notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notificacao);
    }
}
