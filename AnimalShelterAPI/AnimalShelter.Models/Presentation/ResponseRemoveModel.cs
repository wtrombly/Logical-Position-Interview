using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Presentation
{
    public class ResponseRemoveModel
    {
        public bool IsRemoved { get; set; }
        public int? KennelId { get; set; }   
        public string AnimalName { get; set; }
        public string Message { get; set; }
    }
}
