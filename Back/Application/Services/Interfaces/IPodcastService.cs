using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPodcastService
    {
        #region Podcast
        Task<IQueryable<Podcast>> GetAllPodcastsAsync();
        Task<Podcast> GetPodcastByPodcastIdAsync(int PodcastId);
        Task DeletePodcastByIdAsync(int PodcastId);
        Task AddPodcastAsync(PodcastModel podcast);
        Task EditPodcastByIdAsync(int PodcastId, PodcastModel pm);

        #endregion
    }
}
