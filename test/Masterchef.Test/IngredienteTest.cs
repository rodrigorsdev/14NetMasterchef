using Masterchef.Application.Ingrediente.Interface;
using Masterchef.Application.Ingrediente.Service;
using Masterchef.Application.Ingrediente.ViewModel;
using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Masterchef.Core.Data.Interface;
using Masterchef.Domain.Ingrediente.Interface;
using Moq;
using System;
using Xunit;

namespace Masterchef.Test
{
    public class IngredienteTest
    {
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<INotificationHandler<Notification>> _notification;
        private readonly Mock<IIngredienteRepository> _repository;

        private readonly IIngredienteService _service;

        public IngredienteTest()
        {
            _uow = new Mock<IUnitOfWork>();
            _notification = new Mock<INotificationHandler<Notification>>();
            _repository = new Mock<IIngredienteRepository>();

            _service = new IngredienteService(
                _uow.Object,
                _notification.Object,
                _repository.Object);
        }

        [Fact]
        public void AddErrorTest()
        {
            _uow.Setup(a => a.Commit())
                .Returns(new Core.Data.Vo.CommitResponse(false));

            _notification.Setup(a => a.HasErrorNotification())
                .Returns(true);

            AddIngrediente vmodel = new AddIngrediente
            {
                Id = Guid.NewGuid(),
                Nome = string.Empty,
                UnidadeMedida = "kg"
            };

            _service.Add(vmodel);

            Assert.True(_notification.Object.HasErrorNotification());
        }

        [Fact]
        public void AddSuccessTest()
        {
            _uow.Setup(a => a.Commit())
                .Returns(new Core.Data.Vo.CommitResponse(true));

            AddIngrediente vmodel = new AddIngrediente
            {
                Id = Guid.NewGuid(),
                Nome = "Nome",
                UnidadeMedida = "kg"
            };

            _service.Add(vmodel);

            Assert.False(_notification.Object.HasErrorNotification());
        }
    }
}
