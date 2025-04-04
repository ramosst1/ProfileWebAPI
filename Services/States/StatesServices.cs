using Models.APIResponses;
using Models.States;
using Profiles.Models.APIResponses;
using Repositories.States;
using Utilities.Converters.ObjectConverter; 

namespace Services.States
{
    public class StatesServices : IStatesServices
    {
        private readonly IStatesRepository _statesRepository;

        public StatesServices(IStatesRepository statesRepository)
        {
            _statesRepository = statesRepository;
        }

        public async Task<ApiResponse<List<StateModel>>> GetAllStatesAsync()
        {
            var response = new ApiResponse<List<StateModel>>();

            try
            {
                var states = await _statesRepository.GetAllStatesAsync();

                response.data = Convert<List<StateDto>, List<StateModel>>(states);

                response.Success = true;
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Messages.Add(new ErrorMessageModel()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });

            }
            return response;
        }
        private static TTarget Convert<TSource, TTarget>(TSource source)
        {
            var response = DataMapperConverter.Convert<TSource, TTarget>(source);

            return response;
        }

    }
}
