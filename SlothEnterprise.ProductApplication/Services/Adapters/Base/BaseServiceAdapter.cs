using SlothEnterprise.ProductApplication.Applications.Interfaces;
using SlothEnterprise.ProductApplication.Products.Interfaces;
using SlothEnterprise.ProductApplication.Services.Adapters.Interfaces;

namespace SlothEnterprise.ProductApplication.Services.Adapters.Base
{
    public abstract class BaseServiceAdapter<TAdaptee, TProduct> : IServiceAdapter<TProduct>
        where TProduct : IProduct
    {
        protected readonly TAdaptee _adaptee;

        public abstract int SubmitApplicationFor(ISellerCompanyData companyData, TProduct product);

        public BaseServiceAdapter(TAdaptee adaptee)
        {
            _adaptee = adaptee;
        }
    }
}
