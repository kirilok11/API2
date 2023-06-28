using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Migrations;
using API.Controllers;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly FavoriteContext _favoriteContext;
        public FavoriteController(FavoriteContext favoriteContext) 
        {
            _favoriteContext = favoriteContext;
        }
        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<Favorites>>>GetFavorites() 
        {
            if(_favoriteContext.favorites == null) 
            {
                return NotFound();
            }
            return await _favoriteContext.favorites.ToListAsync();
        }
        [HttpGet("get{id}")]
        public async Task<ActionResult<Favorites>> GetFavorites(int id)
        {
            if (_favoriteContext.favorites == null)
            {
                return NotFound();
            }
            var favorite = await _favoriteContext.favorites.FindAsync(id);
            if(favorite == null) 
            {
                return NotFound();
            }
            return favorite;
        }
        [HttpPost("post")]
        public async Task<ActionResult<Favorites>>PostFavorities(Favorites favorites) 
        {
            _favoriteContext.favorites.Add(favorites);
            await _favoriteContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFavorites), new { id = favorites.Id }, favorites);
        }
        [HttpDelete("delete{id}")]
        public async Task<ActionResult> DeleleFavorities(int id) 
        {
            if(_favoriteContext.favorites == null) 
            {
                return NotFound(id);
            }
            var favorit = await _favoriteContext.favorites.FindAsync(id);
            if(favorit == null) 
            {
                return NotFound();

            }
            _favoriteContext.favorites.Remove(favorit);
            await _favoriteContext.SaveChangesAsync();
            return Ok();
        }


    }
}
