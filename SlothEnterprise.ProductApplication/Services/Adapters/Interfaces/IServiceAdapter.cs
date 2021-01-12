using SlothEnterprise.ProductApplication.Applications.Interfaces;
using SlothEnterprise.ProductApplication.Products.Interfaces;

namespace SlothEnterprise.ProductApplication.Services.Adapters.Interfaces
{
    public interface IServiceAdapter<TProduct>
        where TProduct : IProduct
    {
        int SubmitApplicationFor(ISellerCompanyData companyData, TProduct product);
    }
}
