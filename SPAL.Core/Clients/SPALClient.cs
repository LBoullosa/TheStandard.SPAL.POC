using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SPAL.Core.Models;
using System;
using System.Linq;

namespace SPAL.Core.Clients
	{
	public class SPALClient : ISPALClient
		{
		private readonly IServiceProvider serviceProvider = null;
		private readonly ProvidersOptions providersOptions;

		public SPALClient(IServiceProvider serviceProvider, IOptions<ProvidersOptions> providersOptions)
			{
			this.serviceProvider = serviceProvider;
			this.providersOptions = providersOptions.Value;
			}

		private ISPALClientProvider GetSPALClientProvider(string providerId)
			{
			Type providerType = string.IsNullOrEmpty(providerId)
				? providersOptions.Providers.Single().ProviderType
				: providersOptions.Providers
					.Where(provider => provider.Id == providerId)
					.Single()
					.ProviderType;

			if (providerType == null)
				throw new NotImplementedException();

			ISPALClientProvider spalClientProvider =
				serviceProvider.GetRequiredService(providerType) as ISPALClientProvider;

			return spalClientProvider;
			}

		public string GetString(string providerId) =>
			GetSPALClientProvider(providerId).GetString();
		}
	}
