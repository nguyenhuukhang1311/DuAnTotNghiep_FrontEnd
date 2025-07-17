namespace DuAnTotNghiep_FrontEnd.Models
{
	public class APIResponseModel<T>
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public T? Data { get; set; }
		public int StatusCode { get; set; }
		public List<string>? Errors { get; set; }
		public APIResponseModel(bool isSuccess, string message, T? data, int statusCode, List<string>? errors = null)
		{
			IsSuccess = isSuccess;
			Message = message;
			Data = data;
			StatusCode = statusCode;
			Errors = errors;
		}
	}
}
