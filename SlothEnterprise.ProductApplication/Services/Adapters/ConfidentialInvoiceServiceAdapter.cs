using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Services.Adapters.Base;

namespace SlothEnterprise.ProductApplication.Services.Adapters
{
    public class ConfidentialInvoiceServiceAdapter : BaseCompanyDataServiceAdapter<IConfidentialInvoiceService, ConfidentialInvoiceDiscount>
    {
        public ConfidentialInvoiceServiceAdapter(IConfidentialInvoiceService adaptee)
            : base(adaptee)
        {
        }

        protected override IApplicationResult SubmitApplicationFor(CompanyDataRequest companyData, ConfidentialInvoiceDiscount product)
        {
            return _adaptee.SubmitApplicationFor(companyData, product.TotalLedgerNetworth, product.AdvancePercentage, product.VatRate);
        }
    }
}
