using System;
using MongoCore.Core.DTOs;

namespace MongoCore.Core.Interfaces.InterfaceRepositories;

public interface IMongoRepository
{
    Task<List<NoteDTO>> GetAllRecords();
    Task<NoteDTO> GetRecordById(string id);
    Task<bool> InsertRecordByModel(NoteDTO model);
    Task<bool> UpdateRecordByModel(NoteDTO model);
    Task<bool> DeleteRecordById(string id);
}
