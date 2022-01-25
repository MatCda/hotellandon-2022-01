using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelLandon.Data;
using HotelLandon.Models;

namespace HotelLandon.MvcRazor.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly HotelLandon.Data.HotelLandonContext _context;

        public IndexModel(HotelLandon.Data.HotelLandonContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; }

        public async Task OnGetAsync()
        {
            Reservation = await _context.Reservations.ToListAsync();
        }
    }
}
