using DuAnTotNghiep_FrontEnd.DTOs;
using DuAnTotNghiep_FrontEnd.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace DuAnTotNghiep_FrontEnd.Services
{
	public class InputReceiptService
	{
		private readonly HttpClient _httpClient;

		public InputReceiptService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<InputReceiptViewModel>?> GetAllInputReceiptsAsync()
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<APIResponseModel<List<InputReceiptViewModel>>>("api/InputReceipt/getreceipts");
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
		public async Task<APIResponseModel<object>> CreateReceiptAsync(List<CreateReceiptDetailDTO> detailDTOs, string managerId)
		{
			var url = $"api/InputReceipt/create?ManagerId={Uri.EscapeDataString(managerId)}";

			var response = await _httpClient.PostAsJsonAsync(url, detailDTOs);

			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<APIResponseModel<object>>();
				return result ?? new APIResponseModel<object>(false, "Không đọc được dữ liệu phản hồi", null, 500);
			}
			else
			{
				var errorContent = await response.Content.ReadAsStringAsync();
				return new APIResponseModel<object>(false, $"Lỗi API: {errorContent}", null, (int)response.StatusCode);
			}
		}
		public async Task<bool> CancelReceiptAsync(int id)
		{
			var response = await _httpClient.PutAsync($"api/InputReceipt/cancel/{id}", null);

			if (response.IsSuccessStatusCode)
			{
				return true;
			}

			// Optional: Log or process error response
			return false;
		}
		public async Task<bool> ConfirmReceiptAsync(int id)
		{
			var response = await _httpClient.PutAsync($"api/InputReceipt/confirm/{id}", null);
			return response.IsSuccessStatusCode;
		}
	}
}
