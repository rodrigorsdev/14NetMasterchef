using Masterchef.Application.Receita.Interface;
using Masterchef.Application.Receita.Service;
using Masterchef.Application.Receita.ViewModel;
using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Masterchef.Core.Data.Interface;
using Masterchef.Domain.Receita.Interface;
using Moq;
using System;
using Xunit;

namespace Masterchef.Test
{
    public class ReceitaTest
    {
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<INotificationHandler<Notification>> _notification;
        private readonly Mock<IReceitaRepository> _repository;

        private readonly IReceitaService _service;

        public ReceitaTest()
        {
            _uow = new Mock<IUnitOfWork>();
            _notification = new Mock<INotificationHandler<Notification>>();
            _repository = new Mock<IReceitaRepository>();

            _service = new ReceitaService(
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

            AddReceita vmodel = new AddReceita
            {
                ReceitaId = Guid.NewGuid(),
                CategoriaId = Guid.NewGuid(),
                Descricao = "Descrição",
                ModoPreparo = "Modo preparo",
                Tags = "tag1, tag2",
                Titulo = "Titulo"
            };

            _service.Add(vmodel);

            Assert.False(_notification.Object.HasErrorNotification());
        }

        [Fact]
        public void AddSuccessTest()
        {
            _uow.Setup(a => a.Commit())
                .Returns(new Core.Data.Vo.CommitResponse(true));

            AddReceita vmodel = new AddReceita
            {
                ReceitaId = Guid.NewGuid(),
                Descricao = "Descrição",
                ModoPreparo = "Modo preparo",
                Tags = "tag1, tag2",
                Titulo = "Titulo"
            };

            _service.Add(vmodel);

            Assert.False(_notification.Object.HasErrorNotification());
        }
    }
}
