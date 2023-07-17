using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPodcastGroupService
    {
        #region PodcastGroup
        Task<IEnumerable<PodcastGroup>> GetAllPodcastGroupsAsync();
        Task<PodcastGroup> GetPodcastGroupByPodcastGroupIdAsync(int PodcastGroupId);
        Task DeletePodcastGroupByIdAsync(int PodcastGroupId);
        Task AddPodcastGroupAsync(PodcastGroupModel pgm);
        Task EditPodcastGroupByIdAsync(int PodcastGroupId, PodcastGroupModel pgm);

        #endregion
    }
}
