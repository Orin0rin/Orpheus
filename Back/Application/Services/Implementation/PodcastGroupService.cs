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
    public class PodcastGroupService : IPodcastGroupService
    {
        private readonly dbDataContext _context;

        public PodcastGroupService(dbDataContext context)
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

        public async Task AddPodcastGroupAsync(PodcastGroupModel pgm)
        {
            await _context.PodcastGroups.AddAsync(new PodcastGroup()
            {
                Name=pgm.Name,
                NumberOfEpisodes=pgm.NumberOfEpisodes,
                Status=pgm.Status,
                ImgAddress=pgm.ImgAddress

            });
            await _context.SaveChangesAsync();
        }
        public async Task EditPodcastGroupByIdAsync(int PodcastGroupId, PodcastGroupModel pgm)
        {
            var podcastGroup = await _context.PodcastGroups.FindAsync(PodcastGroupId);
            podcastGroup.Name = pgm.Name;
            podcastGroup.NumberOfEpisodes = pgm.NumberOfEpisodes;
            podcastGroup.Status = pgm.Status;
            podcastGroup.ImgAddress = pgm.ImgAddress;

            
            await _context.SaveChangesAsync();
        }
    }
}
