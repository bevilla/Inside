using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInTowerRange : MonoBehaviour
{
    public TowerAttack tower;

    void Start()
    {
        if (!tower)
        {
            Debug.LogError("TowerAttack script not attached", this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            tower.AddEnemy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            tower.RemoveEnemy(other.gameObject);
        }
    }
}
