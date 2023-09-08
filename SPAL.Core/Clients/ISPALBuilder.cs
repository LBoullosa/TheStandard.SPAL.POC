using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SPAL.Core.Models;

namespace SPAL.Core.Extensions
{
    public interface ISPALBuilder
		{
		IServiceCollection Services { get; }
		OptionsBuilder<ProvidersOptions> ProvidersOptionsBuilder { get; }
		}
	}
