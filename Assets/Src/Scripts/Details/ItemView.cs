using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _title;

    public void Render(Detail detail)
    {
        _title.text = detail.Title;
        _image.sprite = detail.GetComponent<DetailShop>().Icon;
    }
}
