using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Interface;
using Microsoft.Extensions.Caching.Memory;
using Infraestructure;

namespace WebApplication.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IContext _context;
        public BaseController(IContext context)
        {
            _context = context;
        }
    }
}