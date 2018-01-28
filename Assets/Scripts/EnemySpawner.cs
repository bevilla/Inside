using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform destination;
    public float cooldown = 2f;
    public OrgansInfos.Organ organDestination1;
    public OrgansInfos.Organ organDestination2;

    float remainingTime = 0f;

    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            GameObject obj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            EnemyMovement enemyMovement = obj.GetComponent<EnemyMovement>();

            remainingTime = cooldown;
            enemyMovement.destination = destination.position;
            enemyMovement.organDestination = Random.value > 0.5f ? organDestination1 : organDestination2;
        }
    }
}
