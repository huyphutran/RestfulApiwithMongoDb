using System;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Services;
using MongoExample.Models;
using MongoDB.Driver;

namespace MongoExample.Controllers; 

[Controller]
[Route("api/[controller]")]
public class PlaylistController : Controller {

    private readonly MongoDBService _mongoDBService;

    public PlaylistController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet] // Read db

    public async Task<List<Playlist>> Get() { 

        return await _mongoDBService.GetAsync();

     }

    [HttpPost] // Create db
    public async  Task<IActionResult> Post([FromBody] Playlist playlist) {

        await _mongoDBService.CreateAsync(playlist);
        return CreatedAtAction(nameof(Get), new {id = playlist.Id}, playlist);
     }

    [HttpPut("id")] // Update db
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId) {
        await _mongoDBService.AddToPlaylistAsync(id,movieId);
        return NoContent();
    }


    [HttpDelete("id")] // Delete db
    public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
     }


}