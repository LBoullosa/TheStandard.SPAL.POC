using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SPAL.Core.Models;

namespace SPAL.Core.Extensions
	{
	public class SPALBuilder : ISPALBuilder
		{
		private readonly IServiceCollection services;
		private readonly OptionsBuilder<ProvidersOptions> providersOptionsBuilder;

		public IServiceCollection Services { get => services; }
		public OptionsBuilder<ProvidersOptions> ProvidersOptionsBuilder { get => providersOptionsBuilder; }

		public SPALBuilder(IServiceCollection services, OptionsBuilder<ProvidersOptions> providersOptionsBuilder)
			{
			this.services = services;
			this.providersOptionsBuilder = providersOptionsBuilder;
			}
		}
	}
