namespace DuAnTotNghiep_FrontEnd.Models
{
	public class BranchViewModel
	{
		public int BranchId { get; set; }
		public string? Address { get; set; }
		public string? ManagerName { get; set; }
		public ICollection<ProductDetailViewModel>? BranchDetails { get; set; }
	}
}
