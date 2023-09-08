using SPAL.ImplementationX.Services;

namespace SPAL.ImplementationX.Clients
	{
	internal class ImplementationXClientProvider : IImplementationXClientProvider
		{
		private readonly IXService xService;

		public ImplementationXClientProvider(IXService xService) =>
			this.xService = xService;

		public string GetString() =>
			xService.GetString();
		}
	}
