using System;

[Serializable]
public abstract class Money
{
    public int Value { get; private set; }

    public void Increase(Money money)
    {
        Value += money.Value;
    }

    public abstract void Accept(IMoneyVisitor moneyVisitor);
}

[Serializable]
public class Energy : Money
{
    public override void Accept(IMoneyVisitor moneyVisitor)
    {
        moneyVisitor.Visit(this);
    }
}

[Serializable]
public class Metal : Money
{
    public override void Accept(IMoneyVisitor moneyVisitor)
    {
        moneyVisitor.Visit(this);
    }
}

[Serializable]
public class Fuel : Money
{
    public override void Accept(IMoneyVisitor moneyVisitor)
    {
        moneyVisitor.Visit(this);
    }
}

public interface IMoneyVisitor
{
    void Visit(Energy energy);
    void Visit(Metal metal);
    void Visit(Fuel fuel);
}

[Serializable]
public class MoneyVisitor : IMoneyVisitor
{
    public event Action ValuesChanged;

    public MoneyVisitor() 
    {
        Metals = new Metal();
        Energy = new Energy();
        Fuel = new Fuel();
    }

    public Metal Metals { get; private set; }
    public Energy Energy { get; private set; }
    public Fuel Fuel { get; private set; }

    public void Visit(Energy energy)
    {
        Energy.Increase(energy);
        ValuesChanged?.Invoke();
    }

    public void Visit(Metal metal)
    {
        Metals.Increase(metal);
        ValuesChanged?.Invoke();
    }

    public void Visit(Fuel fuel)
    {
        Fuel.Increase(fuel);
        ValuesChanged?.Invoke();
    }

    public static MoneyVisitor operator+(MoneyVisitor first, MoneyVisitor second)
    {
        first.Metals.Increase(second.Metals);
        first.Energy.Increase(second.Energy);
        first.Fuel.Increase(second.Fuel);

        return first;
    }
}