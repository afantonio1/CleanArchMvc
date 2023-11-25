using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    #nullable disable
    public sealed class Category : BaseEntity
    {
        #region Construtores
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name);
        }

        #endregion

        #region Propriedades

        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        #endregion

        #region Métodos
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name, too short, minimum 3 characters");
            Name = name;
        }

        #endregion
    }
}
