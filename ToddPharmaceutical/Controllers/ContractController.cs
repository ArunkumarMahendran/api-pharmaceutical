using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmaceutical.BLL.IContractDetails;
using System.Threading.Tasks;
using MODEL = Pharmaceutical.Common.Models;

namespace ToddPharmaceutical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ContractController : ControllerBase
    {
        private readonly IContractDetail _contractDetail;
        public ContractController(IContractDetail contractDetail)
        {
            _contractDetail = contractDetail;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var contractDetails = _contractDetail.GetContractDetails();
                if (contractDetails == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return Ok(contractDetails);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Interal Server Error");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MODEL.ContractDetail contractDetail)
        {
            try
            {
                var contractDetails = _contractDetail.CreateContractDetails(contractDetail);
                return Ok(contractDetails);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Interal Server Error");
            }

        }


        [HttpPut]

        public async Task<IActionResult> Put([FromBody] MODEL.ContractDetail contractDetail)
        {
            try
            {

                var contractDetails = _contractDetail.UpdateContractDetail(contractDetail);
                return Ok(contractDetails);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Interal Server Error");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var contractDetails = _contractDetail.DeleteContractDetail(id);
                return Ok(contractDetails);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Interal Server Error");
            }
        }
    }
}
