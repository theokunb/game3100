using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuBackground : MonoBehaviour
{
    [SerializeField] private float _fadeTime;
    [SerializeField] private float _translationTime;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private RectTransform[] _menus;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnepMenu(RectTransform menu)
    {
        DisableMenus(menu);
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, _fadeTime);

        menu.localPosition = new Vector3(0,-Screen.height, 0);
        menu.DOAnchorPosY(0, _translationTime).OnComplete(() =>
        {
            Time.timeScale = 0f;
        });
    }

    public void CloseMenu(RectTransform menu)
    {
        Time.timeScale = 1f;
        _canvasGroup.DOFade(0, _fadeTime);

        menu.DOAnchorPosY(-Screen.height, _translationTime).OnComplete(() => 
        {
            EnableMenus();
            _canvasGroup.gameObject.SetActive(false);
        });
    }

    private void DisableMenus(RectTransform targetMenu)
    {
        foreach(var menu in _menus)
        {
            if(menu != targetMenu)
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
