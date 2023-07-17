using Application.Services.Implementation;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class PodcastGroupController : BaseController
    {
        #region Constructor
        private readonly IPodcastGroupService _podcastGroupService;
        public PodcastGroupController(IPodcastGroupService podcastGroupService)
        {
            _podcastGroupService = podcastGroupService;
        }
        #endregion

        // GET: api/<PodcastGroupController>
        [HttpGet]
        public async Task<IEnumerable<PodcastGroup>> Get()
        {
            return await _podcastGroupService.GetAllPodcastGroupsAsync();
        }

        // GET api/<PodcastGroupController>/5
        [HttpGet("{id}")]
        public async Task<PodcastGroup?> Get(int id)
        {
            return await _podcastGroupService.GetPodcastGroupByPodcastGroupIdAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post([FromBody] PodcastGroupModel pgm)
        {
            await _podcastGroupService.AddPodcastGroupAsync(pgm);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PodcastGroupModel pgm)
        {
            await _podcastGroupService.EditPodcastGroupByIdAsync(id, pgm);
        }


        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _podcastGroupService.DeletePodcastGroupByIdAsync(id);

        }
    }
}
