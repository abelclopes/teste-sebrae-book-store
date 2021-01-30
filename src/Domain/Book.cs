using System;
using System.Collections.Generic;
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

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public Guid CategoryId { get; set; }
        public string PublishingCompany { get; set; }
        public Boolean Rented { get; set; }
        // public bit[] image { get; set; }

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