using MediatR;
using Moq;
using Rommanel.Application.Commands;
using Rommanel.Application.Events;
using Rommanel.Application.Handlers;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Tests.Handlers
{
    public class UpdateClienteHandlerTests
    {
        [Fact]
        public async Task Handle_DeveAtualizarClienteEPublicarEvento()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var clienteAntigo = new Cliente("Antigo", "11111111111", new DateTime(1995, 1, 1), "6111111111", "antigo@email.com",
                new Endereco("00000000", "Velha", "1", "Bairro", "Cidade", "DF"));

            var mockRepo = new Mock<IClienteRepository>();
            var mockMediator = new Mock<IMediator>();

            mockRepo.Setup(r => r.GetByIdAsync(clienteId)).ReturnsAsync(clienteAntigo);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            var handler = new UpdateClienteHandler(mockRepo.Object, mockMediator.Object);

            var command = new UpdateClienteCommand
            {
                Id = clienteId,
                Nome = "Atualizado",
                CPF_CNPJ = "22222222222",
                DataNascimento = new DateTime(1990, 5, 10),
                Telefone = "61999999999",
                Email = "novo@email.com",
                Endereco = new Endereco("70345000", "Rua Nova", "20", "Centro", "Brasília", "DF")
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.UpdateAsync(It.IsAny<Cliente>()), Times.Once);
            mockMediator.Verify(m => m.Publish(It.IsAny<ClienteAtualizadoEvent>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
