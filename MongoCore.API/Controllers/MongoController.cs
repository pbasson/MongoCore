using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoCore.Core.DTOs;
using MongoCore.Core.Interfaces.InterfaceServices;

namespace MongoCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoController : ControllerBase
    {
        private readonly IMongoService mongoService; 

        public MongoController(IMongoService _mongoService)
        {
            mongoService = _mongoService;
        }

        [HttpGet]
        [Route("GetAllRecord")]
        public async Task<ActionResult> GetAllRecord()
        {   
            var model = await mongoService.GetAllRecordsAsync(); 
            if(model != null && model.Any() )
            {
                return Ok( model ); 
            }   
            return BadRequest();
        }

        [HttpGet]
        [Route("GetRecordById/{id}")]
        public async Task<ActionResult> GetRecordById(string id)
        {   
            var model = await mongoService.GetRecordByIdAsync(id); 
            if( model != null )
            {
                return Ok( model ); 
            }   
            return BadRequest();
        }
        
        [HttpPost]
        [Route("InsertRecordByModel")]
        public async Task<ActionResult> InsertRecordByModel([FromBody] NoteDTO model )
        {       
            var request = await mongoService.InsertRecordByModelAsync(model);
            if (request)
            {
                return CreatedAtAction(nameof(GetRecordById), new { id = model.Id }, model);
            }
            
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateRecordByModel")]
        public async Task<ActionResult> UpdateRecordByModel([FromBody] NoteDTO model )
        {   
            var request = await mongoService.UpdateRecordByModelAsync(model); 
            if( request )
            {
                return Ok( model ); 
            }   
            return BadRequest();
        }

        [HttpGet]
        [Route("DeleteRecordById/{id}")]
        public async Task<ActionResult> DeleteRecordById(string id)
        {   
            var request = await mongoService.DeleteRecordByIdAsync(id); 
            if( request )
            {
                return Ok( request ); 
            }   
            return BadRequest();
        }
    }
}
