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
    public class TempController : ControllerBase
    {
        private readonly ValuesHolder _holder;

        public TempController(ValuesHolder holder)
        {
            this._holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime inputData, [FromQuery] int inputTemp)
        {
            _holder.Values.Add(new TempPoint(inputData,inputTemp));
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime fromData, [FromQuery] DateTime toData)
        {
            return Ok(_holder.Values.Where(w => w.DataTemp >= fromData && w.DataTemp <= toData).ToList());
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime dataToUpdate, [FromQuery] int newTemp)
        {
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                if (_holder.Values[i].DataTemp == dataToUpdate)
                    _holder.Values[i].Temp = newTemp;
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
