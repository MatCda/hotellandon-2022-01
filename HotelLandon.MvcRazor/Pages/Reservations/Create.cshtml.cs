using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelLandon.Data;
using HotelLandon.Models;
using HotelLandon.Repository;

namespace HotelLandon.MvcRazor.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly IRepositoryBase<Reservation> repository;

        public CreateModel(IRepositoryBase<Reservation> repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Reservations.Add(Reservation);
            //await _context.SaveChangesAsync();
            await repository.AddAsync(Reservation);

            return RedirectToPage("./Index");
        }
    }
}
