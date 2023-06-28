/*
using API.Clients;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly ILogger<DatabaseController> _logger;

        public DatabaseController(ILogger<DatabaseController> logger)
        {
            _logger = logger;
        }
        long d = 500;
        string n = "dsadas";
        int s = 21;

        [HttpPost]
        /*
        public async Task <long> Place(long ID, string Name, int Score)
        {
            ID = d;
            Name = n;
            Score = s;
            DataBase dataBase = new DataBase();
            
            dataBase.InsertFavoriteDishesAsync(ID, Name, Score);
            return ID;
            
        }
        
        public async  Place(string cont)
        {
            GptClient client = new GptClient();

            return await client.ChatRespone(cont);
        }

    }
}
*/