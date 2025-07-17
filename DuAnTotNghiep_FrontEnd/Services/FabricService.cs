using DuAnTotNghiep_FrontEnd.Models;
using System.Net.Http.Json;

namespace DuAnTotNghiep_FrontEnd.Services
{
	public class FabricService
	{
		private readonly HttpClient _httpClient;

		public FabricService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<FabricViewModel>> GetFabrics()
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<APIResponseModel<List<FabricViewModel>>>("api/Fabric/getfabrics");
				if (response.IsSuccess)
				{
					return response.Data;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi gọi API: " + ex.Message);
			}
			return [];
		}
	}
}
