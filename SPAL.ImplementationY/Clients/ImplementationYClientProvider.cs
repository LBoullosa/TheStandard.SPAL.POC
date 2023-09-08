using SPAL.ImplementationY.Services;

namespace SPAL.ImplementationY.Clients
	{
	public class ImplementationYClientProvider : IImplementationYClientProvider
		{
		private readonly IYService yService;

		public ImplementationYClientProvider(IYService yService) =>
			this.yService = yService;

		public string GetString() =>
			yService.GetString();
		}
	}
