using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    private IObjectPool<Enemy> enemyPool;

    private void OnEnable()
    {
        StartCoroutine(DieCoroutine());
    }

    public void SetPool(IObjectPool<Enemy> pool)
    {
        enemyPool = pool;
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(1f);
        enemyPool.Release(this); // return to pool
    }
}