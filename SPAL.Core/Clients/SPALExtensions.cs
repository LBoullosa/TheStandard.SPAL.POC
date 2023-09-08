using Microsoft.Extensions.DependencyInjection;
using SPAL.Core.Clients;
using SPAL.Core.Models;
using System;

namespace SPAL.Core.Extensions
	{
	public static class SPALExtensions
		{
		private static TSPALBuilder AddProviderConfiguration<TSPALBuilder, TSPALClientProvider, TProviderOption>(
				this TSPALBuilder builder,
				string id)
			where TSPALBuilder : ISPALBuilder
			where TSPALClientProvider : ISPALClientProvider
			where TProviderOption : ProviderOption, new()
			{
			builder.ProvidersOptionsBuilder.Configure<TProviderOption>((providersOptions, providerOption) =>
				{
				providersOptions.Providers.Add(providerOption);
				});

			var constructorOpcionesApi = builder.Services
				.Configure<TProviderOption>(a =>
					{
					});

			builder.Services
				.AddSingleton<TProviderOption>(proveedorServicios =>
					{
					return new TProviderOption
						{
						Id = id,
						ProviderType = typeof(TSPALClientProvider)
						};
					});

			return builder;
			}

		public static ISPALBuilder AddSPALClient(this IServiceCollection services)
			{
			services.AddScoped<ISPALClient, SPALClient>();

			var providersOptionsBuilder = services
				.AddOptions<ProvidersOptions>()
				.Configure(opciones =>
					{
					});

			return new SPALBuilder(services, providersOptionsBuilder);
			}

		public static ISPALBuilder AddClientProvider<TSPALClientProvider, TProviderOption>(
				this ISPALBuilder builder,
				string id)
			where TSPALClientProvider : ISPALClientProvider
			where TProviderOption : ProviderOption, new()
			{
			if (builder == null)
				throw new ArgumentException(nameof(builder));

			builder.AddProviderConfiguration<ISPALBuilder, TSPALClientProvider, TProviderOption>(id);

			return builder;
			}
		}
	}
