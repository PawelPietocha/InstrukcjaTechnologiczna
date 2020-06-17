using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrukcjaTechnologiczna.Core;
using InstrukcjaTechnologiczna.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstrukcjaTechnologiczna.Pages.FObrabiarki
{
    public class ObrabiarkiViewModel : PageModel
    {
        public IEnumerable<Obrabiarka> Obrabiarki { get; set; }
        public IEnumerable<SelectListItem> Rodzaje { get; set; }
        private readonly IObrabiarkiData obrabiarkiData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty(SupportsGet = true)]
        public string SearchByName { get; set; }
        [BindProperty(SupportsGet = true)]
        public RodzajObrabiarki SearchByType { get; set; }

        public ObrabiarkiViewModel(IObrabiarkiData obrabiarkiData, IHtmlHelper htmlHelper)
        {
            this.obrabiarkiData = obrabiarkiData;
            this.htmlHelper = htmlHelper;
        }
        public void OnGet()
        {
            Rodzaje = htmlHelper.GetEnumSelectList<RodzajObrabiarki>();
            
            if (SearchByName == null && SearchByType == RodzajObrabiarki.Wszystkie)
            {
                Obrabiarki = obrabiarkiData.GetAll();
            }
            else if (SearchByName == null && SearchByType != RodzajObrabiarki.Wszystkie)
            {
                Obrabiarki = obrabiarkiData.GetByType(SearchByType);
            }
            else
            {
                Obrabiarki = obrabiarkiData.GetByName(SearchByName);
            }
            
                
            
        }
    }
}