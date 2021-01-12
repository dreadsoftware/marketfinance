using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Services.Adapters.Base;

namespace SlothEnterprise.ProductApplication.Services.Adapters
{
    public class BusinessLoansServiceAdapter : BaseCompanyDataServiceAdapter<IBusinessLoansService, BusinessLoans>
    {
        public BusinessLoansServiceAdapter(IBusinessLoansService adaptee)
            : base(adaptee)
        {
        }

        protected override IApplicationResult SubmitApplicationFor(CompanyDataRequest companyData, BusinessLoans product)
        {
            var loansRequest = new LoansRequest
            {
                InterestRatePerAnnum = product.InterestRatePerAnnum,
                LoanAmount = product.LoanAmount
            };

            return _adaptee.SubmitApplicationFor(companyData, loansRequest);
        }
    }
}
