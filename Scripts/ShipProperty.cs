using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipProperty : MonoBehaviour
{
    public float startShipHealth = 100f;
    public float currentShipHealth;
    public float shipShootingRange = 100f;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        currentShipHealth = startShipHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if( currentShipHealth <= 0 )
        {
            isDead = true;
            Destroy(gameObject);
        }
    }
}
