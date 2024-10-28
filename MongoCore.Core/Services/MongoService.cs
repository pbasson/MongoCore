using System;
using MongoCore.Core.DTOs;
using MongoCore.Core.Interfaces.InterfaceRepositories;
using MongoCore.Core.Interfaces.InterfaceServices;

namespace MongoCore.Core.Services;

public class MongoService : IMongoService
{
    private readonly IMongoRepository _repository = default!;

    public async Task<List<NoteDTO>> GetAllRecords()
    {
        try
        {
            var getModel = await _repository.GetAllRecords();
            if (getModel != null && getModel.Any() )
            {
                return getModel;
            }            

            return new List<NoteDTO>();
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task<NoteDTO> GetRecordById(string id)
    {
        try
        {
            var getModel = await _repository.GetRecordById(id);
            if (getModel != null)
            {
                return getModel;
            }            
            return new NoteDTO(); 
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task<NoteDTO> InsertRecordByModel(NoteDTO model)
    {
        throw new NotImplementedException();
    }

    public async Task<NoteDTO> UpdateRecordByModel(NoteDTO model)
    {
        throw new NotImplementedException();
    }

    public async Task<NoteDTO> DeleteRecordById(string id)
    {
        throw new NotImplementedException();
    }
}
