using ERP_StudentRequests.Core.DTOs.Request;
using ERP_StudentRequests.Core.DTOs.Response;
using ERP_StudentRequests.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace ERP_StudentRequests.Services
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }


        public Task<GetReqLetterResponse?> AddRequest(CreateReqLetterRequest student)
        {
            throw new NotImplementedException();
        }


        public Task<GetReqLetterResponse?> GetRequestById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetReqLetterResponse>> GetRequests()
        {
            //try
            //{
            //    var apiResponse = await _httpClient.GetStreamAsync($"api/StudentRequests");

            //    var requests = await JsonSerializer.DeserializeAsync<List<GetReqLetterResponse>>(apiResponse, _serializerOptions);
            //    return requests ?? new List<GetReqLetterResponse>();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}

            throw new NotImplementedException();
        }

        public Task<bool> DeleteRequest(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
