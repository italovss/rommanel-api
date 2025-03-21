using Microsoft.EntityFrameworkCore;
using Rommanel.Domain.Entities;
using Rommanel.Domain.Repositories;
using Rommanel.Infrastructure.Data;

namespace Rommanel.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetByIdAsync(Guid id) =>
            await _context.Clientes.FindAsync(id);

        public async Task<IEnumerable<Cliente>> GetAllAsync() =>
            await _context.Clientes.ToListAsync();

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cliente = await GetByIdAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
