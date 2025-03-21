using FluentAssertions;
using Moq;
using Rommanel.Application.Commands;
using Rommanel.Application.Handlers;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Tests.Handlers
{
    public class DeleteClienteHandlerTests
    {
        [Fact]
        public async Task Handle_DeveRemoverCliente_QuandoIdExiste()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var cliente = new Cliente("Carlos Santos", "98765432100", new DateTime(1988, 7, 22),
                "61955555555", "carlos@email.com",
                new Endereco("70345000", "Rua W", "100", "Centro", "Brasília", "DF"));

            var clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(repo => repo.GetByIdAsync(clienteId)).ReturnsAsync(cliente);
            clienteRepositoryMock.Setup(repo => repo.DeleteAsync(clienteId)).Returns(Task.CompletedTask);

            var handler = new DeleteClienteHandler(clienteRepositoryMock.Object);
            var command = new DeleteClienteCommand(clienteId);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            clienteRepositoryMock.Verify(repo => repo.DeleteAsync(clienteId), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveLancarExcecao_QuandoClienteNaoExiste()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(repo => repo.GetByIdAsync(clienteId)).ReturnsAsync((Cliente)null);

            var handler = new DeleteClienteHandler(clienteRepositoryMock.Object);
            var command = new DeleteClienteCommand(clienteId);

            // Act & Assert
            await FluentActions.Invoking(() => handler.Handle(command, CancellationToken.None))
                .Should().ThrowAsync<KeyNotFoundException>()
                .WithMessage("Cliente não encontrado");
        }
    }
}
