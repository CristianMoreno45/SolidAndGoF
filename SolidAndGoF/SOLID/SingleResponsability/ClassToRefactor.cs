namespace SolidAndGoF.SOLID.SingleResponsability
{
    public class ClassToRefactor
    {
        public class AccountService
        {
            public readonly List<string> Accounts = new List<string>();
            public void Create(string firstName, string LastName, int age)
            {
                bool isValid = true;
                string result="";
                if (string.IsNullOrEmpty(firstName))
                {
                    result = "The parameter 'First Name' is mandatory.";
                    isValid = false;
                }
                    
                if(string.IsNullOrEmpty(LastName))
                {
                    result = "The parameter 'Last Name' is mandatory.";
                    isValid = false;
                }

                if (age < 1)
                {
                    result = "The parameter 'Age' is mandatory and it should be greater than zero.";
                    isValid = false;
                }

                if (isValid) {
                    result = $"The account has been created ({firstName},{LastName},{age})";
                   
                }
                Accounts.Add(result);
            }

            public void DownLoadReport(string fileName, List<string> records)
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                using StreamWriter writer = new StreamWriter(fileName);
                foreach (string record in records)
                {
                    writer.WriteLine(record);
                }
            }
        }

        public void Handle1(string fileName)
        {
            AccountService service = new AccountService();
            service.Create("Jhon", "Doe", 24);
            service.Create("Juan", "Rodriguez", 38);
            service.Create("Emily", "Smith", 12);
            service.DownLoadReport(fileName, service.Accounts);
        }
        public void Handle2(string fileName)
        {
            AccountService service = new AccountService();
            service.Create("", "Doe", 24);
            service.DownLoadReport(fileName, service.Accounts);
        }
        public void Handle3(string fileName)
        {
            AccountService service = new AccountService();
            service.Create("Jhon", "", 24);
            service.DownLoadReport(fileName, service.Accounts);
        }
        public void Handle4(string fileName)
        {
            AccountService service = new AccountService();
            service.Create("Jhon", "Doe", 0);
            service.DownLoadReport(fileName, service.Accounts);
        }

    }
}
