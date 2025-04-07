using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    private IObjectPool<Enemy> enemyPool;

    [SerializeField] private Enemy enemyPrefab;

    private void Awake()
    {
        SetUpBulletPool();
    }

    private void Update()
    {
        SpawnEnemy();
    }

    private void SetUpBulletPool()
    {
        enemyPool = new ObjectPool<Enemy>(
            CreatePool,
            OnGetFromPool,
            OnReturnToPool,
            OnDestroyPooledObject,
            maxSize: 100
        );
    }

    private Enemy CreatePool()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.SetPool(enemyPool);
        return enemy;
    }

    private void OnGetFromPool(Enemy bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position;
    }

    private void OnReturnToPool(Enemy bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(Enemy bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void SpawnEnemy()
    {
        if (Input.GetKeyDown(KeyCode.S))
            enemyPool.Get();
    }
}