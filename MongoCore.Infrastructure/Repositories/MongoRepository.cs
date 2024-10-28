using MongoCore.Core.DTOs;
using MongoCore.Core.Interfaces.InterfaceRepositories;
using MongoCore.Core.Interfaces.InterfaceServices;
using MongoDB.Driver;

namespace MongoCore.Infrastructure.Repositories;

public class MongoRepository : IMongoRepository
{
    private readonly IMongoCollection<NoteDTO> collection;

    public MongoRepository(IDatabaseSettings settings)
    {
        collection = new MongoClient(settings.ConnectionURI)
            .GetDatabase(settings.DatabaseName)
            .GetCollection<NoteDTO>(settings.CollectionName) ;
    }

    public async Task<List<NoteDTO>> GetAllRecords()
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

    public async Task<NoteDTO> GetRecordById(string id)
    {
        try
        {
            var getCollect = await collection.Find(x => x.id == id).FirstOrDefaultAsync();         
            return getCollect;   
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> InsertRecordByModel(NoteDTO model)
    {
        try
        {
            model.CreatedDate = DateTime.Now;
            collection.InsertOne(model);
            return true;
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
            if (model != null && !string.IsNullOrEmpty( model.id ))
            {
                collection.ReplaceOne(x => x.id == model.id, model);
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
    public async Task<bool> DeleteRecordById(string id)
    {
        try
        {
            var model = await GetRecordById(id);
            if (model != null && !string.IsNullOrEmpty( model.id ))
            {
                collection.DeleteOne(x => x.id == model.id);
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
