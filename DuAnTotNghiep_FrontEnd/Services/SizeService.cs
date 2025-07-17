using DuAnTotNghiep_FrontEnd.Models;
using System.Net.Http.Json;

namespace DuAnTotNghiep_FrontEnd.Services
{
	public class SizeService
	{
		private readonly HttpClient _httpClient;

		public SizeService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<SizeViewModel>> GetSizes()
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<APIResponseModel<List<SizeViewModel>>>("api/Size/getsizes");
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
