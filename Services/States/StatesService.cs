using Models.APIResponses;
using Models.States;
using Profiles.Models.APIResponses;
using Repositories.States;
using Services.States.DataMapper;
using Services.States.Interfaces;

namespace Services.States
{
    public class StatesService : IStatesServices
    {
        private readonly IStatesRepository _statesRepository;

        public StatesService(IStatesRepository statesRepository)
        {
            _statesRepository = statesRepository;
        }

        public async Task<ApiResponse<List<StateModel>>> GetAllStatesAsync()
        {
            var response = new ApiResponse<List<StateModel>>();

            try
            {
                var states = await _statesRepository.GetAllStatesAsync();

                response.data = states.MapDataAsStateModel();

                response.Success = true;
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.ErrorMessages.Add(new ErrorMessageModel()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });

            }
            return response;
        }
    }
}
