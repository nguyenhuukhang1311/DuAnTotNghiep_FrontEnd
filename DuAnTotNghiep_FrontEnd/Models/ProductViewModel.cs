﻿namespace DuAnTotNghiep_FrontEnd.Models
{
	public class ProductViewModel
	{
		public int ProductId { get; set; }
		public string? ProductName { get; set; }
		public string? Description { get; set; }
		public string? CategoryProduct { get; set; }
		public string? Status { get; set; }
		public string? Thumbnail { get; set; }
		public ICollection<ProductDetailViewModel>? ProductDetails { get; set; }
	}
}
