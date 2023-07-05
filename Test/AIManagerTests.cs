using INT.ImageGenerator.Business;
using INT.ImageGenerator.Business.Enumerations;
using INT.ImageGenerator.Business.Managers;
using Moq;
using OpenAI_API;
using OpenAI_API.Images;

namespace Test
{
    public class AIManagerTests
    {
        // Create an AIManager
        // Create a mock IOpenAIAPI
        private readonly Mock<IOpenAIAPI> _openAIAPI;

        public AIManagerTests()
        {
            _openAIAPI = new Mock<IOpenAIAPI>();
        }

        // Create a test method to test the GetRandomAnimalImageUrl method
        [Fact]
        public void GetRandomAnimalImageUrlTest()
        {
            var responseUrl = "https://images.dog.ceo/breeds/terrier-norwich/n02094258_100.jpg";
            var imageResult = new ImageResult
            {
                Data = new List<Data>
                {
                    new Data
                    {
                        Url = responseUrl
                    }
                }
            };

            var animalType = AnimalEnum.Dog;
            var animalColor = AnimalColorEnum.Black;
            var animalAge = AnimalAgeEnum.Baby;
            var query = "cute";

            var manager = new AIManager(_openAIAPI.Object);
            _openAIAPI.Setup(x => x.ImageGenerations.CreateImageAsync(
            It.Is<string>(str => str.Contains(animalType.ToString()) &&
                str.Contains(animalColor.ToString()) &&
                str.Contains(animalAge.ToString()) &&
                str.Contains(query))))
                    .ReturnsAsync(imageResult);

            // Call the method
            var result = manager.GetRandomAnimalImageUrl(
                AnimalEnum.Dog,
                AnimalColorEnum.Black,
                AnimalAgeEnum.Baby,
                query);

            // Verify the result url is the same as the response url
            Assert.Equal(responseUrl, result.Result);
        }
    }
}
