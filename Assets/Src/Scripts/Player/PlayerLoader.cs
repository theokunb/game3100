using System.Linq;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PrimaryPlayerCreator _primaryCreator;
    [SerializeField] private ItemsPull _itemsPull;

    private PlayerProgress _playerProgress;

    public PlayerProgress PlayerProgress => _playerProgress;

    private void Awake()
    {
        ProccessPlayerData();
        ProccessPlayerProgress();
    }

    public bool TryLoadData<T>(out T data,string fileName)
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

        _wallet.SetCurrency(playerData.GetCurrency());
    }

    private Detail FindDetail(DetailData detailData)
    {
        return _itemsPull.Details.Where(detail => detail.Title == detailData.Title).FirstOrDefault();
    }

    private void ProccessPlayerData()
    {
        if (TryLoadData(out PlayerData playerData, GameStorage.PlayerData))
        {
            LoadPlayer(playerData);
        }
        else
        {
            _primaryCreator.CreateDefaultPlayer();
            _primaryCreator.CreateDefaultWallet();
        }
    }

    private void ProccessPlayerProgress()
    {
        if(TryLoadData(out _playerProgress, GameStorage.PlayerProgress))
        {

        }
        else
        {
            _playerProgress = new PlayerProgress();
            GameStorage.Save(_playerProgress, GameStorage.PlayerProgress);
        }

        _playerProgress.VisitGame();
    }
}
