
using System.Net.Http.Json;
using System.Net.Http;

namespace POSAppCore
{
	public class RequestHandler
	{
		private async Task<T?> DataDeserialization<T>(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<T>();
				return result;
			}
			else
			{
				var message = await response.Content.ReadAsStringAsync();
				throw new Exception(message);
			}
		}

		public async Task<T?> DeleteRequest<T>(string Uri)
		{
			var response = await IoC.HttpClient.DeleteAsync(Uri);
			return await DataDeserialization<T>(response);
		}

		public async Task<T?> GetRequest<T>(string Uri)
		{
			var response = await IoC.HttpClient.GetAsync(Uri);
			return await DataDeserialization<T>(response);
		}

		public async Task<T?> PatchRequest<T>(string Uri, T dto)
		{
			throw new NotImplementedException();
		}

		public async Task<T1?> PostRequest<T1, T2>(string Uri, T2 dto)
		{
			var response = await IoC.HttpClient.PostAsJsonAsync<T2>(Uri, dto);
			return await DataDeserialization<T1>(response);
		}

		public async Task<T1?> PutRequest<T1, T2>(string Uri, T2 dto)
		{
			var response = await IoC.HttpClient.PutAsJsonAsync<T2>(Uri, dto);
			return await DataDeserialization<T1>(response);
		}

		public async Task<T1?> PostRequestWithMultipartContent<T1>(string Uri, MultipartFormDataContent form)
		{
			var response = await IoC.HttpClient.PostAsync(Uri, form);
			return await DataDeserialization<T1>(response);
		}
	}
}
