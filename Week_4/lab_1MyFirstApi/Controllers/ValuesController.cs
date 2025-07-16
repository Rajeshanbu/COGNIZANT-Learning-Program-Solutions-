using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<string> values = new() { "value1", "value2" };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string newValue)
        {
            values.Add(newValue);
            return Ok(values);
        }

        [HttpPut("{index}")]
        public IActionResult Put(int index, [FromBody] string updatedValue)
        {
            if (index < 0 || index >= values.Count)
                return BadRequest("Invalid index");

            values[index] = updatedValue;
            return Ok(values);
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= values.Count)
                return BadRequest("Invalid index");

            values.RemoveAt(index);
            return Ok(values);
        }
    }
}
