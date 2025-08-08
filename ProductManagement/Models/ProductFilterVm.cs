using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using static System.Collections.Specialized.BitVector32;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System;

namespace ProductManagement.Models
{

    public class ProductFilterVm
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        [DataType(DataType.Date)] public DateTime? FromDate { get; set; }
        [DataType(DataType.Date)] public DateTime? ToDate { get; set; }
        public int? ServiceProviderId { get; set; }
        public IEnumerable<SelectListItem> Providers { get; set; } = new List<SelectListItem>();
    }

}
