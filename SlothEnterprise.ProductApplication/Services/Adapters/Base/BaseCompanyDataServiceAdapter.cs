using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications.Interfaces;
using SlothEnterprise.ProductApplication.Products.Interfaces;

namespace SlothEnterprise.ProductApplication.Services.Adapters.Base
{
    public abstract class BaseCompanyDataServiceAdapter<TAdaptee, TProduct> : BaseServiceAdapter<TAdaptee, TProduct>
        where TProduct : IProduct
    {
        protected abstract IApplicationResult SubmitApplicationFor(CompanyDataRequest companyData, TProduct product);

        protected BaseCompanyDataServiceAdapter(TAdaptee adaptee)
            : base(adaptee)
        {
        }

        public override int SubmitApplicationFor(ISellerCompanyData companyData, TProduct product)
        {
            var companyDataRequest = new CompanyDataRequest
            {
                CompanyFounded = companyData.Founded,
                CompanyNumber = companyData.Number,
                CompanyName = companyData.Name,
                DirectorName = companyData.DirectorName
            };

            var result = SubmitApplicationFor(companyDataRequest, product);

            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }
    }
}
