using HW_1.DataObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {

        private readonly ValuesHolder TempList;

        public TemperatureController(ValuesHolder holder)
        {
            TempList = holder;
        }

        [HttpGet]
        public List<TemperatureAndDate> Get()
        {
            return TempList.Data;
        }

        [HttpPost]
        public TemperatureAndDate Post([FromQuery] TemperatureAndDate NewRecord)
        {
            TempList.Data.Add(NewRecord);
            return TempList.Data.Last();
        }

        [HttpPut]
        public TemperatureAndDate Put(  [FromQuery] DateTime DateForChange,
                                        [FromQuery] float NewTemperature)
        {
            TemperatureAndDate temp = new TemperatureAndDate();

            foreach (var record in TempList.Data)
            {
                if (DateForChange == record.Date)
                {
                    record.Temperature = NewTemperature;

                    temp.Date = record.Date;
                    temp.Temperature = record.Temperature;
                }
            }
            return temp;
        }

        [HttpDelete]
        public List<TemperatureAndDate> Delete([FromQuery] DateTime DateForDelete)
        {
            List<TemperatureAndDate> _TempList = new List<TemperatureAndDate>();

            foreach (var record in TempList.Data)
            {
                if (record.Date != DateForDelete)
                {
                    _TempList.Add(record);
                }
            }

            TempList.Data = _TempList;
            return TempList.Data;
        }
    }
}
