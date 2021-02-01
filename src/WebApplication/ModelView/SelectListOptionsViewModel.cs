using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace WebApplication.ModelView
{
    public class SelectListOptionsViewModel
    {
        public object Key { get; private set; }
        public string Value { get; private set; }

        public static List<SelectListOptionsViewModel> GetList(){
            return new List<SelectListOptionsViewModel> {
                new SelectListOptionsViewModel{Key = null, Value = "Todos"},
                new SelectListOptionsViewModel{Key = true, Value= "Alugado"}, 
                new SelectListOptionsViewModel{Key = false, Value= "Disponivel"}
            };
        }

    }
}