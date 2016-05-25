using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoApp.Models;
using ToDoApp.ViewModels;

namespace ToDoApp.Services
{
    class RestClient
    {
        private const string TaskResourceUrl = "http://windowsphoneuam.azurewebsites.net/api/ToDoTasks";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<ToDoTask> PostTask(ToDoTask task)
        {
            var serialized = JsonConvert.SerializeObject(task);
            var response = await _httpClient.PostAsync(TaskResourceUrl, new StringContent(serialized, Encoding.UTF8, "application/json"));
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ToDoTask>(content);
        }

        public async Task<List<ToDoTask>> GetUserTasks()
        {
            try
            {
                var response = await _httpClient.GetAsync(TaskResourceUrl);
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ToDoTask>>(content);
            }
            catch (Exception e)
            {
                 Debug.WriteLine(e.Message);          
            }
            return new List<ToDoTask>();
        }

        public async void PutTask(ToDoTask toDoTask)
        {
            var serialized = JsonConvert.SerializeObject(toDoTask);
            await _httpClient.PutAsync(TaskResourceUrl + "/" + toDoTask.Id, new StringContent(serialized, Encoding.UTF8, "application/json"));
        }

        public async void DeleteTask(ToDoTask toDoTask)
        {
            var response = await _httpClient.DeleteAsync(TaskResourceUrl + "/" + toDoTask.Id);
        }
    }
}
