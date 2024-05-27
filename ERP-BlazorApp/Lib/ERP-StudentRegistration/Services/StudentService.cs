//using ERP.StudentRegistration.Core.DTO.Request;
//using ERP_StudentRegistration.DTOs.Response;
//using ERP_StudentRegistration.Services.Interfaces;
//using System.Net.Http.Json;
//using System.Text.Json;
//using System.Text;

//namespace ERP_StudentRegistration.Services
//{
//    public class StudentService : IStudentService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly JsonSerializerOptions _serializerOptions;

//        public StudentService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;

//            _serializerOptions = new JsonSerializerOptions 
//            {
//                PropertyNameCaseInsensitive = true,
//            };
//        }

//        public async Task<List<StudentResponse>> GetStudents()
//        {
//            try 
//            {
//                var apiResponse = await _httpClient.GetStreamAsync($"api/StudentRegistration");

//                var students = await JsonSerializer.DeserializeAsync<List<StudentResponse>>(apiResponse, _serializerOptions);
//                return students ?? new List<StudentResponse>();
//            }
//            catch (Exception ex) 
//            {
//                Console.WriteLine(ex.Message);
//                throw;
//            }
//        }

//        public async Task<StudentResponse?> GetStudentById(Guid id)
//        {
//            var student = await _httpClient.GetFromJsonAsync<StudentResponse>($"api/StudentRegistration/{id}");
//            return student;
//        }


//        public async Task<StudentResponse?> AddStudent(CreateStudentRequest student)
//        {
//            try  
//            {
//                var studentJson = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");

//                var response = await _httpClient.PostAsync($"api/StudentRegistration", studentJson);

//                if (!response.IsSuccessStatusCode)
//                    return null;

//                var responseBody = await response.Content.ReadAsStreamAsync();
//                var newStudent = await JsonSerializer.DeserializeAsync<StudentResponse>(responseBody, _serializerOptions);

//                return newStudent;
             
//            }
//            catch (Exception ex) 
//            {
//                Console.WriteLine(ex);
//                throw;

//            }
//        }

//        public Task<bool> DeleteStudent(Guid id)
//        {
//            throw new NotImplementedException();
//        }


//        public Task<bool> UpdateDriver(UpdateStudentRequest student)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
