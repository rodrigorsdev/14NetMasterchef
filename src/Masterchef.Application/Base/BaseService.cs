using FluentValidation.Results;
using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Masterchef.Core.Data.Interface;

namespace Masterchef.Application.Base
{
    public abstract class BaseService
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler<Notification> _notification;

        public BaseService(
            IUnitOfWork uow,
            INotificationHandler<Notification> notification)
        {
            _uow = uow;
            _notification = notification;
        }

        protected void NotifyValidationError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _notification.Handle(new Notification("error", error.ErrorMessage));
        }

        protected bool Commit()
        {
            if (_notification.HasNotification())
                return false;

            var commandResponse = _uow.Commit();

            if (commandResponse.Success)
                return true;

            _notification.Handle(new Notification("error", "Commit error!"));

            return false;
        }
    }
}
