using IJunior.TypedScenes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Subpanel _rootPanel;
    [SerializeField] private Button _playButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClicked);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayClicked);
    }

    public void OpenMenu(Subpanel subpanel)
    {
        subpanel.Push(subpanel, _rootPanel);
    }

    private void OnPlayClicked()
    {
        GameScene.Load(0);
    }
}
