using System;
using MongoCore.Core.DTOs;
using MongoCore.Core.Interfaces.InterfaceRepositories;
using MongoCore.Core.Interfaces.InterfaceServices;

namespace MongoCore.Core.Services;

public class MongoService : IMongoService
{
    private readonly IMongoRepository repository = default!;

    public MongoService(IMongoRepository _repository)
    {
        repository = _repository;
    }

    public async Task<List<NoteDTO>> GetAllRecords()
    {
        try
        {
            var getModel = await repository.GetAllRecords();
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
            var getModel = await repository.GetRecordById(id);
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

    public async Task<bool> InsertRecordByModel(NoteDTO model)
    {
        try
        {
            if (model != null && !string.IsNullOrEmpty( model.id))
            {
                return await InsertRecordByModel(model);
            }
            return false;
        }
        catch (Exception)
        {
            throw;
        }   
    }

    public async Task<bool> UpdateRecordByModel(NoteDTO model)
    {
        try
        {
            if (model != null && !string.IsNullOrEmpty( model.id))
            {
                return await InsertRecordByModel(model);
            }
            return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeleteRecordById(string id)
    {
        try
        {
            var model = await GetRecordById(id);
            if (model != null && !string.IsNullOrEmpty( model.id))
            {
                return await InsertRecordByModel(model);
            }
            return false;
        }
        catch (Exception)
        {
            throw;
        }
    }


}
