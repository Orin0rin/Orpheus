using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPodcastRepository
    {
        #region Podcast
        Task<IEnumerable<Podcast>> GetAllPodcastsAsync();
        Task<Podcast> GetPodcastByPodcastIdAsync(int PodcastId);
        Task DeletePodcastByIdAsync(int PodcastId);
        Task AddPodcastAsync(PodcastModel podcast);
        Task EditPodcastByIdAsync(int PodcastId, PodcastModel pm);



        #endregion
    }
}
