
namespace AnimalShelter.Models.Presentation
{
    public class AdoptionResponseModel
    {
        public bool IsRemoved { get; set; }
        public int? KennelId { get; set; }   
        public string AnimalName { get; set; }
        public string Message { get; set; }
    }
}
