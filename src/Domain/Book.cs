using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class Book : EntidadeBase
    {
        public Book()
        {
        }
        public Book(string title, string description, string author, string year, Guid categoryId, string publishingCompany)
        {
            Title = title;
            Description = description;
            Author = author;
            Year = year;
            CategoryId = categoryId;
            PublishingCompany = publishingCompany;
        }
        public Book(Guid id, string title, string description, string author, string year, Guid categoryId, string publishingCompany)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            Year = year;
            CategoryId = categoryId;
            PublishingCompany = publishingCompany;
        }

        [Required(ErrorMessage = "Titulo � Obrigat�rio")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Descri��o � Obrigat�rio")]
        [Display(Name = "Descri��o")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Autor � Obrigat�rio")]
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Ano � Obrigat�rio")]
        [Display(Name = "Ano de publica��o")]
        public string Year { get; set; }
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Categoria � Obrigat�rio")]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Required(ErrorMessage = "Editora � Obrigat�rio")]
        [Display(Name = "Editora")]
        public string PublishingCompany { get; set; }
        [Display(Name = "Alugado?")]
        public Boolean Rented { get; set; }
        public byte[] Image { get; set; }

        public void update(Book model)
        {
            Title = model.Title;
            Description = model.Description;
            Author = model.Author;
            Year = model.Year;
            CategoryId = model.CategoryId;
            PublishingCompany = model.PublishingCompany;
        }
        public void update(string title)
        {
            Title = title;
        }

        public void UpdateByBook(Book model)
        {
            Id = model.Id;
            Title = model.Title;
            Description = model.Description;
            Author = model.Author;
            Year = model.Year;
            CategoryId = model.CategoryId;
            PublishingCompany = model.PublishingCompany;
            Excluded = model.Excluded;
            // return this;
        }
        public void Deleted()
        {
            this.Delete();
        }
        public Book Rent()
        {
            Rented = true;
            return this;
        }
    }
}