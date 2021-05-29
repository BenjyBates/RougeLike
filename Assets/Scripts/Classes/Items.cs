using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [Header("Information")]
    public string Name;
    public GameObject Body;

    [Header("Health")]
    public float HealthRegen;

    private void OnMouseUp()
    {
        BattleManager.IsLooting = true;
    }
}
