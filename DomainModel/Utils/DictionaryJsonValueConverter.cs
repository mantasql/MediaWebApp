using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Utils
{
    internal class DictionaryJsonValueConverter<T, K> : ValueConverter<Dictionary<T, K>, string>
    {
        public DictionaryJsonValueConverter() : base (
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<Dictionary<T, K>>(v))
        {
            
        }
    }
}
