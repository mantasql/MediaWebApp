using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Utils
{
    internal class DictionaryValueComparer<TKey, TValue> : ValueComparer<Dictionary<TKey, TValue>>
    {
        public DictionaryValueComparer()
        : base(
            (d1, d2) => DictionaryEquals(d1, d2),
            d => GetHashCode(d),
            d => Clone(d))
        {
        }

        private static bool DictionaryEquals(Dictionary<TKey, TValue> d1, Dictionary<TKey, TValue> d2)
        {
            if (ReferenceEquals(d1, d2))
                return true;

            if (d1 is null || d2 is null)
                return false;

            // Use LINQ to compare key-value pairs
            return d1.OrderBy(kv => kv.Key)
                     .SequenceEqual(d2.OrderBy(kv => kv.Key));
        }

        private static int GetHashCode(Dictionary<TKey, TValue> d)
        {
            if (d is null)
                return 0;

            // Combine hash codes of key-value pairs
            return d.Select(kv => (kv.Key?.GetHashCode() ?? 0) ^ (kv.Value?.GetHashCode() ?? 0))
                    .Aggregate((current, next) => (current * 397) ^ next);
        }

        private static Dictionary<TKey, TValue> Clone(Dictionary<TKey, TValue> d)
        {
            if (d is null)
                return null;

            // Create a new dictionary with the same key-value pairs
            return d.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}
