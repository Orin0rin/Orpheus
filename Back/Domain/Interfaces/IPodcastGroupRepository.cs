using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPodcastGroupRepository
    {
        #region PodcastGroup
        Task<IEnumerable<PodcastGroup>> GetAllPodcastGroupsAsync();
        Task<PodcastGroup> GetPodcastGroupByPodcastGroupIdAsync(int PodcastGroupId);
        Task DeletePodcastGroupByIdAsync(int PodcastGroupId);
        Task AddPodcastGroupAsync(PodcastGroup podcastGroup);
        Task EditPodcastGroupByIdAsync(int PodcastGroupId, PodcastGroup pg);

        #endregion
    }
}
