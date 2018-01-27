using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public enum Algorithm
    {
        EnterFirst,
        EnterLast,
        Nearest,
        Farthest,
        Stronger,
        Weaker,
    };

    public float cooldown;
    public float damage;
    public Algorithm algorithm;

    float remainingTime = 0;
    List<GameObject> availableEnemies = new List<GameObject>();

    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            remainingTime = cooldown;
            Attack();
        }
    }

    void Attack()
    {
        if (availableEnemies.Count > 0)
        {
            Kill(GetEnemyToAttack());
        }
    }

    GameObject GetEnemyToAttack()
    {
        GameObject enemy = availableEnemies[0];

        switch (algorithm)
        {
            case Algorithm.EnterFirst:
                enemy = availableEnemies[0];
                break;
            case Algorithm.EnterLast:
                enemy = availableEnemies[availableEnemies.Count - 1];
                break;
            case Algorithm.Nearest:
                foreach (GameObject obj in availableEnemies)
                {
                    if (Vector3.Distance(obj.transform.position, transform.position) < Vector3.Distance(enemy.transform.position, transform.position))
                    {
                        enemy = obj;
                    }
                }
                break;
            case Algorithm.Farthest:
                foreach (GameObject obj in availableEnemies)
                {
                    if (Vector3.Distance(obj.transform.position, transform.position) > Vector3.Distance(enemy.transform.position, transform.position))
                    {
                        enemy = obj;
                    }
                }
                break;
            default:
                Debug.LogError(algorithm + " not implemented");
                break;
        }
        return enemy;
    }

    void Kill(GameObject obj)
    {
        Destroy(obj);
        availableEnemies.Remove(obj);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (!availableEnemies.Contains(other.gameObject))
            {
                availableEnemies.Add(other.gameObject);
            }
        }
    }
}
