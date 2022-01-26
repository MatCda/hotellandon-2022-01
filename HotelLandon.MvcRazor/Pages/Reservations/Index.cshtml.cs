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
    public class IndexModel : PageModel
    {
        private readonly IRepositoryBase<Reservation> repository;

        public IndexModel(IRepositoryBase<Reservation> repository)
        {
            this.repository = repository;
        }

        public IList<Reservation> Reservations { get;set; }

        public async Task OnGetAsync()
        {
            Reservations = await repository.GetAllAsync();
        }
    }
}
