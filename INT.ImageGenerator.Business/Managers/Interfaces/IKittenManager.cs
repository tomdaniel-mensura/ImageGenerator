namespace INT.ImageGenerator.Business.Managers.Interfaces
{
    public interface IKittenManager
    {
        // method to fetch an url of an image of a kitten
        public Task<string> GetRandomKittenImageUrl();
    }
}
