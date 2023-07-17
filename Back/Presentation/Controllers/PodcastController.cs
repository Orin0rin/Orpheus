using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class PodcastController : BaseController
    {
        #region Constructor
        private readonly IPodcastService _podcastService;
        private readonly ITokenService _tokenService;
        public PodcastController(IPodcastService podcastService, ITokenService tokenService)
        {
            _podcastService = podcastService;
            _tokenService = tokenService;
        }
        #endregion

        [HttpGet("{jwt}")]
        public async Task<IActionResult> Get(string jwt)
        {
            await _tokenService.CallValidateJWTAsync(jwt);
            var list1 = await _podcastService.GetAllPodcastsAsync();

            var list2 = list1
                .Select(rec => new
                {
                    rec.ID,
                    rec.Title,
                    rec.PublishDate,
                    rec.Description,
                    PodcastGroupName = rec.PodcastGroup.Name,
                    rec.GroupID,
                    rec.VoiceAddress
                })
                .ToList();
            return Ok(new
            {
                list = list2
            });
        }

       
        [HttpGet("{id}/{jwt}")]
        public async Task<Podcast?> Get(int id, string jwt)
        {
            await _tokenService.CallValidateJWTAsync(jwt);
            return await _podcastService.GetPodcastByPodcastIdAsync(id);
        }


        [HttpPost("{jwt}")]
        public async Task Post([FromBody] PodcastModel podcast,string jwt)
        {
            await _podcastService.AddPodcastAsync(podcast);
        }


        [HttpPut("{id}/{jwt}")]
        public async Task Put(int id, [FromBody] PodcastModel pm, string jwt)
        {
            await _tokenService.CallValidateJWTAsync(jwt);
            await _podcastService.EditPodcastByIdAsync(id,pm);
        }

        
        [HttpDelete("{id}/{jwt}")]
        public async Task Delete (int id, string jwt)
        {
            await _tokenService.CallValidateJWTAsync(jwt);
            await _podcastService.DeletePodcastByIdAsync(id);
        }
    }
}
