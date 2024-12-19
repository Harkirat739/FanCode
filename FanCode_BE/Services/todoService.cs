using Microsoft.Extensions.Logging;
using FanCode_BE.interfaces;
using FanCode_BE.Models;

namespace FanCode_BE.Services
{
    public class todoService : ItodoService, IDisposable
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        public todoService(ILogger<todoService> logger)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com");
            _logger = logger;
        }
        public void Dispose()
        {
            _client.Dispose();
        }

        public async ValueTask<IEnumerable<TodoRequestModel>> GetTodos()
        {
            IEnumerable<TodoRequestModel> todoRequests = Enumerable.Empty<TodoRequestModel>();

            try
            {
                _logger.LogInformation("method:{method} - get all users list from api-{api}", nameof(GetTodos), "/users");
                var userAsync = await _client.GetAsync("/users");
                HttpResponseMessage respMsg = userAsync.EnsureSuccessStatusCode();
                if (respMsg.IsSuccessStatusCode == true)
                {
                    var userLst = await respMsg.Content.ReadFromJsonAsync<List<UserRequestModel>>();
                    if (userLst == null) return todoRequests;

                    _logger.LogInformation("method:{method} - get all todo list from api-{api}", nameof(GetTodos), "/todos");

                    var todoAsync = await _client.GetAsync("/todos");
                    HttpResponseMessage respTodoMsg = todoAsync.EnsureSuccessStatusCode();
                    if (respTodoMsg.IsSuccessStatusCode == true)
                    {
                        var TodoLst = await respTodoMsg.Content.ReadFromJsonAsync<List<TodoRequestModel>>();
                        if (TodoLst == null) return todoRequests;

                        _logger.LogInformation("method:{method} - logic for get more then 50% complete tasks for all users", nameof(GetTodos));

                        var filterUserListAsPerFancode = userLst
                            .Where(f => f.Address?.Geo?.Lat >= -40 && f.Address?.Geo?.Lat <= 5)
                            .Where(f => f.Address?.Geo?.Lng >= 5 && f.Address?.Geo?.Lng <= 100);

                        var userAllTaskList = (from todo in TodoLst
                                               join users in filterUserListAsPerFancode on todo.UserId equals users.Id
                                               group new { todo, users.Name } by todo.UserId into userGroup
                                               let totalTasks = userGroup.Count()
                                               let completedTasks = userGroup.Count(t => t.todo.Completed == true)
                                               where completedTasks > totalTasks * 0.5
                                               from todoList in userGroup
                                               select new TodoRequestModel
                                               {
                                                   UserId = userGroup.Key,
                                                   Completed = todoList.todo.Completed,
                                                   Title = todoList.todo.Title,
                                                   Id = todoList.todo.Id,
                                                   Name = todoList.Name,
                                               }).AsQueryable();
                        if (userAllTaskList.Any())
                            todoRequests = userAllTaskList.AsEnumerable();
                    }
                    else return todoRequests;
                }
                return todoRequests;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
       

    }
}
