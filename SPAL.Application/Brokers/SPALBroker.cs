using SPAL.Core.Clients;

namespace SPAL.Application.Brokers
{
    public class SPALBroker : ISPALBroker
		{
		private readonly ISPALClient spalClient;

		public SPALBroker(ISPALClient spalClient) =>
			this.spalClient = spalClient;

		public string GetString(string providerId) =>
			spalClient.GetString(providerId);
		}
	}
