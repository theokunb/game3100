using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData 
{
    private List<DetailData> _detailDatas= new List<DetailData>();
    private List<CurrencyData> _currencyDatas= new List<CurrencyData>();

    public PlayerData(Player player)
    {
        foreach(var detail in player.GetAllDetails())
        {
            _detailDatas.Add(detail);
        }

        if(player.TryGetComponent(out Wallet wallet))
        {
            foreach(var element in wallet.GetCurrecncies())
            {
                _currencyDatas.Add(element);
            }
        }
    }

    public IEnumerable<DetailData> DetailDatas => _detailDatas;

    public IEnumerable<CurrencyData> GetCurrency() => _currencyDatas;
}
