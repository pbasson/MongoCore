using System;
using MongoCore.Core.DTOs;

namespace MongoCore.Core.Interfaces.InterfaceServices;

public interface IMongoService
{
    Task<List<NoteDTO>> GetAllRecordsAsync();
    Task<NoteDTO> GetRecordByIdAsync(string id);
    Task<bool> InsertRecordByModelAsync(NoteDTO model);
    Task<bool> UpdateRecordByModelAsync(NoteDTO model);
    Task<bool> DeleteRecordByIdAsync(string id);
}
