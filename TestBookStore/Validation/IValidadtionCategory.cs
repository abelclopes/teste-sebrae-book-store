using System;
using Domain;
namespace TestBookStore.Validation
{
    public interface IValidadtionCategory
    {
        string IsValidName(Category model);
        string IsValidDescription(Category model);
        string IsDeleted(Category model);
    }
}