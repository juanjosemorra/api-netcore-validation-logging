using api_netcore_validation_logging.DTOs;
using api_netcore_validation_logging.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_netcore_validation_logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        public readonly DBContextBeer dbContextBeer;
        private readonly ILogger<BeersController> _logger;

        public BeersController(DBContextBeer dBContextBeer, ILogger<BeersController> logger)
        {
            this.dbContextBeer = dBContextBeer;
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            _logger.LogInformation("Listado de cervezas");
            throw new ArgumentException(
              $"We don't offer a weather forecast for");
            return Ok(this.dbContextBeer.Beers);        
        }



        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            Beer oBeer = this.dbContextBeer.Beers.ToList().Find(p => p.beerId.Equals(id));
            if (oBeer == null)
            {
                return NotFound();
            }


            return Ok(oBeer);
        }

        [HttpPost]
        public IActionResult Agregar([FromBody] BeerInsertDTO beerDTO)
        {
            if (beerDTO == null)
            {
                return BadRequest();
            }


            Beer beer = new Beer()
            {
                beerId = (this.dbContextBeer.Beers.Max(p => p.beerId) + 1),
                name = beerDTO.name
            };

            this.dbContextBeer.Beers.Add(beer);
            this.dbContextBeer.SaveChanges();
        
            return Ok();       
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BeerUpdateDTO beerDTO)
        {
            if (beerDTO == null)
            {
                return BadRequest();
            }


            beerDTO.name = "123456789123";
            if (!TryValidateModel(beerDTO, nameof(BeerUpdateDTO)))
            {
                ModelState.AddModelError("descripcion", "La descripción no puede ser igual al nombre");
                return BadRequest(ModelState);
            }


            if (beerDTO.name.Equals(beerDTO.description))
            {
                ModelState.AddModelError("descripcion", "La descripción no puede ser igual al nombre");
                ModelState.AddModelError("descripcion1", "asdasdasd");
                return BadRequest(ModelState);
            }


            return Ok();
        }
    }
}
