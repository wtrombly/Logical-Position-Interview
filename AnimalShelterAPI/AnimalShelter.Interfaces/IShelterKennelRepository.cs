using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;



namespace AnimalShelter.Interfaces
{
    public interface IShelterKennelRepository
    {
        public List<ShelterKennelBO> GetShelterKennels();

        public void UpdateAllShelterKennels(List<ShelterKennelBO> list);

        public void UpdateShelterKennel(ShelterResponseModel response);

        public void UpdateShelterKennel(AdoptionResponseModel response);

        public bool IsAnimalSheltered(AdoptionRequestModel model);

        public void RemoveShelteredAnimal(AdoptionRequestModel request);
    }
}
