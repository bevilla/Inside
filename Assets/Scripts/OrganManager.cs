using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum E_OrganType
{
    BRAIN,
    HEART,
    INTESTINE,
    LUNGS,
    LIVER
}

public class OrganManager : MonoBehaviour
{

    [SerializeField]
    float maxHealth;
    float health;

    [SerializeField]
    E_OrganType organ;

    public Slider healthBar;

    private void Awake()
    {
        health = maxHealth;
        if (healthBar)
        {
            healthBar.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (healthBar)
        {
            healthBar.value = Mathf.Clamp01(health / maxHealth);
            if (!healthBar.gameObject.activeSelf && health < maxHealth)
            {
                healthBar.gameObject.SetActive(true);
            }
        }
    }

    void    death()
    {
        switch (organ)
        {
            case E_OrganType.BRAIN:
                OrgansInfos.instance.isBrainAlive = false;
                break;
            case E_OrganType.HEART:
                OrgansInfos.instance.isHeartAlive = false;
                break;
            case E_OrganType.INTESTINE:
                OrgansInfos.instance.isIntestinesAlive = false;
                break;
            case E_OrganType.LUNGS:
                OrgansInfos.instance.isLungsAlive = false;
                break;
            case E_OrganType.LIVER:
                OrgansInfos.instance.isLiverAlive = false;
                break;
        }
        OrgansInfos.instance.organCount--;
        OrgansInfos.instance.refreshOrganCountText();
        Destroy(gameObject);
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Enemy")
        {
            health -= col.collider.GetComponent<UnitStats>().damage;
            Destroy(col.collider.gameObject);
            if (health <= 0)
                death();
        }
    }
}
