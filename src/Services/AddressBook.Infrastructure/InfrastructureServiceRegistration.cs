using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AddressBook.Infrastructure.Persistence;
using AddressBook.Application.Contracts;
using AddressBook.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(
			this IServiceCollection services,
			IConfiguration configuration
			)
		{
			services.AddDbContext<AddressBookContext>(options =>
			{
				options.UseSqlServer(
					configuration.GetConnectionString("AddressBookConnectionString")
					);
			});

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IContactRepository, ContactRepository>();

            return services;
		}
	}
}

