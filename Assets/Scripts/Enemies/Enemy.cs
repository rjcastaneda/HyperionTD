using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float movementSpeed;

    public void Update()
    {
        if (health <= 0){ Death();  }
    }

    private void Death(){ Destroy(this); }
}

        
