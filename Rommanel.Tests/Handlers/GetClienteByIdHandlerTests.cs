using FluentAssertions;
using Moq;
using Rommanel.Application.Handlers;
using Rommanel.Application.Queries;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Tests.Handlers
{
    public class GetClienteByIdHandlerTests
    {
        [Fact]
        public async Task Handle_DeveRetornarCliente_QuandoIdExiste()
        {
            // Arrange
            var clienteId = Guid.NewGuid();
            var cliente = new Cliente("Maria Souza", "98765432100", new DateTime(1985, 5, 10), "61988888888", "maria@email.com",
                new Endereco("70345000", "Rua Y", "20", "Centro", "Brasília", "DF"));

            var clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(repo => repo.GetByIdAsync(clienteId)).ReturnsAsync(cliente);

            var handler = new GetClienteByIdHandler(clienteRepositoryMock.Object);
            var query = new GetClienteByIdQuery(clienteId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Nome.Should().Be("Maria Souza");
        }
    }
}
