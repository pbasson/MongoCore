using System;

namespace MongoCore.Core.Interfaces.InterfaceServices;

public interface IDatabaseSettings
{
    string ConnectionURL {get; set;}
    string DatabaseName {get; set;}
    string CollectionName {get; set;}
}
