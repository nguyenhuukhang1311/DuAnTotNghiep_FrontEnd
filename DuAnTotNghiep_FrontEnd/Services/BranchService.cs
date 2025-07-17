using DuAnTotNghiep_FrontEnd.Models;
using System.Net.Http.Json;

namespace DuAnTotNghiep_FrontEnd.Services
{
	public class BranchService
	{
		private readonly HttpClient _httpClient;
		public BranchService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<BranchViewModel>> GetBranches()
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<APIResponseModel<List<BranchViewModel>>>("api/Branch/getbranches");
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
