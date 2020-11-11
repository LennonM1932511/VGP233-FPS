using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DestructableObject : MonoBehaviour, IDamagable
{
    public float MaxHealth = 100.0f;
    public int PointsValue = 10;

    public GameObject enemyExplodePrefab;
    public VisualEffect enemyExplode;

    private float currentHealth;

    void Awake()
    {
        currentHealth = MaxHealth;
        enemyExplode.Stop();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " took " + Mathf.RoundToInt(damage).ToString() + " damage and has " + Mathf.RoundToInt(currentHealth).ToString() + " health remaining.");
        CheckIsAlive();
    }

    private bool CheckIsAlive()
    {
        if (currentHealth <= 0)
        {
            GameObject explosion = Instantiate(enemyExplodePrefab, transform.position, Quaternion.identity);
            enemyExplode.Play();

            // update log and HUD
            Debug.Log(transform.name + " is destroyed! You gain " + PointsValue.ToString() + " points!");
            ServiceLocator.Get<GameManager>().UpdateScore(PointsValue);
            ServiceLocator.Get<GameManager>().UpdateKills();

            // destroy
            Destroy(gameObject);
            return false;
        }
        return true;
    }
}
