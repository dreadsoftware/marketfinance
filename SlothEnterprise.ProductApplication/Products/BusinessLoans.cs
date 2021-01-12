using SlothEnterprise.ProductApplication.Products.Base;

namespace SlothEnterprise.ProductApplication.Products
{
    public class BusinessLoans : BaseProduct
    {
        /// <summary>
        /// Per annum interest rate
        /// </summary>
        public decimal InterestRatePerAnnum { get; set; }

        /// <summary>
        /// Total available amount to withdraw
        /// </summary>
        public decimal LoanAmount { get; set; }
    }
}
