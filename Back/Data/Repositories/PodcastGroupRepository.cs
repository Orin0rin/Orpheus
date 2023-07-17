using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PodcastGroupRepository:IPodcastGroupRepository
    {
        private readonly dbDataContext _context;
        public PodcastGroupRepository(dbDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PodcastGroup>> GetAllPodcastGroupsAsync()
        => await _context.PodcastGroups.ToListAsync();

        public async Task<PodcastGroup?> GetPodcastGroupByPodcastGroupIdAsync(int PodcastGroupId)
        => await _context.PodcastGroups.FirstOrDefaultAsync(p => p.ID == PodcastGroupId);
        public async Task DeletePodcastGroupByIdAsync(int PodcastGroupId)
        {
            try
            {
                var podcastGroup = await _context.PodcastGroups.FindAsync(PodcastGroupId);
                if (podcastGroup != null)
                {
                    _context.PodcastGroups.Remove(podcastGroup);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task AddPodcastGroupAsync(PodcastGroup podcastGroup)
        {
            await _context.PodcastGroups.AddAsync(new PodcastGroup()
            {
                Name = podcastGroup.Name,
                NumberOfEpisodes = podcastGroup.NumberOfEpisodes,
                Status = podcastGroup.Status,
                ImgAddress = podcastGroup.ImgAddress

            });
            await _context.SaveChangesAsync();
        }
        public async Task EditPodcastGroupByIdAsync(int PodcastGroupId, PodcastGroup pg)
        {
            var podcastGroup = await _context.PodcastGroups.FindAsync(PodcastGroupId);
            podcastGroup.Name = pg.Name;
            podcastGroup.NumberOfEpisodes = pg.NumberOfEpisodes;
            podcastGroup.Status = pg.Status;
            podcastGroup.ImgAddress = pg.ImgAddress;


            await _context.SaveChangesAsync();
        }
    }
}
