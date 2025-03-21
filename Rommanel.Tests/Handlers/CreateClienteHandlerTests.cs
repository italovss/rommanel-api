using FluentAssertions;
using MediatR;
using Moq;
using Rommanel.Application.Commands;
using Rommanel.Application.Events;
using Rommanel.Application.Handlers;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;

namespace Rommanel.Tests.Handlers
{
    public class CreateClienteHandlerTests
    {
        [Fact]
        public async Task Handle_DeveCriarClienteEPublicarEvento()
        {
            // Arrange
            var mockRepo = new Mock<IClienteRepository>();
            var mockMediator = new Mock<IMediator>();

            var handler = new CreateClienteHandler(mockRepo.Object, mockMediator.Object);

            var command = new CreateClienteCommand
            {
                Nome = "João Teste",
                CPF_CNPJ = "12345678900",
                DataNascimento = new DateTime(1990, 1, 1),
                Telefone = "61999999999",
                Email = "joao@email.com",
                Endereco = new Endereco("70345000", "Rua X", "10", "Centro", "Brasília", "DF")
            };

            // Act
            var id = await handler.Handle(command, CancellationToken.None);

            // Assert
            id.Should().NotBeEmpty();
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Cliente>()), Times.Once);
            mockMediator.Verify(m => m.Publish(It.IsAny<ClienteCriadoEvent>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
