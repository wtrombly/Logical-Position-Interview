using AnimalShelter.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data.DataModels;

public class ShelterKennelResponseModel
{
    public int KennelIdValue { get; set; }
    public Size KennelSize { get; set; }
    public bool IsOccupied { get; set; }
    public IShelterAnimal? ShelterAnimal { get; set; }
}
