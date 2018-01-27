using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStats : MonoBehaviour
{
    public float hpMax;
    [System.NonSerialized]
    public float hp;
    public float damage;
    public float speed;

    public Slider healthBar;

    void Awake()
    {
        hp = hpMax;
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
        }
    }
}
