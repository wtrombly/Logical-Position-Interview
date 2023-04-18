
namespace AnimalShelter.Data.DataModels
{
    public class Kennel
    {
        public int KennelId { get; set; }
        public string AnimalName { get; set; }
        public string IsOccupied { get; set; }
        public Size KennelSize { get; set; }
    }
}
