

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AnimalShelter.Data.DataModels
{
    public class Kennel
    {
        public int KennelId { get; set; }
        public string AnimalName { get; set; }
        public string IsOccupied { get; set; }
        public KennelSize KennelSize { get; set; }
    }
}
