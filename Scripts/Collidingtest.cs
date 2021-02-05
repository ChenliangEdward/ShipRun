using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidingtest : MonoBehaviour
{
    public AudioClip collideAudio;
    private ShipProperty shipProperty;
    private Collider collider;
    //Start is called before the first frame update
    void Start()
    {
        shipProperty = GetComponentInChildren<ShipProperty>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(shipProperty.currentShipHealth);
    }
    private void OnTriggerEnter(Collider collider)
    {
        shipProperty.currentShipHealth = shipProperty.currentShipHealth - 10;
        // AudioSource.PlayClipAtPoint(collideAudio,transform.position);
    }
}
