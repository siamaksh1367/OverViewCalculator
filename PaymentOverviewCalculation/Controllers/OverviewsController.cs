using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OverViewCalculator;
using OverViewCalculator.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentOverviewCalculation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverviewsController : ControllerBase
    {
        private readonly AbstractCalculation<OverviewQueryDto, OverviewResultDto> _cal;

        public OverviewsController(AbstractCalculation<OverviewQueryDto, OverviewResultDto> cal)
        {
            _cal = cal;
        }

        [HttpGet]
        public ActionResult<OverviewResultDto> Get([FromQuery] OverviewQueryDto query)
        {

            return Ok(_cal.CalculateOverView(query)) ;
        }
    }
}
