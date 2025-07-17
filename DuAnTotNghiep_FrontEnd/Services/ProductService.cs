using DuAnTotNghiep_FrontEnd.Models;
using System.Net.Http.Json;

namespace DuAnTotNghiep_FrontEnd.Services
{
	public class ProductService
	{
		private readonly HttpClient _httpClient;

		public ProductService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<ProductViewModel>> GetProducts()
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<List<ProductViewModel>>("api/Product/getproducts");
				if (response.Count != 0)
				{
					return response;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi gọi API: " + ex.Message);
			}
			return [];
		}
		public async Task<List<ProductDetailViewModel>> GetProductDetails(int productId)
		{
			try
			{
				var response = await _httpClient.GetFromJsonAsync<List<ProductDetailViewModel>>($"api/Product/productDetails/{productId}");
				if (response.Count != 0)
				{
					return response;
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
