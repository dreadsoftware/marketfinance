using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications.Interfaces;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Services.Adapters.Base;

namespace SlothEnterprise.ProductApplication.Services.Adapters
{
    public class SelectInvoiceServiceAdapter : BaseServiceAdapter<ISelectInvoiceService, SelectiveInvoiceDiscount>
    {
        public SelectInvoiceServiceAdapter(ISelectInvoiceService adaptee)
            : base(adaptee)
        {
        }

        public override int SubmitApplicationFor(ISellerCompanyData companyData, SelectiveInvoiceDiscount product)
        {
            return _adaptee.SubmitApplicationFor(companyData.Number.ToString(), product.InvoiceAmount, product.AdvancePercentage);
        }
    }
}
