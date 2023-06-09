﻿
namespace AnimalShelter.Models.Business
{
    public class KennelCapacityBO
    {
        public int KennelCount;
        public int KennelCountVacant;

        public int SmallKennelCount;
        public int SmallKennelCountVacant;
        public List<int> SmallVacantKennelIds;

        public int MediumKennelCount;
        public int MediumKennelCountVacant;
        public List<int> MediumVacantKennelIds;

        public int LargeKennelCount;
        public int LargeKennelCountVacant;
        public List<int> LargeVacantKennelIds;

        public KennelCapacityBO() { }

    }
}
