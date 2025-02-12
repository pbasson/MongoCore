using MongoCore.Core.Interfaces.InterfaceServices;

namespace MongoCore.API.APIHelper;

public class DatabaseSettings : IDatabaseSettings
{
    public string ConnectionURI { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
}

