using FluentAssertions;
using Moq;
using Rommanel.Application.Commands;
using Rommanel.Application.Handlers;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Tests.Handlers
{
    public class CreateClienteHandlerTests
    {
        [Fact]
        public async Task Handle_DeveCriarClienteERetornarId()
        {
            // Arrange
            var clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Cliente>()))
                .Returns(Task.CompletedTask);

            var handler = new CreateClienteHandler(clienteRepositoryMock.Object);

            var command = new CreateClienteCommand
            {
                Nome = "João Silva",
                CPF_CNPJ = "12345678900",
                DataNascimento = new DateTime(1990, 1, 1),
                Telefone = "61999999999",
                Email = "joao@email.com",
                Endereco = new Endereco("70345000", "Rua X", "10", "Centro", "Brasília", "DF")
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeEmpty();
            clienteRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Cliente>()), Times.Once);
        }
    }
}
