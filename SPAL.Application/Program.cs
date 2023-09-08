using Microsoft.Extensions.DependencyInjection;
using SPAL.Application.Brokers;
using SPAL.Application.Services;
using SPAL.Core.Extensions;
using SPAL.ImplementationX.Extensions;
using SPAL.ImplementationY.Extensions;
using System;

internal class Program
	{
	/// <summary>
	/// Just invoke one specific implementation. In this case X.
	/// </summary>
	private static void DoImplementationX()
		{
		var services = new ServiceCollection();

		services
			.AddScoped<ISPALBroker, SPALBroker>()
			.AddScoped<ISPALService, SPALService>();

		services
			.AddSPALClient()
			.UseImplementationX();

		IServiceProvider serviceProvider = services.BuildServiceProvider();

		using IServiceScope scope = serviceProvider.CreateScope();
		string value = scope.ServiceProvider.GetService<ISPALService>().GetString();

		Console.WriteLine($"Value for only implementation X: " + value);
		}

	/// <summary>
	/// Just invoke one specific implementation. In this case Y.
	/// </summary>
	private static void DoImplementationY()
		{
		var services = new ServiceCollection();

		services
			.AddScoped<ISPALBroker, SPALBroker>()
			.AddScoped<ISPALService, SPALService>();

		services
			.AddSPALClient()
			.UseImplementationY();

		IServiceProvider serviceProvider = services.BuildServiceProvider();

		using IServiceScope scope = serviceProvider.CreateScope();
		string value = scope.ServiceProvider.GetService<ISPALService>().GetString();

		Console.WriteLine($"Value for only implementation Y: " + value);
		}

	/// <summary>
	/// Invoke implementation X or Y based on some business rule.
	/// For example, imagine two external systems which realizes the same functionality
	/// but are developed by different companies. Each implementation deals with its own
	/// external models and the convert them into a local model.
	/// From a constant, value or whatever we could invoke/use one library or another without
	/// too much changes.
	/// </summary>
	private static void DoImplementationXorY()
		{
		var services = new ServiceCollection();

		services
			.AddScoped<ISPALBroker, SPALBroker>()
			.AddScoped<ISPALService, SPALService>();

		services
			.AddSPALClient()
			.UseImplementationX("X")
			.UseImplementationY("Y");

		IServiceProvider serviceProvider = services.BuildServiceProvider();

		using IServiceScope scope = serviceProvider.CreateScope();
		string value = scope.ServiceProvider.GetService<ISPALService>().GetStringWithProviderId("X");
		Console.WriteLine($"Value selected from implementation X: " + value);

		value = scope.ServiceProvider.GetService<ISPALService>().GetStringWithProviderId("Y");	
		Console.WriteLine($"Value selected from implementation Y: " + value);
		}

	private static void Main(string[] args)
		{
		DoImplementationX();
		DoImplementationY();
		DoImplementationXorY();
		}
	}