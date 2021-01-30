using System;
using System.ComponentModel;
using System.Reflection;

namespace Domain.Paginator 
{
    public class LinkInfo
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }   
}