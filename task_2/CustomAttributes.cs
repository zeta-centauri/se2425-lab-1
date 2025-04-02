using System;

namespace task_2
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CompanyInfoAttribute : Attribute
    {
        public string CompanyName { get; }
        public string Country { get; }

        public CompanyInfoAttribute(string companyName, string country)
        {
            CompanyName = companyName;
            Country = country;
        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class SecretInfoAttribute : Attribute
    {
        public string Description { get; }
        public int SecurityLevel { get; }

        public SecretInfoAttribute(string description, int securityLevel)
        {
            Description = description;
            SecurityLevel = securityLevel;
        }
    }
}
