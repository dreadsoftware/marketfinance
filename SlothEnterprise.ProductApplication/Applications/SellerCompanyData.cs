using System;
using SlothEnterprise.ProductApplication.Applications.Interfaces;

namespace SlothEnterprise.ProductApplication.Applications
{
    public class SellerCompanyData : ISellerCompanyData
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string DirectorName { get; set; }
        public DateTime Founded { get; set; }
    }
}
