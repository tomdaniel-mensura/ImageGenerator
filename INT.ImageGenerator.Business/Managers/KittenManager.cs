using INT.ImageGenerator.Business.Managers.Interfaces;
using Unsplash.Api;

namespace INT.ImageGenerator.Business.Managers
{
    internal class KittenManager : IKittenManager
    {
        private readonly IPhotosApi _photosApi;
        public KittenManager(IPhotosApi photosApi) {
            _photosApi = photosApi;
        }

        public async Task<string> GetRandomKittenImageUrl()
        {
            // fetch a random image of a kitten from the Unsplash API

            // and return the url of the image
            var kittens = await _photosApi.GetRandomPhotosAsync(new RandomPhotoFilterOptions(query: "kitten"));
            return kittens.First().Urls.Regular;
        }
    }
}
