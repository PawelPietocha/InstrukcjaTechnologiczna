using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrukcjaTechnologiczna.Core;
using InstrukcjaTechnologiczna.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstrukcjaTechnologiczna
{
    public class UchwytViewModel : PageModel
    {
        private readonly IObrabiarkiData obrabiarkiData;

        public IEnumerable<Uchwyt> Uchwyty { get; set; }
        public IEnumerable<SelectListItem> Rodzaje { get; set; }
        private readonly IHtmlHelper htmlHelper;
        [BindProperty(SupportsGet = true)]
        public RodzajUchwytu SearchByType { get; set; }
        public UchwytViewModel(IObrabiarkiData obrabiarkiData, IHtmlHelper htmlHelper)
        {
            this.obrabiarkiData = obrabiarkiData;
            this.htmlHelper = htmlHelper;
        }
        public void OnGet()
        {
            Rodzaje = htmlHelper.GetEnumSelectList<RodzajUchwytu>();
            if (SearchByType == RodzajUchwytu.Wszystkie)
            {
                Uchwyty = obrabiarkiData.GetAllUchwyts();
            }
           
            else
            {
                Uchwyty = obrabiarkiData.GetUchwytByType(SearchByType);
            }
        }
    }
}