using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Descrição é Obrigatório")]
        [Display(Name = "Descrição")]
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