using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float health;
    public Weapon CurrentWeapon;

    private void Awake()
    {

    }

    private void Update()
    {
        if(health <= 0)
        {
            health = 0;
        }
    }

}
