﻿using Microsoft.AspNetCore.Mvc;
using API.Clients;
using API.Models;

namespace API.Controllers
{
    
        [ApiController]
        [Route("[controller]")]
        public class BookingController : ControllerBase
        {
            private readonly ILogger<BookingController> _logger;

            public BookingController(ILogger<BookingController> logger)
            {
                _logger = logger;
            }

            [HttpGet(Name = "hotels around")]
            public async Task<RootBook> Place(string CheckInDate, string DestType, string CheckOutDate, string NumOfAdults, string DestId, string NumOfRooms, string NumOfChildren, string AgeOfChildren)
        {
                BookingClient client = new BookingClient();
                return client.SearchHotels(CheckInDate, DestType, CheckOutDate, NumOfAdults, DestId, NumOfRooms, NumOfChildren, AgeOfChildren).Result;
            }
        }
    
}
