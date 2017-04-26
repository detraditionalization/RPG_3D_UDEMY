using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    float maxHealth = 100f;

    float currentHealth = 70f;

    public float healthAsPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }


}
