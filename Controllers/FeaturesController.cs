using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vig.Controllers.Resources;
using Vig.Models;
using Vig.Persistance;

namespace Vig.Controllers {
    public class FeaturesController : Controller {
        private readonly VigaDbContext context;
        private readonly IMapper mapper;
        public FeaturesController (VigaDbContext context, IMapper mapper) {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet ("/api/Features")]
        public async Task<IEnumerable<FeatureResource>> GetFetures()
        {
            var features = await context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}