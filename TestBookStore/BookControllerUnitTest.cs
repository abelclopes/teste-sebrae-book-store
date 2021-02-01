using Moq;
using System;
using Xunit;
using Domain.Interface;
using Domain;
using WebApplication.Models.Pagination;
using WebApplication.Controllers;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TestBookStore.Validation;

namespace TestBookStore
{
    public class BookControllerUnitTest
    {

        [Fact]
        public void Book_Controller_Create_AuthorIsValid()
        {
            // Arrange                  
            Mock<IValidadtionCategory> mock = new Mock<IValidadtionCategory>();
            var model = new Category() { Id = Guid.NewGuid(), Name = "teste" };

            mock.Setup(m => m.IsValidName(model)).Returns("válido");
            var verif = new ValidadtionCategory();

            // act
            var resultado = verif.IsValidName(model);
            var resultadoEsperado = mock.Object.IsValidName(model);

            // assert
            Assert.Equal(resultado, resultadoEsperado);

        }

        [Fact]
        public void Book_Controller_Create_AuthorIsInValid()
        {
            // Arrange                  
             Mock<IValidadtionCategory> mock = new Mock<IValidadtionCategory>();
            var model = new Category() { Id = Guid.NewGuid(), Name = "" };

            mock.Setup(m => m.IsValidName(model)).Returns("inválido");
            var verif = new ValidadtionCategory();

            // act
            var resultado = verif.IsValidName(model);
            var resultadoEsperado = mock.Object.IsValidName(model);

            // assert
            Assert.Equal(resultado, resultadoEsperado);

        }
    }
}
