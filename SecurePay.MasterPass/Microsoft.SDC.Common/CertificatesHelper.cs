using System;
using System.Security.Cryptography.X509Certificates;

namespace SecurePay.MasterPass.Microsoft.SDC.Common {
    //This class is copied from Microsoft.SDC.Common because SecurePay.MasterPass shouldn't have any reference from TSA. 
    public static class CertificatesHelper {
           
            public static X509Certificate2 FindCertificate(StoreLocation location, StoreName name,
                                                            X509FindType findType, string findValue, bool validOnly = true) {
                X509Store store = new X509Store(name, location);
                try {
                    store.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection col = store.Certificates.Find(findType, findValue, true);
                    if (col.Count == 0) {
                        string certFindDescription = $"location {location}  StoreName   {name}, X509FindType  {findType}, findValue  {findValue}";
                        col = store.Certificates.Find(findType, findValue, false);
                        if (col.Count == 0) {
                            string msg = $"No certificates found in {certFindDescription}";
                            throw new NullReferenceException(msg);

                        }
                        else {
                            string msg = $"No VALID certificates found in {certFindDescription}";
                            if (validOnly) {
                                throw new NullReferenceException(msg);
                            }
                        }
                    }
                    return col[0]; // return first certificate found
                }
                finally {
                    store.Close();
                }
            }
        }
    }