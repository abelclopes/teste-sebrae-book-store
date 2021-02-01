using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Domain;
using System.Linq;

namespace Domain.Interface
{
    public interface IContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<RentBook> RentBooks { get; set; }
        
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
        void Dispose();
    }
    
}