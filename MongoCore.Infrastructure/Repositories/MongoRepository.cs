using MongoCore.Core.DTOs;
using MongoCore.Core.Interfaces.InterfaceRepositories;
using MongoCore.Core.Interfaces.InterfaceServices;
using MongoDB.Driver;

namespace MongoCore.Infrastructure.Repositories;

public class MongoRepository : IMongoRepository
{
    private readonly IMongoCollection<NoteDTO> collection;

    public MongoRepository( IDatabaseSettings settings)
    {
        collection = new MongoClient(settings.ConnectionURI)
            .GetDatabase(settings.DatabaseName)
            .GetCollection<NoteDTO>(settings.CollectionName) ;
    }

    public async Task<List<NoteDTO>> GetAllRecordsAsync()
    {
        try
        {
            var getCollect = await collection.Find(x => true).ToListAsync();            
            if ( getCollect != null && getCollect.Any() )
            {
                return getCollect;
            }
            return new List<NoteDTO>();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<NoteDTO> GetRecordByIdAsync(string id)
    {
        try
        {
            var getCollect = await collection.Find(x => x.Id == id).FirstOrDefaultAsync();         
            return getCollect;   
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> InsertRecordByModelAsync(NoteDTO model)
    {
        try
        {
            model.Id = null; 
            model.CreatedDate = DateTime.Now;
            await collection.InsertOneAsync(model);

            return true;
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
            if (model != null && !string.IsNullOrEmpty( model.Id ))
            {
                await collection.ReplaceOneAsync(x => x.Id == model.Id, model);
                return true; 
            }
            return false; 
        }
        catch (Exception)
        {
            throw;
        }

        throw new NotImplementedException();
    }
    public async Task<bool> DeleteRecordByIdAsync(string id)
    {
        try
        {
            var model = await GetRecordByIdAsync(id);
            if (model != null && !string.IsNullOrEmpty( model.Id ))
            {
                await collection.DeleteOneAsync(x => x.Id == model.Id);
                return true; 
            }
            return false; 
        }
        catch (Exception)
        {
            throw;
        }
    }
}
