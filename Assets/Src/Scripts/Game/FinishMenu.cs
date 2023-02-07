using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    [SerializeField] private MenuBackground _menuBackground;
    [SerializeField] private ItemView _itemViewTemplate;
    [SerializeField] private DisplayCurrency _currencyTemplate;
    [SerializeField] private GameObject _itemsContainer;
    [SerializeField] private GameObject _currencyContainer;
    [SerializeField] private Game _game;
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _nextButton;


    private void OnEnable()
    {
        _homeButton.onClick.AddListener(OnHomeClicked);
        _replayButton.onClick.AddListener(OnReplayClicked);
        _nextButton.onClick.AddListener(OnNextClicked);
    }

    private void OnDisable()
    {
        _homeButton.onClick.RemoveListener(OnHomeClicked);
        _replayButton.onClick.RemoveListener(OnReplayClicked);
        _nextButton.onClick.RemoveListener(OnNextClicked);
    }

    private void Start()
    {
        _nextButton.gameObject.SetActive(_game.HaveNextLevel());
    }

    public void SetRewards(Bag playerBag)
    {
        DisplayItems(playerBag.GetDetails());
        DisplayCurrencies(playerBag.GetCurrencies());
    }

    private void DisplayItems(IEnumerable<DetailDropped> _items)
    {
        foreach(var item in _items)
        {
            var displayedItem = Instantiate(_itemViewTemplate, _itemsContainer.transform);
            displayedItem.Render(item.GetDetail());
        }
    }

    private void DisplayCurrencies(IEnumerable<DroppedCurrency> _currencies)
    {
        var levelReward = _game.CurrentLevel.Reward;
        var droppedReward = _currencies.ToList();
    }

    private void OnHomeClicked()
    {
        _menuBackground.CloseMenu(gameObject);
        MenuScene.Load();
    }

    private void OnReplayClicked()
    {
        _menuBackground.CloseMenu(gameObject);
        GameScene.Load(_game.CurrentLevel.Id);
    }

    private void OnNextClicked()
    {
        _menuBackground.CloseMenu(gameObject);
        GameScene.Load(_game.CurrentLevel.Id + 1);
    }
}
