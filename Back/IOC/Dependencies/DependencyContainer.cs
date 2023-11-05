using Application.Senders.Mail;
using Application.Services.Implementation;
using Application.Services.Interfaces;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Dependencies
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Service
            services.AddScoped<IPodcastService, PodcastService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPodcastGroupService, PodcastGroupService>();
            services.AddScoped<ISendMail, SendMail>();
            #endregion

            #region Repository
            services.AddScoped<IPodcastRepository, PodcastRepository>();
            services.AddScoped<IPodcastGroupRepository, PodcastGroupRepository>();
            #endregion
        }
    }
}
