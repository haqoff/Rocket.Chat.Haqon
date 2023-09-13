using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Rocket.Chat.Haqon.Collections;
using Rocket.Chat.Haqon.Interfaces;

namespace Rocket.Chat.Haqon.Driver
{
    public class StreamCollectionDatabase : IStreamCollectionDatabase
    {
        private readonly ConcurrentDictionary<string, IStreamCollection> _collections =
            new ConcurrentDictionary<string, IStreamCollection>();

        public bool TryGetCollection(string collectionName, out IStreamCollection collection)
        {
            return _collections.TryGetValue(collectionName, out collection);
        }

        [NotNull]
        public IStreamCollection GetOrAddCollection(string collectionName)
        {
            Func<string, StreamCollection> createCollection = name => new StreamCollection(name);

            return _collections.GetOrAdd(collectionName, createCollection);
        }

        public async Task<IStreamCollection> WaitForObjectInCollectionAsync(string collectionName, string id,
                                                                            CancellationToken token)
        {
            while (true)
            {
                IStreamCollection collection;
                var success = TryGetCollection(collectionName, out collection);

                var collectonPopulated = success && collection.ContainsId(id);
                if (collectonPopulated)
                {
                    return collection;
                }

                token.ThrowIfCancellationRequested();
                await Task.Delay(10, token).ConfigureAwait(false);
            }
        }
    }
}