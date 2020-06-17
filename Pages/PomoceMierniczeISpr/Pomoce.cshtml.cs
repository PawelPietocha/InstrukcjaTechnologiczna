using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrukcjaTechnologiczna.Core;
using InstrukcjaTechnologiczna.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstrukcjaTechnologiczna
{
    public class PomoceModel : PageModel
    {
        private readonly IObrabiarkiData obrabiarkiData;

        public IEnumerable<Pomoce> Pomoce { get; set; }
        public PomoceModel(IObrabiarkiData obrabiarkiData)
        {
            this.obrabiarkiData = obrabiarkiData;
        }
        public void OnGet()
        {
           Pomoce= obrabiarkiData.GetAllPomoce();
        }
    }
}