using Rocket.Chat.Haqon.Models.Collections;

namespace Rocket.Chat.Haqon.Collections
{
    public class TypedStreamCollectionEventArgs<T>
    {
        public T Result { get; set; }

        public ModificationType ModificationType { get; set; }

        public TypedStreamCollectionEventArgs(T result, ModificationType type)
        {
            Result = result;
            ModificationType = type;
        }
    }
}