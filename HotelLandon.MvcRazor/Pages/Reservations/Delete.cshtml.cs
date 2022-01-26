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
    public class DeleteModel : PageModel
    {
        private readonly IRepositoryBase<Reservation> repository;

        public DeleteModel(IRepositoryBase<Reservation> repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await repository.GetAsync(id.Value);

            if (Reservation == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Reservation = await _context.Reservations.FindAsync(id);

            //if (Reservation != null)
            //{
            //    _context.Reservations.Remove(Reservation);
            //    await _context.SaveChangesAsync();
            //}
            await repository.DeleteAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
