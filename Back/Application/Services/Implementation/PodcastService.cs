using Application.Services.Interfaces;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class PodcastService : IPodcastService
    {
        private readonly dbDataContext _context;

        public PodcastService(dbDataContext context)
        {
            _context = context;
        }


        public async Task<IQueryable<Podcast>> GetAllPodcastsAsync()
        => _context.Podcasts;

        public async Task<Podcast?> GetPodcastByPodcastIdAsync(int PodcastId)
        => await _context.Podcasts.FirstOrDefaultAsync(p => p.ID == PodcastId);
        public async Task DeletePodcastByIdAsync(int PodcastId)
        {
            try
            {
                var podcast = await _context.Podcasts.FindAsync(PodcastId);
                if (podcast != null)
                {
                    _context.Podcasts.Remove(podcast);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task AddPodcastAsync(PodcastModel podcast)
        {
            await _context.Podcasts.AddAsync(new Podcast() {
                Title = podcast.Title,
                Description = podcast.Description,
                PublishDate = podcast.PublishDate,
                VoiceAddress = podcast.VoiceAddress,
                GroupID = podcast.GroupID
                
            });
            await _context.SaveChangesAsync();
        }
        public async Task EditPodcastByIdAsync(int PodcastId, PodcastModel pm)
        {
            var podcast = await _context.Podcasts.FindAsync(PodcastId);
            podcast.Title=pm.Title;
            podcast.Description=pm.Description;
            podcast.PublishDate= pm.PublishDate;
            podcast.VoiceAddress = pm.VoiceAddress;
            podcast.GroupID = pm.GroupID;
            await _context.SaveChangesAsync();
        }
    }
}

