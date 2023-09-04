using Novell.Directory.Ldap;

namespace Helper
{
    public class LdapAuthenticationService : IAuthenticationService
    {
        private string _hostname;

        private int _port;

        private IList<string> _dcs;

        private string _baseSearch;

        private string _domainName;

        public LdapAuthenticationService(string hostname, string? domain, int port = 389)
        {
            if (string.IsNullOrEmpty(hostname))
            {
                throw new Exception("Unsupported hostname null or empty value .... ");
            }

            _port = port;
            _hostname = hostname;
            _dcs = hostname.Split(".");
            _baseSearch = BuildBaseSearch();
            _domainName = string.IsNullOrEmpty(domain) ? BuildDomain() : domain;
        }

        public User Authenticate(string username, string password)
        {
            using LdapConnection ldapConnection = new LdapConnection();
            ldapConnection.Connect(_hostname, _port);
            ldapConnection.Bind(username + _domainName, password);
            LdapSearchResults ldapSearchResults = ldapConnection.Search(_baseSearch, 2, "(&(objectClass=user)(userPrincipalName=" + username + _domainName + "))", null, typesOnly: false);
            if (ldapSearchResults.HasMore())
            {
                try
                {
                    LdapEntry ldapEntry = ldapSearchResults.Next();
                    if (ldapEntry != null)
                    {
                        string stringValue = ldapEntry.getAttributeSet().getAttribute("sn").StringValue;
                        string stringValue2 = ldapEntry.getAttributeSet().getAttribute("givenName").StringValue;
                        string stringValue3 = ldapEntry.getAttributeSet().getAttribute("displayName").StringValue;
                        return new User(stringValue, stringValue2, stringValue3);
                    }

                    throw new UserNotFoundException("Unable to found user in active directory for " + username);
                }
                catch (LdapException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                    throw new UserNotFoundException("Unable to found user in active directory for " + username);
                }
            }

            throw new UserNotFoundException("Unable to found user in active directory for " + username);
        }

        private string BuildBaseSearch()
        {
            return string.Join(",", _dcs.Select((x) => "DC=" + x));
        }

        public string BuildDomain()
        {
            return _domainName = "@" + _hostname;
        }
    }
}
