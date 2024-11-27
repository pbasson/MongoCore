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

    public async Task<List<NoteDTO>> GetAllRecordsAsync()
    {
        try
        {
            var getModel = await repository.GetAllRecordsAsync();
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

    public async Task<NoteDTO> GetRecordByIdAsync(string id)
    {
        try
        {
            var getModel = await repository.GetRecordByIdAsync(id);
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

    public async Task<bool> InsertRecordByModelAsync(NoteDTO model)
    {
        try
        {
            if (model != null)
            {
                return await repository.InsertRecordByModelAsync(model);
            }
            return false;
        }
        catch (Exception)
        {
            throw;
        }   
    }

    public async Task<bool> UpdateRecordByModelAsync(NoteDTO model)
    {
        try
        {
            if (model != null && !string.IsNullOrEmpty( model.Id))
            {
                return await repository.UpdateRecordByModelAsync(model);
            }
            return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeleteRecordByIdAsync(string id)
    {
        try
        {
            if ( !string.IsNullOrEmpty( id ) )
            {
                return await repository.DeleteRecordByIdAsync(id);
            }
            return false;
        }
        catch (Exception)
        {
            throw;
        }
    }


}
