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
        collection = new MongoClient(settings.ConnectionURL)
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

    public Task<NoteDTO> InsertRecordByModel(NoteDTO model)
    {
        throw new NotImplementedException();
    }

    public Task<NoteDTO> UpdateRecordByModel(NoteDTO model)
    {
        throw new NotImplementedException();
    }
    public Task<NoteDTO> DeleteRecordById(string id)
    {
        throw new NotImplementedException();
    }
}
