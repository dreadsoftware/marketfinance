using SlothEnterprise.ProductApplication.Products.Base;
using SlothEnterprise.ProductApplication.Products.Helpers;

namespace SlothEnterprise.ProductApplication.Products
{
    public class ConfidentialInvoiceDiscount : BaseProduct
    {
        public decimal TotalLedgerNetworth { get; set; }

        public decimal AdvancePercentage { get; set; }

        public decimal VatRate { get; set; } = VatRates.UkVatRate;
    }
}
