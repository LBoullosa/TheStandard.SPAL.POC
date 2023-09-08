using Microsoft.Extensions.DependencyInjection;
using SPAL.Core.Extensions;
using SPAL.ImplementationY.Clients;
using SPAL.ImplementationY.Models.Clients;
using SPAL.ImplementationY.Services;

namespace SPAL.ImplementationY.Extensions
{
    public static class ImplementationYExtensions
		{
		public static ISPALBuilder UseImplementationY(
				this ISPALBuilder builder,
				string id = "implementationY")
			{
			builder.Services.AddScoped<IImplementationYClientProvider, ImplementationYClientProvider>();
			builder.Services.AddScoped<IYService, YService>();

			builder.AddClientProvider<IImplementationYClientProvider, ImplementationYProviderOption>(id);


			return builder;
			}
		}
	}
