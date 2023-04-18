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
    public class KennelCapacityService : IKennelCapacityService
    {
        private readonly IShelterKennelRepository _shelterKennelRepository;

        // Expose a KennelCapacityBO property
        public KennelCapacityBO KennelCapacity { get; private set; }

        public KennelCapacityService(IShelterKennelRepository shelterKennelRepository)
        {
            _shelterKennelRepository = shelterKennelRepository;

            var kennels = _shelterKennelRepository.GetShelterKennels();

            KennelCapacity = CalculateKennelCapacity(kennels);
        }

        public KennelCapacityBO CalculateKennelCapacity(List<ShelterKennelBO> kennels)
        {
            KennelCapacityBO kennelCapacity = new KennelCapacityBO();

            kennelCapacity.KennelCount = kennels.Count;
            kennelCapacity.KennelCountVacant = kennels.FindAll(k => k.IsOccupied == false).Count;

            kennelCapacity.SmallKennelCount = kennels.Count(k => k.KennelSize == Size.Small);
            kennelCapacity.SmallKennelCountVacant = kennels.FindAll(k => k.IsOccupied == false && k.KennelSize == Size.Small).Count;
            kennelCapacity.SmallVacantKennelIds = kennels.Where(k => k.IsOccupied == false && k.KennelSize == Size.Small).Select(k => k.KennelIdValue).ToList();

            kennelCapacity.MediumKennelCount = kennels.Count(k => k.KennelSize == Size.Medium);
            kennelCapacity.MediumKennelCountVacant = kennels.FindAll(k => k.IsOccupied == false && k.KennelSize == Size.Medium).Count;
            kennelCapacity.MediumVacantKennelIds = kennels.Where(k => k.IsOccupied == false && k.KennelSize == Size.Medium).Select(k => k.KennelIdValue).ToList();

            kennelCapacity.LargeKennelCount = kennels.Count(k => k.KennelSize == Size.Large);
            kennelCapacity.LargeKennelCountVacant = kennels.FindAll(k => k.IsOccupied == false && k.KennelSize == Size.Large).Count;
            kennelCapacity.LargeVacantKennelIds = kennels.Where(k => k.IsOccupied == false && k.KennelSize == Size.Large).Select(k => k.KennelIdValue).ToList();

            return kennelCapacity;
        }

        

    }
}
