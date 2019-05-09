using Masterchef.Application.Categoria.Interface;
using Masterchef.Application.Categoria.Service;
using Masterchef.Application.Categoria.ViewModel;
using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Masterchef.Core.Data.Interface;
using Masterchef.Domain.Categoria.Interface;
using Moq;
using System;
using Xunit;

namespace Masterchef.Test
{
    public class CategoriaTest
    {
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<INotificationHandler<Notification>> _notification;
        private readonly Mock<ICategoriaRepository> _repository;

        private readonly ICategoriaService _service;

        public CategoriaTest()
        {
            _uow = new Mock<IUnitOfWork>();
            _notification = new Mock<INotificationHandler<Notification>>();
            _repository = new Mock<ICategoriaRepository>();

            _service = new CategoriaService(
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

            AddCategoria vmodel = new AddCategoria
            {
                Id = Guid.NewGuid(),
                Nome = string.Empty,
                Descricao = "Descrição"
            };

            _service.Add(vmodel);

            Assert.True(_notification.Object.HasErrorNotification());
        }

        [Fact]
        public void AddSuccessTest()
        {
            _uow.Setup(a => a.Commit())
                .Returns(new Core.Data.Vo.CommitResponse(true));

            AddCategoria vmodel = new AddCategoria
            {
                Id = Guid.NewGuid(),
                Nome = "Nome",
                Descricao = "Descrição"
            };

            _service.Add(vmodel);

            Assert.False(_notification.Object.HasErrorNotification());
        }
    }
}
