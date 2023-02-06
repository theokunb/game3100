using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private MenuBackground _menuBackground;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnCloseClicked);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseClicked);
    }

    private void OnCloseClicked()
    {
        _menuBackground.CloseMenu(gameObject);
    }
}
