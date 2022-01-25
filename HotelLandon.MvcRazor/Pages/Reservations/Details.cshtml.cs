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
    public class DetailsModel : PageModel
    {
        private readonly HotelLandon.Data.HotelLandonContext _context;

        public DetailsModel(HotelLandon.Data.HotelLandonContext context)
        {
            _context = context;
        }

        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await _context.Reservations.FirstOrDefaultAsync(m => m.Id == id);

            if (Reservation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
