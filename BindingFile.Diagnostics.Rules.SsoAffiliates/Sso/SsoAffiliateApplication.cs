using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EnterpriseSingleSignOn.Interop;

namespace BindingFile.Diagnostics.Rules.SsoAffiliates
{
    public class SSOAffiliateApplication
    {
        public string Application { get; private set; }
        public string Description { get; private set; }
        public string ContactInfo { get; private set; }
        public string[] UserAccounts { get; private set; }
        public string[] AdminAccounts { get; private set; }
        public int Flags { get; private set; }

        public SSOAffiliateApplication(string application, string description, string contactInfo, string userAccounts, string adminAccounts, int flags)
        {
            this.Application = application;
            this.Description = description;
            this.ContactInfo = contactInfo;
            this.UserAccounts = userAccounts.Split(',');
            this.AdminAccounts = adminAccounts.Split(',');
            this.Flags = flags;
        }
    }

    public class SSOAffiliateApplications
    {
        private struct SSOApplicationsStructure
        {
            public string[] Applications;
            public string[] Descriptions;
            public string[] ContactInfos;
            public string[] UserAccounts;
            public string[] AdminAccounts;
            public int[] Flags;
        }

        private List<SSOAffiliateApplication> _applications = null;

        public IEnumerable<SSOAffiliateApplication> Appliations
        {
            get
            {
                if (_applications == null)
                {
                    _applications = GetSSOApplicationList();
                }
                return _applications;
            }
        }

        private List<SSOAffiliateApplication> GetSSOApplicationList()
        {
            List<SSOAffiliateApplication> applicationList = new List<SSOAffiliateApplication>();
            SSOApplicationsStructure ssoApplicationsStructure = new SSOApplicationsStructure();

            ISSOMapper2 ssoMapper = (Microsoft.EnterpriseSingleSignOn.Interop.ISSOMapper2)new Microsoft.EnterpriseSingleSignOn.Interop.SSOMapper();
            ssoMapper.GetApplications2(out ssoApplicationsStructure.Applications,
                out ssoApplicationsStructure.Descriptions,
                out ssoApplicationsStructure.ContactInfos,
                out ssoApplicationsStructure.UserAccounts,
                out ssoApplicationsStructure.AdminAccounts,
                out ssoApplicationsStructure.Flags);

            for (int i = 0; i < ssoApplicationsStructure.Applications.Length; i++)
            {
                SSOAffiliateApplication ssoApplication = new SSOAffiliateApplication(ssoApplicationsStructure.Applications[i],
                    ssoApplicationsStructure.Descriptions[i],
                    ssoApplicationsStructure.ContactInfos[i],
                    ssoApplicationsStructure.UserAccounts[i],
                    ssoApplicationsStructure.AdminAccounts[i],
                    ssoApplicationsStructure.Flags[i]);

                applicationList.Add(ssoApplication);
            }

            return applicationList;
        }


        //public Dictionary<string, string> GetCredentials(string applicationName, string domain, string user, string pwd)
        //{
        //    Dictionary<string, string> fields = new Dictionary<string, string>();
        //    if (applicationName != Constants._SSO_AFFILIATE_ROOT_NODE)
        //    {
        //        if (string.IsNullOrEmpty(domain) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pwd))
        //        {
        //            Cred(ref fields, applicationName);
        //        }
        //        else
        //        {
        //            using (Impersonation.LogonUser(domain, user, pwd, Impersonation.LogonType.Interactive))
        //            {
        //                Cred(ref fields, applicationName);
        //            }
        //        }
        //    }
        //    return fields;
        //}

        //private void Cred(ref Dictionary<string, string> fields, string applicationName)
        //{
        //    string userName;
        //    string[] labels;
        //    int[] flags;
        //    try
        //    {
        //        Microsoft.BizTalk.SSOClient.Interop.ISSOMapper ssoMapper = (Microsoft.BizTalk.SSOClient.Interop.ISSOMapper)new Microsoft.BizTalk.SSOClient.Interop.SSOMapper();
        //        ssoMapper.GetFieldInfo(applicationName, out labels, out flags);

        //        Microsoft.BizTalk.SSOClient.Interop.ISSOLookup1 ssoLookup = (Microsoft.BizTalk.SSOClient.Interop.ISSOLookup1)new Microsoft.BizTalk.SSOClient.Interop.SSOLookup();
        //        string[] creds = ssoLookup.GetCredentials(applicationName, 0, out userName);
        //        fields.Add(labels[0], userName);
        //        for (int i = 0; i < creds.Length; i++)
        //        {
        //            fields.Add(labels[i + 1], creds[i]);
        //        }
        //    }
        //    catch (Exception exe)
        //    {
        //        userName = "";
        //        fields.Add("Error", exe.Message);
        //        // return new string[] { exe.Message };
        //    }
        //}
    }
}
