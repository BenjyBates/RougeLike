using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Information")]
    public string Name;
    public float health;
    public float maxHealth;
    [Header("Attack Data")]
    public float attackDelay;
    public float attackDamage;

    public Items[] Loot;

    private void OnMouseUp()
    {
        BattleManager.BattleInteract = true;
    }
}
