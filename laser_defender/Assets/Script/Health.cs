using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    public int GetHealth()
    {
        return this.GetHealth();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            Debug.Log("Blood:" + health);
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }






}