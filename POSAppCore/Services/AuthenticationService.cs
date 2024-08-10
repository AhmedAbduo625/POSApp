
using POSAppModels;

namespace POSAppCore
{
	public class AuthenticationService
	{
        public async Task<string> Login(string email, string password)
        {
			try
			{
				var content = new MultipartFormDataContent();
				content.Add(new StringContent(email), "U");
				content.Add(new StringContent(password), "P");
				content.Add(new StringContent(""), "D");
				content.Add(new StringContent("0"), "lang");

				var result = await IoC.RequestHandler.PostRequestWithMultipartContent<UserLoginResponseDto>("POS/p5api2.php", content);

				return result.Token;
			}
			catch (Exception ex)
			{
				throw;
			}
        }

    }
}
