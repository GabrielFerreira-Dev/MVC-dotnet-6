using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models.ViewModels {
    public class SalesFormViewModel {
        public SalesRecord SalesRecord { get; set; }
        public ICollection<Seller>? Sellers { get; set; }
        public SalesStatus SalesStatus { get; set; }
    }
}
