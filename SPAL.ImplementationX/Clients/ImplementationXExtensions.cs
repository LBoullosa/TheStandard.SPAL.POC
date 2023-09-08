using Microsoft.Extensions.DependencyInjection;
using SPAL.Core.Extensions;
using SPAL.ImplementationX.Clients;
using SPAL.ImplementationX.Models.Clients;
using SPAL.ImplementationX.Services;

namespace SPAL.ImplementationX.Extensions
{
    public static class ImplementationXExtensions
		{
		public static ISPALBuilder UseImplementationX(
				this ISPALBuilder builder,
				string id = "implementationX")
			{
			builder.Services.AddScoped<IImplementationXClientProvider, ImplementationXClientProvider>();
			builder.Services.AddScoped<IXService, XService>();

			builder.AddClientProvider<IImplementationXClientProvider, ImplementationXProviderOption>(id);


			return builder;
			}
		}
	}
