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
    public bool isReady = false;
    public GameObject lookAtAs;
    public float animDelay = 0f;

    float remainingTime = 0;
    List<GameObject> availableEnemies = new List<GameObject>();
    GameObject lastAttackedEnemy = null;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();    
        if (lookAtAs == null)
        {
            lookAtAs = gameObject;
        }
        else
        {
            Debug.LogWarning("lookAtAs not set", this);
        }
    }

    void Update()
    {
        if (isReady)
        {
            availableEnemies.RemoveAll(obj => obj == null);

            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                remainingTime = cooldown;
                Attack();
            }
            if (lastAttackedEnemy)
            {
                Vector3 lookAt = new Vector3(
                    lastAttackedEnemy.transform.position.x,
                    lookAtAs.transform.position.y,
                    lastAttackedEnemy.transform.position.z
                );
                lookAtAs.transform.LookAt(lookAt);
            }
        }
    }

    void Attack()
    {
        if (availableEnemies.Count > 0)
        {
            GameObject enemy = GetEnemyToAttack();
            var unitStats = enemy.GetComponent<UnitStats>();

            if (unitStats)
            {
                StartCoroutine(RemoveEnemyHP(unitStats));
            }
            else
            {
                Debug.LogError("No Unit Stats attached to Enemy");
            }
            anim.SetTrigger("Attack");
            lastAttackedEnemy = enemy;
        }
    }

    IEnumerator RemoveEnemyHP(UnitStats unitStats)
    {
        yield return new WaitForSeconds(animDelay);
        unitStats.hp -= damage;

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

    public void AddEnemy(GameObject obj)
    {
        if (!availableEnemies.Contains(obj))
        {
            availableEnemies.Add(obj);
        }
    }

    public void RemoveEnemy(GameObject obj)
    {
        availableEnemies.Remove(obj);
    }
}
