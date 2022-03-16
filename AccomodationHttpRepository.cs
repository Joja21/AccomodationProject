using BookingApplication.Presentation.Pages;
using BookingApplication.Shared.DtoModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace BookingApplication.Presentation.HttpRepository
{
    public class AccomodationHttpRepository : IAccomodationHttpRepository
    {

        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public AccomodationHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        }

        public async Task<bool> CreateAccomodation(AccomodationDTO model)
        {
            string jsonContent = JsonSerializer.Serialize<AccomodationDTO>(model);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json"); 
            var response = await _client.PostAsync("/accomodation/create", content);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public async Task GetAccomodation(AccomodationDTO model)
        {
            string jsonContent = JsonSerializer.Serialize<AccomodationDTO>(model);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.GetAsync("/accomodation/get");
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            

        }

        public async Task<bool> DeleteAccomodation(AccomodationDTO model, int id)
        {
           
            string jsonContent = JsonSerializer.Serialize<AccomodationDTO>(model);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.DeleteAsync("/accomodation/delete");
            if (!response.IsSuccessStatusCode )
            {
                return false;
            }
            return response.IsSuccessStatusCode;
            


        }

        public async void UpdateAccomodation(AccomodationDTO model, int id) 
        {
            
            string jsonContent = JsonSerializer.Serialize<AccomodationDTO>(model);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/accomodation/update", content);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            
        }

        
    }
}
