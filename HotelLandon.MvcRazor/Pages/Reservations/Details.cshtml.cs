using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelLandon.Data;
using HotelLandon.Models;
using HotelLandon.Repository;

namespace HotelLandon.MvcRazor.Pages.Reservations
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositoryBase<Reservation> repository;

        public DetailsModel(IRepositoryBase<Reservation> repository)
        {
            this.repository = repository;
        }

        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Reservation = await _context.Reservations.FirstOrDefaultAsync(m => m.Id == id);
            Reservation = await repository.GetAsync(id.Value);

            if (Reservation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
