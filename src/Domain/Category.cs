using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class Category : EntidadeBase
    {
        public Category()
        {
        }
        public Category(string name, string descricao)
        {
            Name = name;
            Description = descricao;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public void Atualizar(Category model)
        {
            Name = model.Name;
            Description = model.Description;
        }
        public void Atualizar(string name)
        {
            Name = name;
        }
    }
}