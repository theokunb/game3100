using System.Linq;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PrimaryPlayerCreator _primaryCreator;
    [SerializeField] private ItemsPull _itemsPull;

    private void Awake()
    {
        if(TryLoadData(out PlayerData playerData))
        {
            LoadPlayer(playerData);
        }
        else
        {
            _primaryCreator.CreateDefaultPlayer();
            _primaryCreator.CreateDefaultWallet();
        }
    }

    public bool TryLoadData<T>(out T data)
    {
        data = GameStorage.LoadData<T>();

        return data != null;
    }

    public void LoadPlayer(PlayerData playerData)
    {
        foreach (var detailData in playerData.DetailDatas)
        {
            var detail = FindDetail(detailData);
            _player.SetDetail((dynamic)detail);
        }

        _wallet.SetCurrency(playerData.GetCurrency());
    }

    private Detail FindDetail(DetailData detailData)
    {
        return _itemsPull.Details.Where(detail => detail.Title == detailData.Title).FirstOrDefault();
    }
}
