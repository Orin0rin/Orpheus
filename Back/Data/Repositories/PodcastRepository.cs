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
    public class PodcastRepository : IPodcastRepository
    {
        private readonly dbDataContext _context;
        public PodcastRepository(dbDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Podcast>> GetAllPodcastsAsync()
        => await _context.Podcasts.ToListAsync();

        public async Task<Podcast?> GetPodcastByPodcastIdAsync(int PodcastId)
        => await _context.Podcasts.FirstOrDefaultAsync(p => p.ID == PodcastId);
        public async Task DeletePodcastByIdAsync(int PodcastId)
        {
            var podcast = await _context.Podcasts.FindAsync(PodcastId);
            if (podcast!=null)
            {
                _context.Podcasts.Remove(podcast);
                await _context.SaveChangesAsync();
            }
        }
        public async Task AddPodcastAsync(PodcastModel podcast)
        {
            await _context.Podcasts.AddAsync(new Podcast()
            {
                Title = podcast.Title,
                Description = podcast.Description,
                PublishDate = podcast.PublishDate,
                VoiceAddress = podcast.VoiceAddress,
                GroupID = podcast.GroupID,
                
            });
            await _context.SaveChangesAsync();
        }
        public async Task EditPodcastByIdAsync(int PodcastId, PodcastModel pm)
        {
            var podcast = await _context.Podcasts.FindAsync(PodcastId);
            podcast.Title = pm.Title;
            podcast.Description = pm.Description;
            podcast.PublishDate = pm.PublishDate;
            podcast.VoiceAddress = pm.VoiceAddress;
            podcast.GroupID = pm.GroupID;
            
            await _context.SaveChangesAsync();
        }
    }
}
