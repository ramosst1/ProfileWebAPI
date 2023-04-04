
using Models.APIResponses;
using Models.APIResponses.States;
using Repositories.States;
using Services.Util;

namespace Services.States
{
    public class StatesServices : IStatesServices
    {
        private readonly IStatesRepository _statesRepository;

        public StatesServices(IStatesRepository statesRepository)
        {
            _statesRepository = statesRepository;
        }

        public async Task<StatesResponse> GetAllStatesAsync()
        {
            var response = new StatesResponse();

            try
            {
                var profiles = await _statesRepository.GetAllStatesAsync();
                response.States = StatesConverter.Convert(profiles);
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
    }
}
