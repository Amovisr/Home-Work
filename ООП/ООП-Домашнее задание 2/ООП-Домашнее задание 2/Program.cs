using Newtonsoft.Json;
PhisBankAccount pba = new PhisBankAccount();
{

    pba.accountId = pba.GetIndividualNumber();

    pba.accountBalance = 6000;

    pba.accountType = 2;

    switch (pba.accountType)
    {
        case (int)BankAccountType.PhisPerson:
            {
                Console.WriteLine($" Держатель карты: Физическое лицо \n\t\t  Ид Клиента: {pba.accountId}\n\t\t  Баланс: {pba.accountBalance}");
                break;
            }
        case (int)BankAccountType.LegalPerson:
            {
                Console.WriteLine($" Держатель карты: Юридическое лицо \n\t\t  Ид Клиента: {pba.accountId}\n\t\t  Баланс: {pba.accountBalance}");
                break;
            }
    }
}


PhisBankAccount pba2 = new PhisBankAccount();
{

    pba2.accountId = pba2.GetIndividualNumber();

    pba2.accountBalance = 500;

    pba2.accountType = 2;

    switch (pba.accountType)
    {
        case (int)BankAccountType.PhisPerson:
            {
                Console.WriteLine($" Держатель карты: Физическое лицо \n\t\t  Ид Клиента: {pba2.accountId}\n\t\t  Баланс: {pba2.accountBalance}");
                break;
            }
        case (int)BankAccountType.LegalPerson:
            {
                Console.WriteLine($" Держатель карты: Юридическое лицо \n\t\t  Ид Клиента: {pba2.accountId}\n\t\t  Баланс: {pba2.accountBalance}");
                break;
            }
    }
}
PhisBankAccount pba3 = new PhisBankAccount();
{

    pba3.accountId = pba3.GetIndividualNumber();

    pba3.accountBalance = 250;

    pba3.accountType = 2;

    switch (pba.accountType)
    {
        case (int)BankAccountType.PhisPerson:
            {
                Console.WriteLine($" Держатель карты: Физическое лицо \n\t\t  Ид Клиента: {pba3.accountId}\n\t\t  Баланс: {pba3.accountBalance}");
                break;
            }
        case (int)BankAccountType.LegalPerson:
            {
                Console.WriteLine($" Держатель карты: Юридическое лицо \n\t\t  Ид Клиента: {pba3.accountId}\n\t\t  Баланс: {pba3.accountBalance}");
                break;
            }
    }
}






public class PhisBankAccount
{
    public int accountId
    {
        get { return GetIndividualNumber();}
        set { id = value; }
    }


    public int accountBalance
    {
        get;
        set;
    }

    public int accountType
    {
        get;
        set;
    }
    public static int id = 0;

    public int GetIndividualNumber()
    {
    
        return id++;
    }



}



[Flags]

public enum BankAccountType
{
    LegalPerson = 1,
    PhisPerson = 2,
}

