using SlothEnterprise.ProductApplication.Applications.Interfaces;
using SlothEnterprise.ProductApplication.Products.Interfaces;

namespace SlothEnterprise.ProductApplication.Applications
{
    public class SellerApplication<TProduct> : ISellerApplication<TProduct>
        where TProduct : IProduct
    {
        public TProduct Product { get; set; }
        public ISellerCompanyData CompanyData { get; set; }
    }
}
