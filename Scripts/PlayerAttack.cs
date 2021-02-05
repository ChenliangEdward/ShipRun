using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int shootingDamage = 1;
    public float shootingRange = 500.0f;
    public AudioClip shootingAudio;
    public float timeBetweenShooting = 0.001f;
    private LineRenderer gunLine;

    private float timer;
    private Ray ray;
    private RaycastHit hitInfo;
    void Start()
    {
        gunLine = GetComponent<LineRenderer>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timer > timeBetweenShooting)
        {
            timer = 0f;
            Invoke("shoot", 0.01f);
        }
        else
        {
            timer = timer + Time.deltaTime;
            gunLine.enabled = false;
        }
    }

    void shoot()
    {
        AudioSource.PlayClipAtPoint(shootingAudio, transform.position);
        ray.origin = transform.position;
        ray.direction = transform.forward;
        gunLine.SetPosition(0, transform.position);
        if (Physics.Raycast(ray, out hitInfo, shootingRange))
        {
            if (hitInfo.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Hit");
                EnemyHealth enemyhealth = hitInfo.collider.gameObject.GetComponent<EnemyHealth>();
                if (enemyhealth != null)
                {
                    enemyhealth.TakeDamage(shootingDamage);
                }
            }
            gunLine.SetPosition(1, hitInfo.point);
        }
        else gunLine.SetPosition(1, ray.origin + ray.direction * shootingRange);  // If not hit
        gunLine.enabled = true;
    }
}
