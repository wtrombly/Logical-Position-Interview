
namespace AnimalShelter.Models.Presentation
{
    public class ShelterResponseModel
    {
        public bool IsAccepted { get; set; }
        public int KennelId { get; set; }
        public string AnimalName { get; set; }  
        public string Message { get; set; }
    }
}
