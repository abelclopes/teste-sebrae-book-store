using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBookStore.Validation
{
    public class ValidadtionBook : IValidadtionBook
    {
        public string IsDeleted(Book model)
        {
            return model.Excluded? "deletado": "";
        }

        public string IsRented(Book model)
        {
            return model.Rented? "Alugado": "Disponivel";
        }

        public string IsValidAuthor(Book model)
        {
            return string.IsNullOrEmpty(model.Author) ? "inválido": "válido";
        }

        public string IsValidCategoryId(Book model)
        {
            return string.IsNullOrEmpty(model.CategoryId.ToString()) ? "inválido": "válido";
        }

        public string IsValidDescription(Book model)
        {
            return string.IsNullOrEmpty(model.Description) ? "inválido": "válido";
        }

        public string IsValidPublishingCompany(Book model)
        {
            return string.IsNullOrEmpty(model.PublishingCompany) ? "inválido": "válido";
        }

        public string IsValidTitle(Book model)
        {
            return string.IsNullOrEmpty(model.Title) ? "inválido": "válido";
        }

        public string IsValidYear(Book model)
        {
            return string.IsNullOrEmpty(model.Year) ? "inválido": "válido";
        }
    }
}
