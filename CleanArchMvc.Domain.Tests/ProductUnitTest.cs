using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create product with valid parameters")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product 1", "Teste", 5, 99, "imagem 1");
            action.Should()
                .NotThrow<DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Create product - Invalid Id")]
        public void CreateProduct_NegativeId_Value_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product 1", "Teste", 5, 99, "imagem 1");
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("Invalid Id value");

        }

        [Fact(DisplayName = "product name too short")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Teste", 5, 99, "imagem 1");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Long Image name")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product", "Teste", 5, 99, "asdssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss1");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image name, maximum 250 characters");

        }

        [Fact(DisplayName = "Null image name")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product", "Teste", 5, 99, null);
            action.Should()
                .NotThrow<DomainExceptionValidation>();                
        }

        [Fact(DisplayName = "Null image name NullReference")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product", "Teste", 5, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Empty image name")]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product", "Teste", 5, 99, "");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Invalid stock value")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product", "Teste", 5, value, "");
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("Invalid stock value");

        }

        [Theory(DisplayName = "Invalid price value")]
        [InlineData(-5)]
        public void CreateProduct_InvalidPriceValue_DomainExceptionNegativeValue(decimal value)
        {
            Action action = () => new Product(1, "Product", "Teste", value, 99, "");
            action.Should().Throw<DomainExceptionValidation>()
                  .WithMessage("Invalid price value");

        }

    }
}
