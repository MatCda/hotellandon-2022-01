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

namespace HotelLandon.MvcRazor.Pages.Rooms
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositoryBase<Room> repository;

        public DeleteModel(IRepositoryBase<Room> repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await repository.GetAsync(id.Value);

            if (Room == null)
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

            //Room = await _context.Rooms.FindAsync(id);

            //if (Room != null)
            //{
            //    _context.Rooms.Remove(Room);
            //    await _context.SaveChangesAsync();
            //}
            await repository.DeleteAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
