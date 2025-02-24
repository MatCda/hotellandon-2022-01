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
    public class DetailsModel : PageModel
    {
        private readonly IRepositoryBase<Room> repository;

        public DetailsModel(IRepositoryBase<Room> repository)
        {
            this.repository = repository;
        }

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
    }
}
