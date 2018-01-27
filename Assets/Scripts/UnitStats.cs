using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStats : MonoBehaviour
{
    [System.Serializable]
    public struct Status
    {
        public bool poison;
        public bool stun;
    };

    public float hpMax;
    [System.NonSerialized]
    public float hp;
    public float damage;
    public float speed;
    public Status status;

    public Slider healthBar;

    void Awake()
    {
        hp = hpMax;
        if (healthBar)
        {
            healthBar.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        // Update UI
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar)
        {
            healthBar.value = Mathf.Clamp01(hp / hpMax);
            if (!healthBar.gameObject.activeSelf && hp < hpMax)
            {
                healthBar.gameObject.SetActive(true);
            }
        }
    }
}
