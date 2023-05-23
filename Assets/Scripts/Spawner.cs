using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wawe> _wawes;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _palyer;

    private Player _palyerOnScene;

    private Wawe _currentWawe;
    private int _currentWaweNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawnedEnemyCount;

    private void Start()
    {
        InstantiatePlayer();
        SetWawe(_currentWaweNumber);
    }

    private void Update()
    {
        if (_currentWawe == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if(_timeAfterLastSpawn >= _currentWawe.Delay)
        {
            InstantiateEnemy();
            _spawnedEnemyCount++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWawe.Count <= _spawnedEnemyCount)
            _currentWawe = null;
    }

    private void InstantiatePlayer()
    {
        float playerXPosition = 4;
        float playerYPosition = -3.9f;
        Vector2 playerPosition = new Vector2(playerXPosition, playerYPosition);

        _palyerOnScene = Instantiate(_palyer, playerPosition, Quaternion.identity, _spawnPoint);
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWawe.Enemy, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.InitializeTarget(_palyerOnScene);
        enemy.Dying += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDied;
        _palyer.AddMoney(enemy.Reward);
    }

    private void SetWawe(int index)
    {
        _currentWawe = _wawes[index];
    }
}

[System.Serializable]
public class Wawe
{
    public Enemy Enemy;
    public float Delay;
    public float Count;
}
