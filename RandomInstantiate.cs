using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstantiate : MonoBehaviour
{
    public Transform unbreakableWalls1;
    public Transform unbreakableWalls2;
    public Transform breakableAstroid1;
    public Transform breakableAstroid2;
    public Transform breakableAstroid3;

    public int spawnObjectArea = 15;
    public int spawnTimeInterval = 3;
    public float objectInterval = 50f;
    private Rigidbody m_rigidbody;
    private float timer = 0;
    private System.Random rnd = new System.Random();  // A seed to generate random numbers
    public Vector3 obstaclePos = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > spawnTimeInterval)
        {
            Generate();
            Generate();
            Generate();
            timer = rnd.Next(spawnTimeInterval);
        }

    }

    private void Generate()
    {
        int whichone = rnd.Next(5);  // generate a random number to decide which obstacle to instantiate
        switch (rnd.Next(5))
        {
            case 0:
                Instantiate(unbreakableWalls1, new Vector3((float)rnd.NextDouble() * 2 * spawnObjectArea - spawnObjectArea + transform.position.x, (float)rnd.NextDouble() * 2 * spawnObjectArea - spawnObjectArea + transform.position.y, transform.position.z + (float)rnd.NextDouble() * objectInterval), Quaternion.identity);
                break;
            case 1:
                Instantiate(unbreakableWalls2, new Vector3((float)rnd.NextDouble() * 2 * spawnObjectArea - spawnObjectArea + transform.position.x, (float)rnd.NextDouble() * 2 * spawnObjectArea - spawnObjectArea + transform.position.y, transform.position.z + objectInterval), Quaternion.identity);
                break;
            case 2:
                Instantiate(breakableAstroid1, new Vector3((float)rnd.NextDouble() * 2 * spawnObjectArea - spawnObjectArea + transform.position.x, (float)rnd.NextDouble() * 2 * spawnObjectArea - spawnObjectArea + transform.position.y, transform.position.z + objectInterval), Quaternion.identity);
                break;
            case 3:
                Instantiate(breakableAstroid2, new Vector3((float)rnd.NextDouble() * 2 * spawnObjectArea - spawnObjectArea + transform.position.x, (float)rnd.NextDouble() * 2 * spawnObjectArea - spawnObjectArea + transform.position.y, transform.position.z + objectInterval), Quaternion.identity);
                break;
            case 4:
                Instantiate(breakableAstroid3, new Vector3((float)rnd.NextDouble() * 2 * spawnObjectArea - spawnObjectArea + transform.position.x, (float)rnd.NextDouble() * 2 * spawnObjectArea - spawnObjectArea + transform.position.y, transform.position.z + objectInterval), Quaternion.identity);
                break;
        }

    }
}
