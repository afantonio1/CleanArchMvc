using Xunit;
using FluentAssertions;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create category with valid parameters")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Teste 1");
            action.Should()
                .NotThrow<DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Negative ID value")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(-1, "Teste 1");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value");

        }

        [Fact(DisplayName = "Name too short")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Te");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, too short, minimum 3 characters");

        }

        [Fact(DisplayName = "Empty name")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name is required");

        }

        [Fact(DisplayName = "Null name")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>();
        }

    }
}