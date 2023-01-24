using System.Linq;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PrimaryPlayerCreator _primaryCreator;
    [SerializeField] private ItemsPull _itemsPull;
    [SerializeField] private Wallet _wallet;

    private void Awake()
    {
        if(TryLoadData(out PlayerData playerData, GameStorage.PlayerDetails))
        {
            LoadPlayer(playerData);
        }
        else
        {
            _primaryCreator.CreateDefaultPlayer();
        }

        LoadWallet();
    }

    public bool TryLoadData<T>(out T data, string fileName)
    {
        data = GameStorage.LoadData<T>(fileName);

        return data != null;
    }

    public void LoadPlayer(PlayerData playerData)
    {
        foreach (var detailData in playerData.DetailDatas)
        {
            var detail = FindDetail(detailData);
            _player.SetDetail((dynamic)detail);
        }
    }

    private Detail FindDetail(DetailData detailData)
    {
        return _itemsPull.Details.Where(detail => detail.Title == detailData.Title).FirstOrDefault();
    }

    private void LoadWallet()
    {
        if(TryLoadData(out MoneyVisitor money, GameStorage.PlayerWallet))
        {

        }
        else
        {
            money = new MoneyVisitor();
        }

        _wallet.Init(money);
    }
}
