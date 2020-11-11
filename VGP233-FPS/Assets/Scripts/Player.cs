using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    public void TakeDamage(float damage)
    {
        ServiceLocator.Get<GameManager>().UpdateHealth(-damage);
    }

    public void HealDamage(float health)
    {
        ServiceLocator.Get<GameManager>().UpdateHealth(health);
    }
}
