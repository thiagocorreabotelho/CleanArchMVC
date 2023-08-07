using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Base
    {
        #region Propriedade(s)

        public string Name { get; private set; }

        // Propriedades de navegação
        public ICollection<Product> Product { get; set; }

        #endregion Propriedade(s)

        #region Construtor(es)

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }

        #endregion Construtor(es)

        #region Metodos

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        #endregion Metodos

        #region Validações

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 caracters");

            Name = name;
        }

        #endregion Validações
    }
}