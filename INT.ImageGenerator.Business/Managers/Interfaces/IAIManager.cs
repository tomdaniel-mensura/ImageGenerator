using INT.ImageGenerator.Business.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.ImageGenerator.Business.Managers.Interfaces
{
    public interface IAIManager
    {
        // Method to generate an image url of an animal based on animalType, animalColor and animalAge enums and query
        public Task<string> GetRandomAnimalImageUrl(
            AnimalEnum animalType,
            AnimalColorEnum animalColor,
            AnimalAgeEnum animalAge,
            string query);
    }
}
