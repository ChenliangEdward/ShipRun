using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public int health = 100;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            isAlive = false;
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health < 0)
            health = 0;
    }
}
