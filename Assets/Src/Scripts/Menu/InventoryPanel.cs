using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CameraController))]
public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _scrollView;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _headButton;
    [SerializeField] private Button _bodyButton;
    [SerializeField] private Button _legButton;
    [SerializeField] private ItemsPull _itemPull;

    private CameraController _cameraController;

    private void Start()
    {
        _cameraController= GetComponent<CameraController>();
    }

    private void OnEnable()
    {
        _backButton.onClick.AddListener(OnBackButtonClicked);
        _headButton.onClick.AddListener(OnHeadClicked);
        _bodyButton.onClick.AddListener(OnBodyClicked);
        _legButton.onClick.AddListener(OnLegClicked);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(OnBackButtonClicked);
        _headButton.onClick.RemoveListener(OnHeadClicked);
        _bodyButton.onClick.RemoveListener(OnBodyClicked);
        _legButton.onClick.RemoveListener(OnLegClicked);
    }

    private void OnBackButtonClicked()
    {
        _scrollView.SetActive(false);
        _cameraController.ResetPosition();
    }

    private void OnHeadClicked()
    {
        _scrollView.SetActive(true);
        _cameraController.Translate(CameraPoint.Head);
    }

    private void OnBodyClicked()
    {
        _scrollView.SetActive(true);
        _cameraController.Translate(CameraPoint.Body);
    }

    private void OnLegClicked()
    {
        _scrollView.SetActive(true);
        _cameraController.Translate(CameraPoint.Leg);
    }
}
