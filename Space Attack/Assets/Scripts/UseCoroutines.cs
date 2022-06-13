using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCoroutines : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine(CloneEnemyPrefab());
    }

    IEnumerator CloneEnemyPrefab()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8, 8), 6.7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
