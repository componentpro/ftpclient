using System;
using ComponentPro.Diagnostics;
using ComponentPro.IO;
using ComponentPro.Net;

namespace FtpClient
{
    public class LoginInfo
    {
        #region General Info

        TraceEventType _logLevel;
        public TraceEventType LogLevel
        {
            get { return _logLevel; }
            set { _logLevel = value; }
        }

        string _server;
        public string ServerName
        {
            get { return _server; }
            set { _server = value; }
        }

        int _port;
        public int ServerPort
        {
            get { return _port; }
            set { _port = value; }
        }

        string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        string _remoteDir;
        public string RemoteDir
        {
            get { return _remoteDir; }
            set { _remoteDir = value; }
        }

        string _localDir;
        public string LocalDir
        {
            get { return _localDir; }
            set { _localDir = value; }
        }

        bool _pasvMode;
        public bool PasvMode
        {
            get { return _pasvMode; }
            set { _pasvMode = value; }
        }

        bool _encoding;
        public bool Utf8Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        #endregion

        #region Proxy

        string _proxyServer;
        public string ProxyServer
        {
            get { return _proxyServer; }
            set { _proxyServer = value; }
        }

        int _proxyPort;
        public int ProxyPort
        {
            get { return _proxyPort; }
            set { _proxyPort = value; }
        }

        string _proxyUser;
        public string ProxyUser
        {
            get { return _proxyUser; }
            set { _proxyUser = value; }
        }

        string _proxyPassword;
        public string ProxyPassword
        {
            get { return _proxyPassword; }
            set { _proxyPassword = value; }
        }

        string _proxyDomain;
        public string ProxyDomain
        {
            get { return _proxyDomain; }
            set { _proxyDomain = value; }
        }

        FtpProxyType _proxyType;
        public FtpProxyType ProxyType
        {
            get { return _proxyType; }
            set { _proxyType = value; }
        }

        FtpProxyHttpConnectAuthMethod _proxyMethod;
        public FtpProxyHttpConnectAuthMethod ProxyMethod
        {
            get { return _proxyMethod; }
            set { _proxyMethod = value; }
        }

        #endregion

        #region FTP Security

        SecurityMode _securityMode;
        public SecurityMode SecurityMode
        {
            get { return _securityMode; }
            set { _securityMode = value; }
        }

        string _certificate;
        public string Certificate
        {
            get { return _certificate; }
            set { _certificate = value; }
        }

        bool _ccc;
        public bool ClearCommandChannel
        {
            get { return _ccc; }
            set { _ccc = value; }
        }

        #endregion



        bool _enableCompression;
        public bool EnableCompression
        {
            get { return _enableCompression; }
            set { _enableCompression = value; }
        }

        private int _syncMethod;
        public int SyncMethod
        {
            get { return _syncMethod; }
            set { _syncMethod = value; }
        }

        private bool _syncResumability;
        public bool SyncResumability
        {
            get { return _syncResumability; }
            set { _syncResumability = value; }
        }

        private bool _syncDateTime;
        public bool SyncDateTime
        {
            get { return _syncDateTime; }
            set { _syncDateTime = value; }
        }

        private RecursionMode _syncRecursive;
        public RecursionMode SyncRecursive
        {
            get { return _syncRecursive; }
            set { _syncRecursive = value; }
        }

        private string _syncSearchPattern;
        public string SyncSearchPattern
        {
            get { return _syncSearchPattern; }
            set { _syncSearchPattern = value; }
        }


        #region Methods

        public void SaveConfig()
        {
            // Save Login information.
            Util.SaveProperty("ServerName", ServerName);
            Util.SaveProperty("ServerPort", ServerPort);
            Util.SaveProperty("UserName", UserName);
            Util.SaveProperty("Password", Password);
            Util.SaveProperty("RemoteDir", RemoteDir);
            Util.SaveProperty("LocalDir", LocalDir);
            Util.SaveProperty("PASVMode", PasvMode);

            Util.SaveProperty("Encoding", Utf8Encoding);
            
            // Proxy Info.
            Util.SaveProperty("ProxyServer", ProxyServer);
            Util.SaveProperty("ProxyPort", ProxyPort);
            Util.SaveProperty("ProxyUser", ProxyUser);
            Util.SaveProperty("ProxyPassword", ProxyPassword);
            Util.SaveProperty("ProxyDomain", ProxyDomain);
            Util.SaveProperty("ProxyType", (int)ProxyType);
            Util.SaveProperty("ProxyMethod", (int)ProxyMethod);

            // Security Info.
            Util.SaveProperty("Certificate", Certificate);
            Util.SaveProperty("Security", (int)SecurityMode);
            Util.SaveProperty("CCC", ClearCommandChannel);


            Util.SaveProperty("Compress", EnableCompression);

            Util.SaveProperty("FileComparisonMethod", _syncMethod);
            Util.SaveProperty("SyncResumability", _syncResumability);
            Util.SaveProperty("SyncFileDateTime", _syncDateTime);
            Util.SaveProperty("Recursive", _syncRecursive);
            Util.SaveProperty("SearchPattern", _syncSearchPattern);

            Util.SaveProperty("LogLevel", (int)_logLevel);
        }

        public static LoginInfo LoadConfig()
        {
            // Load Login information.
            LoginInfo s = new LoginInfo();

            // Server and authentication info.
            s.ServerName = (string)Util.GetProperty("ServerName", string.Empty);
            s.ServerPort = Util.GetIntProperty("ServerPort", 21);
            s.UserName = (string)Util.GetProperty("UserName", string.Empty);
            s.Password = (string)Util.GetProperty("Password", string.Empty);
            s.RemoteDir = (string)Util.GetProperty("RemoteDir", string.Empty);
            s.LocalDir = (string)Util.GetProperty("LocalDir", AppDomain.CurrentDomain.BaseDirectory);
            s.PasvMode = Util.GetProperty("PASVMode", "True").ToString() == "True";

            s.Utf8Encoding = (string)Util.GetProperty("Encoding", "False") == "True";

            // Proxy info.
            s.ProxyServer = (string)Util.GetProperty("ProxyServer", string.Empty);
            s.ProxyPort = Util.GetIntProperty("ProxyPort", 1080);
            s.ProxyUser = (string)Util.GetProperty("ProxyUser", string.Empty);
            s.ProxyPassword = (string)Util.GetProperty("ProxyPassword", string.Empty);
            s.ProxyDomain = (string)Util.GetProperty("ProxyDomain", string.Empty);
            s.ProxyType = (FtpProxyType)Util.GetIntProperty("ProxyType", 0);
            s.ProxyMethod = (FtpProxyHttpConnectAuthMethod)Util.GetIntProperty("ProxyMethod", 0);

            // Security info.
            s.Certificate = (string)Util.GetProperty("Certificate", string.Empty);
            s.SecurityMode = (SecurityMode)Util.GetIntProperty("Security", 0);
            s.ClearCommandChannel = Util.GetProperty("CCC", "False").ToString() == "True";



            s.EnableCompression = Util.GetProperty("Compress", "False").ToString() == "True";

            s.SyncMethod = Util.GetIntProperty("FileComparisonMethod", 0);
            s.SyncResumability = (string)Util.GetProperty("SyncResumability", "False") == "True";
            s.SyncDateTime = (string)Util.GetProperty("SyncFileDateTime", "True") == "True";
            s.SyncRecursive = (string)Util.GetProperty("Recursive", "True") == "True" ? RecursionMode.Recursive : RecursionMode.None;
            s.SyncSearchPattern = (string)Util.GetProperty("SearchPattern", "*.*");

            s.LogLevel = (TraceEventType)Util.GetIntProperty("LogLevel", (int)TraceEventType.Information);

            return s;
        }

        #endregion
    }    
}