using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebApplication.Models.Pagination
{
    public class PaginationList<T>
    {
        public PaginationList(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
        public int TotalRecords { get; set; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public List<T> Result { get; set; }
        public int TotalPage => (int)Math.Ceiling(this.TotalRecords / (double)this.PageSize);
        public bool TempPagePrevious => this.PageNumber > 1;
        public bool TempPagePosterior => this.PageNumber < this.TotalPage;
        public int BackPageNumber => this.TempPagePosterior ? this.PageNumber + 1 : this.TotalPage;
        public int PreviousPageNumber => this.TempPagePrevious ? this.PageNumber - 1 : 1;

        public async Task<PaginationList<T>> Read(IQueryable<T> source)
        {
            this.TotalRecords = await source.CountAsync();
            this.Result = await source.Skip(PageSize * (PageNumber - 1))
                                         .Take(PageSize)
                                         .ToListAsync();

            return this;
        }

        public PaginationList<T> Read(List<T> source)
        {
            this.TotalRecords = source.Count();
            this.Result = source.Skip(PageSize * (PageNumber - 1))
                                   .Take(PageSize).ToList();                              

            return this;
        }
    }
}