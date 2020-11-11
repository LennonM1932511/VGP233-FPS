using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private float _health;
    [SerializeField] private int _bombs;

    public int Value { get { return _value; } private set { _value = value; } }
    public float Health { get { return _health; } private set { _health = value; } }
    public int Bombs { get { return _bombs; } private set { _bombs = value; } }

    public void Collect()
    {
        if (_value > 0)
        {
            ServiceLocator.Get<GameManager>().UpdateScore(_value);
            Debug.Log(_value + " points collected!");
        }

        if (_health > 0)
        {
            ServiceLocator.Get<GameManager>().UpdateHealth(_health);
            Debug.Log("Player gained " + _health + " health!");
        }

        if (_bombs > 0)
        {
            ServiceLocator.Get<GameManager>().UpdateBombs(_bombs);
            Debug.Log("Player gained " + _bombs + " bombs!");
        }

        gameObject.SetActive(false);
    }
}
