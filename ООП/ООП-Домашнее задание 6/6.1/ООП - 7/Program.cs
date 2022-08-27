static bool ReferenceEquals(Object pbaA, Object pbaB)
{
    return pbaA == pbaB;
}
#region beta
PhisBankAccount pba = new PhisBankAccount();
{

    pba.accountId = pba.GetIndividualNumber();

    pba.accountBalance = 6000;

    pba.accountType = BankAccountType.PhisPerson;

    switch (pba.accountType)
    {
        case BankAccountType.PhisPerson:
            {
                Console.WriteLine($" Держатель карты: Физическое лицо \n\t\t  Ид Клиента: {pba.accountId}\n\t\t  Баланс: {pba.accountBalance}");
                break;
            }
        case BankAccountType.LegalPerson:
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

    pba2.accountType = BankAccountType.PhisPerson;

    switch (pba2.accountType)
    {
        case BankAccountType.PhisPerson:
            {
                Console.WriteLine($" Держатель карты: Физическое лицо \n\t\t  Ид Клиента: {pba2.accountId}\n\t\t  Баланс: {pba2.accountBalance}");
                break;
            }
        case BankAccountType.LegalPerson:
            {
                Console.WriteLine($" Держатель карты: Юридическое лицо \n\t\t  Ид Клиента: {pba2.accountId}\n\t\t  Баланс: {pba2.accountBalance}");
                break;
            }
    }

}


#endregion
Console.WriteLine(pba == pba2);
Console.WriteLine(pba.Equals(pba2));
Console.WriteLine(object.ReferenceEquals(pba,pba2));
Console.WriteLine(pba.hash == pba2.hash);
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

    public BankAccountType accountType
    {
        get;
        set;
    }
    public static int id = 0;

    public int GetIndividualNumber()
    {

        return id++;
    }

    public int hash
    {
        get { return GetHashCode(); }
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(accountId, accountBalance, accountType);
    }
}



[Flags]

public enum BankAccountType
{
    LegalPerson = 1,
    PhisPerson = 2,
}