using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vig.Controllers.Resources;
using Vig.Models;
using Vig.Persistance;

namespace Vig.Controllers {
    public class MakesController : Controller {
        private readonly VigaDbContext context;
        private readonly IMapper mapper;
        public MakesController (VigaDbContext context, IMapper mapper) {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet ("/api/Makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes () {
            // return await context.Makes.Include(m => m.Models).ToListAsync();
            var makes = await context.Makes.Include (m => m.Models).ToListAsync ();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

    }
}