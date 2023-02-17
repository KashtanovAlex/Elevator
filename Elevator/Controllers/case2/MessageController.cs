using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Elevator.Model;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.Text;

namespace Elevator.Controllers.case2;

[ApiController]
[Route("case2/[controller]")]
public class MessageController : ControllerBase
{
    /// <summary>
    /// Получение положения лифта
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Message Get()
    {
        StringBuilder text = new StringBuilder();
        foreach (var mD in Elevator.Model.MessageModel.MessageDictionary)
        {
            text.Append(mD);
        }
        return new Message{ User = 1, Content = text.ToString()};
    }
    /// <summary>
    /// Установка количества этажей в здании
    /// </summary>
    /// <param name="setting"></param>
    [HttpPost]
    public void Post(Message message)
    {
        Elevator.Model.MessageModel.MessageDictionary.Add(message.Content);
    }
}

public class Message
{
    public int User { get; set; }
    public string Content { get; set; }
}