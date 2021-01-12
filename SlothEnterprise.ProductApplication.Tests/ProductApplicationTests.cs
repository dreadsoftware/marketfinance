using System;
using FluentAssertions;
using Moq;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications.Interfaces;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Products.Interfaces;
using SlothEnterprise.ProductApplication.Services.Adapters;
using SlothEnterprise.ProductApplication.Services.Adapters.Interfaces;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        private const int ResultId = 1;

        private readonly IProductApplicationService _sut;
        private readonly Mock<IServiceProvider> _serviceProviderMock = new Mock<IServiceProvider>();
        private readonly Mock<IBusinessLoansService> _businessLoansServiceMock = new Mock<IBusinessLoansService>();
        private readonly Mock<IConfidentialInvoiceService> _confidentialInvoiceServiceMock = new Mock<IConfidentialInvoiceService>();
        private readonly Mock<ISelectInvoiceService> _selectInvoiceServiceMock = new Mock<ISelectInvoiceService>();
        private readonly Mock<IApplicationResult> _result = new Mock<IApplicationResult>();
        private readonly BusinessLoansServiceAdapter _businessLoansServiceAdapter;
        private readonly ConfidentialInvoiceServiceAdapter _confidentialInvoiceServiceAdapter;
        private readonly SelectInvoiceServiceAdapter _selectInvoiceServiceAdapter;

        public ProductApplicationTests()
        {
            _sut = new ProductApplicationService(_serviceProviderMock.Object);

            _businessLoansServiceMock.Setup(m => m.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), It.IsAny<LoansRequest>())).Returns(_result.Object);
            _confidentialInvoiceServiceMock.Setup(m => m.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(_result.Object);
            _selectInvoiceServiceMock.Setup(m => m.SubmitApplicationFor(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(ResultId);

            _businessLoansServiceAdapter = new BusinessLoansServiceAdapter(_businessLoansServiceMock.Object);
            _confidentialInvoiceServiceAdapter = new ConfidentialInvoiceServiceAdapter(_confidentialInvoiceServiceMock.Object);
            _selectInvoiceServiceAdapter = new SelectInvoiceServiceAdapter(_selectInvoiceServiceMock.Object);

            _serviceProviderMock.Setup(m => m.GetService(typeof(IServiceAdapter<BusinessLoans>))).Returns(_businessLoansServiceAdapter);
            _serviceProviderMock.Setup(m => m.GetService(typeof(IServiceAdapter<ConfidentialInvoiceDiscount>))).Returns(_confidentialInvoiceServiceAdapter);
            _serviceProviderMock.Setup(m => m.GetService(typeof(IServiceAdapter<SelectiveInvoiceDiscount>))).Returns(_selectInvoiceServiceAdapter);

            _result.SetupProperty(p => p.ApplicationId, ResultId);
            _result.SetupProperty(p => p.Success, true);
        }

        [Obsolete]
        [Theory]
        [MemberData(nameof(ProductApplicationTestsData.GetApplications), MemberType = typeof(ProductApplicationTestsData))]
        public void ProductApplicationService_SubmitApplicationFor_Obsolete_ShouldReturnOne(ISellerApplication application)
        {
            var result = _sut.SubmitApplicationFor(application);

            result.Should().Be(ResultId);
        }

        [Theory]
        [MemberData(nameof(ProductApplicationTestsData.GetGenericApplications), MemberType = typeof(ProductApplicationTestsData))]
        public void ProductApplicationService_SubmitApplicationFor_Generic_ShouldReturnOne<TProduct>(ISellerApplication<TProduct> application)
            where TProduct : IProduct
        {
            var result = _sut.SubmitApplicationFor(application);

            result.Should().Be(ResultId);
        }
    }
}
