using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private Terrain[] _terrains;
    [SerializeField] private GameObject _boundTemplate;
    [SerializeField] private float _boundWidth;
    [SerializeField] private float _boundHeight;

    private int _platformWidth;
    private int _platformLenght;
    private int _platformHeight;

    private void CreateGround()
    {
        var randomIndex = Random.Range(0, _terrains.Length);
        var terrain = Instantiate(_terrains[randomIndex]);
        terrain.terrainData.size = new Vector3(_platformWidth, _platformHeight, _platformLenght);
    }

    private void CreateBounds()
    {
        var bound1 = Instantiate(_boundTemplate);
        var bound2 = Instantiate(_boundTemplate);
        var bound3 = Instantiate(_boundTemplate);
        var bound4 = Instantiate(_boundTemplate);
        SetUpBound(bound1,
            new Vector3(_platformWidth / 2, _boundHeight / 2, _boundWidth / 2),
            new Vector3(_platformWidth, _boundHeight, _boundWidth));
        SetUpBound(bound2,
            new Vector3(_platformWidth / 2, _boundHeight / 2, _platformLenght - _boundWidth / 2),
            new Vector3(_platformWidth, _boundHeight, _boundWidth));
        SetUpBound(bound3,
            new Vector3(_boundWidth / 2, _boundHeight / 2, _platformLenght / 2),
            new Vector3(_boundWidth, _boundHeight, _platformLenght));
        SetUpBound(bound4,
            new Vector3(_platformWidth - _boundWidth / 2, _boundHeight / 2, _platformLenght / 2),
            new Vector3(_boundWidth, _boundHeight, _platformLenght));
    }

    private void SetUpBound(GameObject bound, Vector3 position, Vector3 scale)
    {
        bound.transform.position = position;
        bound.transform.localScale = scale;
    }

    public void Create(int platformWidth, int platformLenght, int platformHeight)
    {
        _platformWidth = platformWidth;
        _platformHeight = platformHeight;
        _platformLenght = platformLenght;

        CreateGround();
        CreateBounds();
    }
}
