using System;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Applications.Interfaces;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Products.Interfaces;
using SlothEnterprise.ProductApplication.Services.Adapters.Interfaces;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IServiceProvider _serviceProvider;

        public ProductApplicationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [Obsolete]
        public int SubmitApplicationFor(ISellerApplication application)
        {
            if (application.Product is BusinessLoans bl)
            {
                return SubmitApplicationFor(new SellerApplication<BusinessLoans>
                {
                    CompanyData = application.CompanyData,
                    Product = bl,
                });
            }

            if (application.Product is ConfidentialInvoiceDiscount cid)
            {
                return SubmitApplicationFor(new SellerApplication<ConfidentialInvoiceDiscount>
                {
                    CompanyData = application.CompanyData,
                    Product = cid,
                });
            }

            if (application.Product is SelectiveInvoiceDiscount sid)
            {
                return SubmitApplicationFor(new SellerApplication<SelectiveInvoiceDiscount>
                {
                    CompanyData = application.CompanyData,
                    Product = sid,
                });
            }

            throw new InvalidOperationException();
        }

        public int SubmitApplicationFor<TProduct>(ISellerApplication<TProduct> application)
            where TProduct : IProduct
        {
            var service = (IServiceAdapter<TProduct>)_serviceProvider.GetService(typeof(IServiceAdapter<TProduct>));

            if (service == null)
            {
                throw new InvalidOperationException();
            }

            return service.SubmitApplicationFor(application.CompanyData, application.Product);
        }
    }
}
