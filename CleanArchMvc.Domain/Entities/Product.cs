using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    #nullable disable
    public sealed class Product : BaseEntity
    {

        #region Construtores

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        #endregion

        #region Propriedades
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        //Propriedades de navegação
        public int CatetoryId { get; set; }
        public Category Category { get; set; }

        #endregion 

        #region Métodos 
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
            DomainExceptionValidation.When(name.Length < 5, "Invalid Description, too short, minimum 5 characters");

            DomainExceptionValidation.When(price < 0, "Invalid price value");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image.Length > 250, "Invalid image name, maximum 250 characters");

            Name = name;
            Price = price;
            Stock = stock;
            Image = image;
            Description = description;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CatetoryId = categoryId;
        }

        #endregion

    }
}
