using DuAnTotNghiep_FrontEnd.DTOs;
using DuAnTotNghiep_FrontEnd.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace DuAnTotNghiep_FrontEnd.Services
{
	public class OutputReceiptService
	{
		private readonly HttpClient _httpClient;

		public OutputReceiptService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<OutputReceiptViewModel>?> GetAllInputReceiptsAsync()
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<APIResponseModel<List<OutputReceiptViewModel>>>("api/OutputReceipt/getreceipts");
				if (response?.IsSuccess == true)
				{
					return response.Data;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi gọi API: " + ex.Message);
			}
			return null;
		}
		public async Task<bool> CancelReceiptAsync(int id)
		{
			var response = await _httpClient.PutAsync($"api/OutputReceipt/cancel/{id}", null);

			if (response.IsSuccessStatusCode)
			{
				return true;
			}

			// Optional: Log or process error response
			return false;
		}
		public async Task<bool> ConfirmReceiptAsync(int id)
		{
			var response = await _httpClient.PutAsync($"api/OutputReceipt/confirm/{id}", null);
			return response.IsSuccessStatusCode;
		}
		public async Task<APIResponseModel<object>> CreateReceiptAsync(List<CreateReceiptDetailDTO> detailDTOs, string managerId,int? branchId)
		{
			var query = $"?branchId={branchId}&managerId={managerId}";
			var response = await _httpClient.PostAsJsonAsync($"/api/OutputReceipt/create{query}", detailDTOs);

			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<APIResponseModel<object>>();
				return result!;
			}
			else
			{
				var error = await response.Content.ReadFromJsonAsync<APIResponseModel<object>>();
				return error ?? new APIResponseModel<object>(false, "Lỗi không xác định", null, (int)response.StatusCode);
			}
		}
	}
}
