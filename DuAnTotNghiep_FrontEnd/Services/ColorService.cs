using DuAnTotNghiep_FrontEnd.Models;
using System.Net.Http.Json;

namespace DuAnTotNghiep_FrontEnd.Services
{
	public class ColorService
	{
		private readonly HttpClient _httpClient;

		public ColorService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<ColorViewModel>> GetColors()
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<APIResponseModel<List<ColorViewModel>>>("api/Color/getcolors");
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
