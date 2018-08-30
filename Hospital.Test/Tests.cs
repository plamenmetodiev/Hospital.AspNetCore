namespace Hospital.Test
{
    using AutoMapper;
    using Hospital.Web.Infrastructure.Mapping;

    public class Tests
    {
        private static bool testsInitialized = false;

        public void Initialize()
        {
            if (!testsInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testsInitialized = true;
            }
        }
    }
}
