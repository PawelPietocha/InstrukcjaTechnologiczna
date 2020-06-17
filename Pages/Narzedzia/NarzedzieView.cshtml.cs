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
    public class NarzedzieViewModel : PageModel
    {
        private readonly IObrabiarkiData obrabiarkiData;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<Narzedzie> Narzedzia { get; set; }
        public IEnumerable<SelectListItem> Rodzaje { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchByName { get; set; }
        [BindProperty(SupportsGet = true)]
        public RodzajNarzedzia SearchByType { get; set; }
        public NarzedzieViewModel(IObrabiarkiData obrabiarkiData, IHtmlHelper htmlHelper)
        {
            this.obrabiarkiData = obrabiarkiData;
            this.htmlHelper = htmlHelper;
        }
        public void OnGet()
        {
            Rodzaje = htmlHelper.GetEnumSelectList<RodzajNarzedzia>();

            if (SearchByName == null && SearchByType == RodzajNarzedzia.Wszystkie)
            {
                Narzedzia = obrabiarkiData.GetAllNarzedzies();
            }
            else if (SearchByName == null && SearchByType != RodzajNarzedzia.Wszystkie)
            {
                Narzedzia = obrabiarkiData.GetNardzedzieByType(SearchByType);
            }
            else
            {
                Narzedzia = obrabiarkiData.GetNarzedzieByName(SearchByName);
            }
        }
    }
}