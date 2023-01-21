using System.Linq;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    [SerializeField] private Player _player;
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
        }
    }

    public bool TryLoadData(out PlayerData playerData)
    {
        playerData = GameStorage.LoadPlayer();

        return playerData != null;
    }

    public Player LoadPlayer(PlayerData playerData)
    {
        foreach (var detailData in playerData.DetailDatas)
        {
            var detail = FindDetail(detailData);
            _player.SetDetail((dynamic)detail);
        }

        return _player;
    }

    private Detail FindDetail(DetailData detailData)
    {
        return _itemsPull.Details.Where(detail => detail.Title == detailData.Title).FirstOrDefault();
    }
}
