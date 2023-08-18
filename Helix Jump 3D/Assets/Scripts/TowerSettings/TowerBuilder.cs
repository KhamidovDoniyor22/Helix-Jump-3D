using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _pipe;

    [Space]
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platform;

    private float _startAndFinishAdditionalScale = 0.5f;

    public float PipeScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;

    private void Awake()
    {
        Build();
    }
    private void Build()
    {
        GameObject pipe = Instantiate(_pipe, transform);
        pipe.transform.localScale = new Vector3(1, PipeScaleY, 1);

        Vector3 spawnPosition = pipe.transform.position;
        spawnPosition.y += pipe.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, pipe.transform);

        for(int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, pipe.transform);
        }
        SpawnPlatform(_finishPlatform, ref spawnPosition, pipe.transform);
    }
    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent) 
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }
}
