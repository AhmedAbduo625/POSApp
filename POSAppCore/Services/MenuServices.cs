
using POSAppModels;

namespace POSAppCore
{
	public class MenuServices
	{
		public async Task<MenuDto> GetMenusAsync()
		{
			try
			{
				var content = new MultipartFormDataContent();
				content.Add(new StringContent(IoC.AppSettings.Token), "token");
				content.Add(new StringContent("1"), "op");

				var result = await IoC.RequestHandler.PostRequestWithMultipartContent<MenuDto>("POS/p5api2.php", content);

				return result;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
