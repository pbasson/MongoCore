using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoCore.Core.Interfaces.InterfaceServices;

namespace MongoCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoController : ControllerBase
    {
        private readonly IMongoService mongoService; 

        public MongoController()
        {
            
        }

        [HttpGet]
        [Route("GetAllRecord")]
        public async Task<ActionResult> GetAllRecord()
        {   
            var model = await mongoService.GetAllRecords(); 
            if(model != null && model.Any() )
            {
                return Ok( model ); 
            }   
            return BadRequest();
        }
    }
}
