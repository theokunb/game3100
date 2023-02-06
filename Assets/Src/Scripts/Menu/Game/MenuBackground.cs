using UnityEngine;
using UnityEngine.UI;

public class MenuBackground : MonoBehaviour
{
    [SerializeField] private CanvasGroup _background;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject[] _menus;

    public void OnepMenu(GameObject menu)
    {
        DisableMenus(menu);
        _background.alpha = 0;
        _background.LeanAlpha(1, 0.5f);
        _pauseButton.interactable = false;

        menu.transform.localPosition = new Vector2(0, -Screen.height);
        menu.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().setOnComplete(() =>
        {
            Time.timeScale = 0;
        });
    }

    public void CloseMenu(GameObject menu)
    {
        Time.timeScale = 1;
        _pauseButton.interactable = true;

        menu.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(() =>
        {
            EnableMenus();
            gameObject.SetActive(false);
        });
    }

    private void DisableMenus(GameObject gameObject)
    {
        foreach(var menu in _menus)
        {
            if(menu.gameObject != gameObject)
            {
                menu.gameObject.SetActive(false);
            }
        }
    }

    private void EnableMenus()
    {
        foreach (var menu in _menus)
        {
            menu.gameObject.SetActive(true);
        }
    }
}
