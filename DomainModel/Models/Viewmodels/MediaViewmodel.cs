using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models.Viewmodels
{
    public class MediaViewmodel
    {
        public Media Media { get; set; }
        public List<string> Genres { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
    }
}
