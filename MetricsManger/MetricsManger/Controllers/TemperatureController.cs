using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ValuesHolder _holder;

        public TemperatureController(ValuesHolder holder)
        {
            _holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime data, [FromQuery] int temperature)
        {
            _holder.Values.Add(new TempPoint(data, temperature));
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime fromData, [FromQuery] DateTime toData)
        {
            return Ok(_holder.Values.Where(w => w.DataTemp >= fromData && w.DataTemp <= toData).ToList());
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime dataToUpdate, [FromQuery] int newTemperature)
        {
            foreach(TempPoint point in _holder.Values)
            {
                if (point.DataTemp == dataToUpdate)
                    point.Temp = newTemperature;
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime fromData, [FromQuery] DateTime toData)
        {
            _holder.Values = _holder.Values.Where(w => w.DataTemp < fromData || w.DataTemp > toData).ToList();
            return Ok();
        }
    }
}
