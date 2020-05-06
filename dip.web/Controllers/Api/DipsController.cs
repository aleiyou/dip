using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dip.web.Data;
using dip.web.Data.Entities;
using dip.web.Helpers;

namespace dip.web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DipsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public DipsController(DataContext context,
            IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }



        // GET: api/Dips/5
        [HttpGet("{plaque}")]
        public async Task<IActionResult> GetDipEntity([FromRoute] string plaque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DipEntity DipEntity = await _context.Dips
                 .Include(t => t.User) // Driver
                 .Include(t => t.Trips)
                 .ThenInclude(t => t.TripDetails)
                 .Include(t => t.Trips)
                 .ThenInclude(t => t.User) // Passanger
                 .FirstOrDefaultAsync(t => t.Plaque == plaque);

            if (DipEntity == null)
            {
                return NotFound();
            }

            return Ok(_converterHelper.ToDipResponse(DipEntity));
        }
    }
}

       
