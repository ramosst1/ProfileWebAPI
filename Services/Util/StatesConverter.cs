using AutoMapper;
using Models.States;

namespace Services.Util
{
    public class StatesConverter
    {
        private StatesConverter()
        {
            
        }

        public static List<StateModel> Convert(List<StateDto> profiles)
        {
            var profilesConverted = new List<StateModel>();

            profiles.ForEach(selectedProfile =>
                profilesConverted.Add(Convert(selectedProfile))
            );

            return profilesConverted;
        }

        public static StateModel Convert(StateDto aProfile)
        {

            if (aProfile == null) return null;

            var MapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StateDto, StateModel>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var results = iMapper.Map<StateDto, StateModel>(aProfile);

            return results;
        }

    }
}
