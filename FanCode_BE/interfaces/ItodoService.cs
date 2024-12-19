using FanCode_BE.Models;

namespace FanCode_BE.interfaces
{
    public interface ItodoService
    {
        ValueTask<IEnumerable<TodoRequestModel>> GetTodos();
    }
}
