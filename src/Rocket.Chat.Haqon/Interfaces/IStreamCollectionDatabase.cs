using System.Threading;
using System.Threading.Tasks;

namespace Rocket.Chat.Haqon.Interfaces
{
    public interface IStreamCollectionDatabase
    {
        bool TryGetCollection(string collectionName, out IStreamCollection collection);
        IStreamCollection GetOrAddCollection(string collectionName);

        Task<IStreamCollection> WaitForObjectInCollectionAsync(string collectionName, string id,
                                                      CancellationToken token);
    }
}