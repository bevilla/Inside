using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOrganTrigger : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var enemyMovement = other.gameObject.GetComponentInChildren<EnemyMovement>();

            enemyMovement.isMovingToOrgan = true;
            enemyMovement.destination = destination.position;
        }
    }
}
