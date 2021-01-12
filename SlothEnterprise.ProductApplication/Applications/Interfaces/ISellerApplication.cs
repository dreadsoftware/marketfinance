using System;
using SlothEnterprise.ProductApplication.Products.Interfaces;

namespace SlothEnterprise.ProductApplication.Applications.Interfaces
{
    public interface ISellerApplication<TProduct>
        where TProduct : IProduct
    {
        TProduct Product { get; set; }
        ISellerCompanyData CompanyData { get; set; }
    }

    [Obsolete("For Backwards compatibility, use generic ISellerApplication<TProduct>.")]
    public interface ISellerApplication : ISellerApplication<IProduct>
    {
    }
}
