using Moq;
using Rommanel.Application.Commands;
using Rommanel.Application.Handlers;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Tests.Handlers
{
    public class UpdateClienteHandlerTests
    {
        [Fact]
        public async Task Handle_DeveAtualizarCliente_ComDadosValidos()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var clienteExistente = new Cliente("Ana Pereira", "45678912300", new DateTime(1992, 3, 15), "61977777777", "ana@email.com",
                new Endereco("70345000", "Rua Z", "30", "Bairro Norte", "Brasília", "DF"));

            var clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(repo => repo.GetByIdAsync(clienteId)).ReturnsAsync(clienteExistente);
            clienteRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            var handler = new UpdateClienteHandler(clienteRepositoryMock.Object);

            var command = new UpdateClienteCommand
            {
                Id = clienteId,
                Nome = "Ana Pereira Atualizada",
                CPF_CNPJ = "45678912300",
                DataNascimento = new DateTime(1992, 3, 15),
                Telefone = "61977777777",
                Email = "ana.nova@email.com",
                Endereco = new Endereco("70345000", "Rua Z", "30", "Bairro Norte", "Brasília", "DF")
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            clienteRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Cliente>()), Times.Once);
        }
    }
}
