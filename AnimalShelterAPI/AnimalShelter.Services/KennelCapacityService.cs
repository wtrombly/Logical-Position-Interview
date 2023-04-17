using AnimalShelter.Interfaces;
using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class KennelCapacityService
    {
        private readonly IShelterKennelRepository _shelterKennelRepository;

        // Expose a KennelCapacityBO property
        public KennelCapacityBO KennelCapacity { get; private set; }

        public KennelCapacityService(IShelterKennelRepository shelterKennelRepository, RequestShelterModel requestShelterModel)
        {
            _shelterKennelRepository = shelterKennelRepository;

            var kennels = _shelterKennelRepository.GetShelterKennels(requestShelterModel);

            KennelCapacity = CalculateKennelCapacity(kennels);
        }

        public KennelCapacityBO CalculateKennelCapacity(List<ShelterKennelBO> kennels)
        {
            KennelCapacityBO kennelCapacity = new KennelCapacityBO();

            kennelCapacity.KennelCount = kennels.Count;
            kennelCapacity.KennelCountVacant = kennels.FindAll(k => k.IsOccupied == false).Count;

            kennelCapacity.SmallKennelCount = kennels.Count(k => k.KennelSize == KennelSize.Small);
            kennelCapacity.SmallKennelCountVacant = kennels.FindAll(k => k.IsOccupied == false && k.KennelSize == KennelSize.Small).Count;
            kennelCapacity.SmallVacantKennelIds = kennels.Where(k => k.IsOccupied == false && k.KennelSize == KennelSize.Small).Select(k => k.KennelIDValue).ToList();

            kennelCapacity.MediumKennelCount = kennels.Count(k => k.KennelSize == KennelSize.Medium);
            kennelCapacity.MediumKennelCountVacant = kennels.FindAll(k => k.IsOccupied == false && k.KennelSize == KennelSize.Medium).Count;
            kennelCapacity.MediumVacantKennelIds = kennels.Where(k => k.IsOccupied == false && k.KennelSize == KennelSize.Medium).Select(k => k.KennelIDValue).ToList();

            kennelCapacity.LargeKennelCount = kennels.Count(k => k.KennelSize == KennelSize.Large);
            kennelCapacity.LargeKennelCountVacant = kennels.FindAll(k => k.IsOccupied == false && k.KennelSize == KennelSize.Large).Count;
            kennelCapacity.LargeVacantKennelIds = kennels.Where(k => k.IsOccupied == false && k.KennelSize == KennelSize.Large).Select(k => k.KennelIDValue).ToList();

            return kennelCapacity;
        }

        

    }
}
