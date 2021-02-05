using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 10.0f;
    public int value = 1;
    public AudioClip enemyHurtAudio;
    public AudioClip enemyDestroyingAudio;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (int damage)
    {
        health = health - damage;
        if (enemyHurtAudio != null)
            AudioSource.PlayClipAtPoint(enemyHurtAudio, transform.position);
        if (health <= 0)
        {
            Destroy(gameObject);
            //Invoke("PlaySound", 1.0f);

        }
    }

    //private void PlaySound()
    //{
    //    AudioSource.PlayClipAtPoint(enemyDestroyingAudio, transform.position);
    //}
}
