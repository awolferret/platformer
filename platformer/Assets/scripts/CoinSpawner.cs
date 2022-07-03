using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _spawnPoint;

    private Transform[] _spawnPoints;
    private Coroutine _coroutine;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnPoint.childCount];

        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            _spawnPoints[i] = _spawnPoint.GetChild(i);
        }

        _coroutine = StartCoroutine(SpawnCoins());
        StopCoroutine(_coroutine);
    }

    private IEnumerator SpawnCoins()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Spawn(ChoosePoint(_spawnPoints[i]));
        }

        yield return null;
    }

    private void Spawn(Vector2 whereToSpawn)
    {
        Coin newObject = Instantiate(_coin, whereToSpawn, Quaternion.identity);
    }

    private Vector2 ChoosePoint(Transform spawnPoint)
    {
        float xPosition = spawnPoint.position.x;
        float yPosition = spawnPoint.position.y;
        Vector2 whereToSpawn = new Vector2(xPosition,yPosition);
        return whereToSpawn;
    }
}
