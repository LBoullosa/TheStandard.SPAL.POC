using SPAL.Application.Brokers;

namespace SPAL.Application.Services
	{
	internal class SPALService : ISPALService
		{
		private readonly ISPALBroker spalBroker;

		public SPALService(ISPALBroker spalBroker) =>
			this.spalBroker = spalBroker;

		public string GetString() =>
			spalBroker.GetString(null);

		public string GetStringWithProviderId(string providerId) =>
			spalBroker.GetString(providerId);
		}
	}
