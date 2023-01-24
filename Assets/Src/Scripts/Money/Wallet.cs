using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Image _metalIcon;
    [SerializeField] private TMP_Text _metal;
    [SerializeField] private Image _energyIcon;
    [SerializeField] private TMP_Text _energy;
    [SerializeField] private Image _fuelIcon;
    [SerializeField] private TMP_Text _fuel;

    private MoneyVisitor _moneyVisitor;

    public MoneyVisitor MoneyVisitor => _moneyVisitor;

    private void OnEnable()
    {
        if (MoneyVisitor != null)
        {
            MoneyVisitor.ValuesChanged += OnValueChanged;
        }
    }

    private void OnDisable()
    {
        MoneyVisitor.ValuesChanged -= OnValueChanged;
    }

    public void Init(MoneyVisitor moneyVisitor)
    {
        _moneyVisitor = moneyVisitor;
        MoneyVisitor.ValuesChanged += OnValueChanged;

        Render();
    }

    public void Add(MoneyVisitor newMoney)
    {
        _moneyVisitor += newMoney;
    }

    public void OnTakeMoney(Money money)
    {
        money.Accept(_moneyVisitor);
    }

    private void Render()
    {
        _metal.text = MoneyVisitor.Metals.Value.ToString();
        _energy.text = MoneyVisitor.Energy.Value.ToString();
        _fuel.text = MoneyVisitor.Fuel.Value.ToString();
    }

    private void OnValueChanged()
    {
        Render();
    }
}
