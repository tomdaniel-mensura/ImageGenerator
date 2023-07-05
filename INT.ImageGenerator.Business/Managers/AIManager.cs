using INT.ImageGenerator.Business.Enumerations;
using INT.ImageGenerator.Business.Managers.Interfaces;
using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.ImageGenerator.Business.Managers
{
    public class AIManager : IAIManager
    {
        private readonly IOpenAIAPI _openAIAPI;

        public AIManager(IOpenAIAPI openAIAPI)
        {
            _openAIAPI = openAIAPI;
        }

        // Method to generate an image url of an animal based on animalType, animalColor and animalAge enums and query
        public async Task<string> GetRandomAnimalImageUrl(
            AnimalEnum animalType,
            AnimalColorEnum animalColor,
            AnimalAgeEnum animalAge,
            string query)
        {
            // concat all enums and query into one string
            string prompt = animalType.ToString() + " " + animalColor.ToString() + " " + animalAge.ToString() + " " + query;
            var result = await _openAIAPI.ImageGenerations.CreateImageAsync(prompt);
            return result.Data.FirstOrDefault()?.Url;
        }
    }
}
