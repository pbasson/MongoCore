using System;
using MongoCore.Core.DTOs;

namespace MongoCore.Core.Interfaces.InterfaceRepositories;

public interface IMongoRepository
{
    Task<List<NoteDTO>> GetAllRecords();
    Task<NoteDTO> GetRecordById(string id);
    Task<NoteDTO> InsertRecordByModel(NoteDTO model);
    Task<NoteDTO> UpdateRecordByModel(NoteDTO model);
    Task<NoteDTO> DeleteRecordById(string id);
}
