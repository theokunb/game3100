using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private MenuBackground _menuBackground;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _resumeButton.onClick.AddListener(OnResumeClicked);
        _exitButton.onClick.AddListener(OnExitClicked);
    }

    private void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(OnResumeClicked);
        _exitButton.onClick.RemoveListener(OnExitClicked);
    }

    private void OnResumeClicked()
    {
        _menuBackground.CloseMenu(GetComponent<RectTransform>());
    }

    private void OnExitClicked()
    {
        MenuScene.Load();
    }
}
