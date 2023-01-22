using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailView : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event Action<DetailView> OnEquipButtonClicked;

    public DetailShop DetailShop { get; private set; }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    public void Render(DetailShop detailShop)
    {
        _button.image.sprite = detailShop.Icon;
        DetailShop = detailShop;
    }

    private void OnButtonClicked()
    {
        OnEquipButtonClicked?.Invoke(this);
    }
}
