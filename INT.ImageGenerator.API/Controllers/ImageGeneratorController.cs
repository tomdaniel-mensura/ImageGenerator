using INT.ImageGenerator.API.Validators;
using INT.ImageGenerator.Business;
using INT.ImageGenerator.Business.Enumerations;
using INT.ImageGenerator.Business.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace INT.ImageGenerator.API.Controllers
{
    /// <summary>
    /// API controller for image generation.
    /// </summary>
    [ApiController]
    [Route("api/images")]
    public class ImageGeneratorController : ControllerBase
    {
        private readonly IKittenManager _kittenManager;
        private readonly IAIManager _aiManager;

        public ImageGeneratorController(IKittenManager kittenManager, IAIManager aiManager)
        {
            _kittenManager = kittenManager;
            _aiManager = aiManager;
        }

        /// <summary>
        /// Gets a random image of a cat using the Unsplash API.
        /// </summary>
        /// <returns></returns>
        [HttpPost("kittens")]
        public async Task<IActionResult> GetRandomKittenImage()
        {
            // TODO:
            // 1. KittenManager
            return Ok(await _kittenManager.GetRandomKittenImageUrl());
        }

        /// <summary>
        /// Generates an animal image using the DALL-E API.
        /// </summary>
        /// <returns></returns>
        [HttpPost("animals/ai")]
        public async Task<IActionResult> GetAIGeneratedCatImage(
            AnimalEnum animalType,
            AnimalColorEnum animalColor,
            AnimalAgeEnum animalAge,
            string query)
        {
            if (!Validator.ValidateQuery(query))
            {
                throw new ArgumentException("Invalid query.");
            }

            // TODO:
            // 1. AIManager
            // 2. Update string filters to enums
            // 3. Implement required filters
            // 4. query validation:
            //    - query is optional
            //    - query should contain minimum 2 words
            //    - query should contain maximum 15 words
            //    - query should not contain any special characters
            return Ok(await _aiManager.GetRandomAnimalImageUrl(animalType, animalColor, animalAge, query));
        }
    }
}
