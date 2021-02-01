using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBookStore.Validation
{
    public class ValidadtionCategory : IValidadtionCategory
    {
        public string IsValidName(Category model)
        {
            return string.IsNullOrEmpty(model.Name) ? "inválido" : "válido";
        }

        public string IsValidDescription(Category model)
        {
            return string.IsNullOrEmpty(model.Description) ? "inválido" : "válido";

        }
        public string IsDeleted(Category model)
        {
            return model.Excluded? "deletado": "";
        }
     }
}
