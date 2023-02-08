using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class FinishMenu : MonoBehaviour
{
    [SerializeField] private MenuBackground _menuBackground;
    [SerializeField] private Game _game;
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _nextButton;

    private RectTransform _rectTransform;

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
        _rectTransform = GetComponent<RectTransform>();
        _nextButton.gameObject.SetActive(_game.HaveNextLevel());
    }

    public void SetRewards(Bag playerBag)
    {
        DisplayItems(playerBag.GetDetails());
        DisplayCurrencies(playerBag.GetCurrencies());
    }

    private void DisplayItems(IEnumerable<DetailDropped> _items)
    {

    }

    private void DisplayCurrencies(IEnumerable<DroppedCurrency> _currencies)
    {
        var levelReward = _game.CurrentLevel.Reward;
        var droppedReward = _currencies.ToList();
    }

    private void OnHomeClicked()
    {
        _menuBackground.CloseMenu(_rectTransform);
        MenuScene.Load();
    }

    private void OnReplayClicked()
    {
        _menuBackground.CloseMenu(_rectTransform);
        GameScene.Load(_game.CurrentLevel.Id);
    }

    private void OnNextClicked()
    {
        _menuBackground.CloseMenu(_rectTransform);
        GameScene.Load(_game.CurrentLevel.Id + 1);
    }
}
