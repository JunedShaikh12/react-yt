using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;
using ModelBinding.Repository.Services;
using System.Xml.Linq;

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class PController : ControllerBase
    {

        private readonly IPService _pservice;

        public PController(IPService pservice)
        {
            _pservice = pservice;
        }

        [HttpGet("details")]
        public IActionResult GetProductById([FromQuery] int id)
        {
            //var idValue = HttpContext.Request.RouteValues["id"].ToString();

            //if (!int.TryParse(idValue, out int productId))
            //    return BadRequest("Invalid Product ID format.");

            var product = _pservice.GetById(id);
            return Ok(product);
        }

        [HttpGet("match")]
        public IActionResult Search([FromHeader] string Name)
        {
            var searchResult = _pservice.Searchh(Name);
            if(searchResult == null)
            {
                return null;
            }
            return Ok(searchResult);
        }

        [HttpPost("Post")]
        public IActionResult Create([FromBody] PModel product)
        {
            var newPrd = _pservice.AddPrd(product);
            return Ok(newPrd);
        }

        [HttpGet("custom-binding")]
        public IActionResult CustomObjectBinding([FromQuery] string complexData)
        {
            var parts = complexData?.Split(',');
            if (parts?.Length == 3)
            {
                var newObject = new CustomObject
                {
                    Name = parts[0],
                    Age = int.Parse(parts[1]),
                    Location = parts[2]
                };
                return Ok(newObject);
            }
            return BadRequest("INVALID CUSTOM FORMAT");
        }




}
}
