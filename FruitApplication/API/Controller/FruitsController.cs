
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Models;
using FruitApplication.BusinessLogic.Interfaces;
using FruitApplication.BusinessLogic.Models;

namespace FruitApplication.API.Controller
{
    [ApiController]
    [Route("")]
    [Produces("application/json")]
    public class FruitsController : ControllerBase
    {

        private readonly IBLFruit _bLFruit;

        public FruitsController(IBLFruit bLFruit)
        {
            _bLFruit = bLFruit;
        }
        // GET: api/Fruits
        [HttpGet]
        [Route("fruits")]
        public ActionResult<IEnumerable<FruitDTO>> FindAll()
        {
            var result = _bLFruit.FindAll();
            if (!result.Any())
            {

                var e = new ReturnError
                {
                    status = 404,
                    msg = "Fruit not found",
                    date = DateTime.Now
                };

                return Ok(e);

            }

            return Ok(result);
        }

        [HttpGet("fruits/{id}")]
        public ActionResult<FruitDTO> FindFruitById(long id)
        {
            var result = _bLFruit.FindById(id);

            if (result == null)
            {

                var e = new ReturnError
                {
                    status = 404,
                    msg = "Fruit not found",
                    date = DateTime.Now
                };

                return NotFound(e);

            }

            return Ok(result);
        }


        [HttpPost("fruits")]
        public ActionResult SaveFruit([FromBody] FruitDTO fruitDTO)
        {

            var badRequest = new ReturnError
            {
                status = 404,
                msg = "Fruit not found",
                date = DateTime.Now
            };

            if (!RequestValidation(fruitDTO)) return BadRequest(badRequest);

            _bLFruit.Save(fruitDTO);

            var uri = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}");

            return Created(uri, fruitDTO);
        }

        private bool RequestValidation(FruitDTO fruitDTO)
        {

            if (string.IsNullOrWhiteSpace(fruitDTO.Name)) return false;

            if (fruitDTO.Type.Id <= 0) return false;

            if (string.IsNullOrWhiteSpace(fruitDTO.Description)) return false;

            var descriptionLenth = fruitDTO.Description.Length;

            if (descriptionLenth > 25) return false;


            return true;

        }


        [HttpPut("fruits/{id}")]
        public ActionResult UpdateFruit(FruitDTO fruitDTO, long id)
        {
            _bLFruit.Update(id, fruitDTO);
            return NoContent();
        }


        [HttpDelete("fruits/{id}")]
        public ActionResult DeleteFruit(long id)
        {

            var result = _bLFruit.FindById(id);
            if (result.Id == 0)
            {

                var e = new ReturnError
                {
                    status = 404,
                    msg = "Fruit not found",
                    date = DateTime.Now
                };

                return NotFound();

            };

            _bLFruit.Delete(id);

            return NoContent();
        }
    }
}
