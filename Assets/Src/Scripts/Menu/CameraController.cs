using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private Transform _cameraMainView;
    [SerializeField] private Transform _cameraHeadView;
    [SerializeField] private Transform _cameraBodyView;
    [SerializeField] private Transform _cameraLegView;

    private Coroutine _translationTask;

    public void ResetPosition()
    {
        _camera.transform.position = _cameraMainView.position;
    }

    public void Translate(CameraPoint cameraPoint)
    {
        switch(cameraPoint)
        {
            case CameraPoint.Main:
                TranslateCamera(_cameraMainView);
                break;
            case CameraPoint.Head:
                TranslateCamera(_cameraHeadView);
                break;
            case CameraPoint.Body:
                TranslateCamera(_cameraBodyView);
                break;
            case CameraPoint.Leg:
                TranslateCamera(_cameraLegView);
                break;
        }
    }

    private void TranslateCamera(Transform target)
    {
        if(_translationTask == null)
        {
            _translationTask = StartCoroutine(TranslateCameraTask(target));
        }
        else
        {
            StopCoroutine(_translationTask);
            _translationTask = StartCoroutine(TranslateCameraTask(target));
        }
    }

    private IEnumerator TranslateCameraTask(Transform target)
    {
        while(_camera.transform.position != target.position)
        {
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, target.position, Time.deltaTime * _cameraSpeed);
            yield return null;
        }
    }
}

public enum CameraPoint
{
    Main,
    Head,
    Body,
    Leg
}
