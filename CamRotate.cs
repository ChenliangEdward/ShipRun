using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public Transform Cam;
    public float camRotateSpeed = 3.0f;
    public float minMouseRotateX = -75.0f;
    public float maxMouseRotateX = 75.0f;

    private float mouseRotateX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rv = Input.GetAxisRaw("Mouse X");
        float rh = Input.GetAxisRaw("Mouse Y");
        Rotate(rh, rv);
    }

    void Rotate(float rh, float rv)
    {
        transform.Rotate(0, rv * camRotateSpeed, 0);
        mouseRotateX -= rh * camRotateSpeed;
        mouseRotateX = Mathf.Clamp(mouseRotateX, minMouseRotateX, maxMouseRotateX);
        Cam.transform.localEulerAngles = new Vector3(mouseRotateX, 0.0f, 0.0f);
    }
}
