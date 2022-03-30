
#region beta
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

    switch (pba2.accountType)
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
#endregion

int Transaction()
{
    Console.WriteLine("Введите ид карты с которой хотите перевести деньги");

    int IdForTransaction = Convert.ToInt32(Console.ReadLine());

    switch (IdForTransaction)
    {
        case 0:
            {

                int newBalance = pba.accountBalance + pba2.accountBalance; // Счет пополняется

                pba2.accountBalance = newBalance;

                int oldBalance = pba.accountBalance - pba.accountBalance; // Счет после списания денег

                pba.accountBalance = oldBalance;

                Console.WriteLine($" Успешный первод! \n Баланс:{pba2.accountBalance}");
                break;

            }
        case 1:
            {
                int newBalance = pba2.accountBalance + pba.accountBalance;//Счет пополняется

                pba.accountBalance = newBalance;

                int oldBalance = pba2.accountBalance - pba2.accountBalance;// Счет после списания денег

                pba2.accountBalance = oldBalance;

                Console.WriteLine($" Успешный первод! \n\t Баланс:{pba.accountBalance}");
                break;
            }

    }
    return 0;
}
_ = Transaction();

public class PhisBankAccount
{

    public int accountId
    {
        get { return GetIndividualNumber(); }
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


