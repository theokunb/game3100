using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData 
{
    private List<DetailData> _detailDatas= new List<DetailData>();

    public PlayerData(Player player)
    {
        foreach(var detail in player.GetAllDetails())
        {
            _detailDatas.Add(detail);
        }
    }

    public IEnumerable<DetailData> DetailDatas => _detailDatas;
}
