using System;
using Domain;

namespace TestBookStore.Validation
{
    public interface IValidadtionBook
    {
        string IsValidTitle(Book model);
        string IsValidDescription(Book model);
        string IsRented(Book model);
        string IsDeleted(Book model);
        string IsValidAuthor(Book model);
        string IsValidPublishingCompany(Book model);
        string IsValidYear(Book model);
        string IsValidCategoryId(Book model);
        

    }
}