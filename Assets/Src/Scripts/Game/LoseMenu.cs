using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] private MenuBackground _menuBackground;
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _replayButton;
    [SerializeField] private Game _game;

    private void OnEnable()
    {
        _homeButton.onClick.AddListener(OnHomeClicked);
        _replayButton.onClick.AddListener(OnReplayClicked);
    }

    private void OnDisable()
    {
        _homeButton.onClick.RemoveListener(OnHomeClicked);
        _replayButton.onClick.RemoveListener(OnReplayClicked);
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
}
