using System.Collections.Generic;
using Moq;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Applications.Interfaces;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Tests
{
    class ProductApplicationTestsData
    {
        private static readonly SellerCompanyData _sellerCompanyData = new SellerCompanyData();
        private static readonly BusinessLoans _businessLoansProduct = new BusinessLoans();
        private static readonly ConfidentialInvoiceDiscount _confidentialInvoiceDiscountProduct = new ConfidentialInvoiceDiscount();
        private static readonly SelectiveInvoiceDiscount _selectiveInvoiceDiscountProduct = new SelectiveInvoiceDiscount();
        private static readonly Mock<ISellerApplication> _businessLoansApplication = new Mock<ISellerApplication>();
        private static readonly Mock<ISellerApplication> _confidentialInvoiceDiscountApplication = new Mock<ISellerApplication>();
        private static readonly Mock<ISellerApplication> _selectiveInvoiceDiscountApplication = new Mock<ISellerApplication>();
        private static readonly Mock<ISellerApplication<BusinessLoans>> _businessLoansGenericApplication = new Mock<ISellerApplication<BusinessLoans>>();
        private static readonly Mock<ISellerApplication<ConfidentialInvoiceDiscount>> _confidentialInvoiceDiscountGenericApplication = new Mock<ISellerApplication<ConfidentialInvoiceDiscount>>();
        private static readonly Mock<ISellerApplication<SelectiveInvoiceDiscount>> _selectiveInvoiceDiscountGenericApplication = new Mock<ISellerApplication<SelectiveInvoiceDiscount>>();

        static ProductApplicationTestsData()
        {
            _businessLoansApplication.SetupProperty(p => p.Product, _businessLoansProduct);
            _businessLoansApplication.SetupProperty(p => p.CompanyData, _sellerCompanyData);
            _confidentialInvoiceDiscountApplication.SetupProperty(p => p.Product, _confidentialInvoiceDiscountProduct);
            _confidentialInvoiceDiscountApplication.SetupProperty(p => p.CompanyData, _sellerCompanyData);
            _selectiveInvoiceDiscountApplication.SetupProperty(p => p.Product, _selectiveInvoiceDiscountProduct);
            _selectiveInvoiceDiscountApplication.SetupProperty(p => p.CompanyData, _sellerCompanyData);
            _businessLoansGenericApplication.SetupProperty(p => p.Product, _businessLoansProduct);
            _businessLoansGenericApplication.SetupProperty(p => p.CompanyData, _sellerCompanyData);
            _confidentialInvoiceDiscountGenericApplication.SetupProperty(p => p.Product, _confidentialInvoiceDiscountProduct);
            _confidentialInvoiceDiscountGenericApplication.SetupProperty(p => p.CompanyData, _sellerCompanyData);
            _selectiveInvoiceDiscountGenericApplication.SetupProperty(p => p.Product, _selectiveInvoiceDiscountProduct);
            _selectiveInvoiceDiscountGenericApplication.SetupProperty(p => p.CompanyData, _sellerCompanyData);
        }

        public static IEnumerable<object[]> GetApplications()
        {
            yield return new object[] { _businessLoansApplication.Object };
            yield return new object[] { _confidentialInvoiceDiscountApplication.Object };
            yield return new object[] { _selectiveInvoiceDiscountApplication.Object };
        }

        public static IEnumerable<object[]> GetGenericApplications()
        {
            yield return new object[] { _businessLoansGenericApplication.Object };
            yield return new object[] { _confidentialInvoiceDiscountGenericApplication.Object };
            yield return new object[] { _selectiveInvoiceDiscountGenericApplication.Object };
        }
    }
}
