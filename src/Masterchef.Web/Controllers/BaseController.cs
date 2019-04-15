using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Microsoft.AspNetCore.Mvc;

namespace Masterchef.Web.Controllers
{
    public class BaseController : Controller
    {
        protected INotificationHandler<Notification> _notifications;

        public BaseController(
            INotificationHandler<Notification> notifications)
        {
            _notifications = notifications;
        }

        protected bool ValidOperation()
        {
            return (!_notifications.HasErrorNotification());
        }

        protected void Handle(string key, string value)
        {
            _notifications.Handle(new Notification(key, value));
        }

        protected void AddMessages()
        {
            if (_notifications.HasNotification())
            {
                _notifications.ListNotifications().ForEach(a =>
                {
                    switch (a.Key)
                    {
                        case ("error"):
                            TempData["errorMessage"] = a.Value;
                            break;
                        case ("info"):
                            TempData["infoMessage"] = a.Value;
                            break;
                        case ("success"):
                            TempData["successMessage"] = a.Value;
                            break;
                    }
                });
            }
        }
    }
}
