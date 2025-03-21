using FluentAssertions;
using Moq;
using Rommanel.Application.Handlers;
using Rommanel.Application.Queries;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Tests.Handlers
{
    public class GetClientesHandlerTests
    {
        [Fact]
        public async Task Handle_DeveRetornarListaDeClientes_QuandoExistemClientes()
        {
            // Arrange
            var clientes = new List<Cliente>
            {
                new Cliente("Carlos Santos", "12345678900", new DateTime(1990, 5, 10), "61955555555", "carlos@email.com",
                    new Endereco("70345000", "Rua A", "100", "Centro", "Brasília", "DF")),
                new Cliente("Ana Pereira", "98765432100", new DateTime(1985, 3, 22), "61977777777", "ana@email.com",
                    new Endereco("70345000", "Rua B", "200", "Sul", "Brasília", "DF"))
            };

            var clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(clientes);

            var handler = new GetClientesHandler(clienteRepositoryMock.Object);
            var query = new GetClientesQuery(1, 10); 

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().Contain(c => c.Nome == "Carlos Santos");
            result.Should().Contain(c => c.Nome == "Ana Pereira");
        }

        [Fact]
        public async Task Handle_DeveRetornarListaVazia_QuandoNaoExistemClientes()
        {
            // Arrange
            var clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Cliente>());

            var handler = new GetClientesHandler(clienteRepositoryMock.Object);
            var query = new GetClientesQuery(1, 10);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEmpty();
        }
    }
}
