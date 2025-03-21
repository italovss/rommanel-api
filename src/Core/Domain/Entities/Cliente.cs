namespace Rommanel.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF_CNPJ { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente(string nome, string cpfCnpj, DateTime dataNascimento, string telefone, string email, Endereco endereco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF_CNPJ = cpfCnpj;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }
    }
}
