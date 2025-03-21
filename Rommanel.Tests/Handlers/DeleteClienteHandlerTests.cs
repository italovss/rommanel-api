using MediatR;
using Moq;
using Rommanel.Application.Commands;
using Rommanel.Application.Events;
using Rommanel.Application.Handlers;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Tests.Handlers
{
    public class DeleteClienteHandlerTests
    {
        [Fact]
        public async Task Handle_DeveRemoverClienteEPublicarEvento()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var cliente = new Cliente("Carlos", "12345678900", DateTime.Today.AddYears(-30), "61999999999", "carlos@email.com",
                new Endereco("70345000", "Rua 1", "100", "Centro", "Brasília", "DF"));

            var mockRepo = new Mock<IClienteRepository>();
            var mockMediator = new Mock<IMediator>();

            mockRepo.Setup(r => r.GetByIdAsync(clienteId)).ReturnsAsync(cliente);
            mockRepo.Setup(r => r.DeleteAsync(clienteId)).Returns(Task.CompletedTask);

            var handler = new DeleteClienteHandler(mockRepo.Object, mockMediator.Object);

            // Act
            await handler.Handle(new DeleteClienteCommand(clienteId), CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.DeleteAsync(clienteId), Times.Once);
            mockMediator.Verify(m => m.Publish(It.IsAny<ClienteRemovidoEvent>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
