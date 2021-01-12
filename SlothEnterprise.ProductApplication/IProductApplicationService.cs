using System;
using SlothEnterprise.ProductApplication.Applications.Interfaces;
using SlothEnterprise.ProductApplication.Products.Interfaces;

namespace SlothEnterprise.ProductApplication
{
    public interface IProductApplicationService
    {
        [Obsolete("For Backwards compatibility, use generic SubmitApplicationFor.")]
        int SubmitApplicationFor(ISellerApplication application);

        int SubmitApplicationFor<TProduct>(ISellerApplication<TProduct> application)
            where TProduct : IProduct;
    }
}
