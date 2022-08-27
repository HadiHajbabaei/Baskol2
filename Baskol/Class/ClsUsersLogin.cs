namespace Baskol
{
    static class ClsUsersLogin
    {
        private static MyDB.BusinessLayer.Models.Account _User;
        private static MyDB.BusinessLayer.Models.Company company;
        private static Properties.Settings st = new Properties.Settings();

        public static bool Crack
        {
            get { return st.Crack; }
            set { st.Crack = value; st.Save(); }
        }

        public static string FileNameServer
        {
            get { return st.FileNameServer; }
            set { st.FileNameServer = value; st.Save(); }
        }

        public static string FileName
        {
            get { return st.FileName; }
            set { st.FileName = value; st.Save(); }
        }
        public static MyDB.BusinessLayer.Models.Company Company
        {
            get { return company; }
            set { company = value; }
        }

        public static MyDB.BusinessLayer.Models.Account User
        {
            get { return _User; }
            set { _User = value; }
        } 
    }

}
