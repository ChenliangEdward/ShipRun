using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMoveNew : MonoBehaviour
{
    public Transform avatar;                    
    public float maxForwardSpeed = 10f;         
    public float forwoardAcc = 5f;             
    public float forwardDamp = 5f;           

    public float maxUpSpeed = 10f;              
    public float upAcc = 5f;                    
    public float upDamp = 5f;                  

    public float maxRotateSpeed = 10f;         
    public float rotateAcc = 5f;                
    public float rotateDamp = 5f;               

    public float maxPanSpeed = 10f;
    public float panAcc = 10f;
    public float panDamp = 5f;

    public float avatarUpAngle = 5f;
    public float avatarRotateAngle = 5f;      
    public float avatarPanAngle = 5f;           
    public float avatarAngleInterpolation = 5f; 

    private Vector3 moveDirection;
    private float nowForwardSpeed;
    private float nowUpSpeed;
    private float nowRotateSpeed;
    private float nowRotateAngle;
    private float nowPanSpeed;
    private float newmaxForwardSpeed;
    private float newforwardAcc;
    private Vector3 input;

    private Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        nowRotateAngle = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (avatar != null)
        {
            // Simulate the ship angle
            avatar.localRotation = Quaternion.Lerp(avatar.localRotation, Quaternion.Euler(avatarUpAngle * -(nowUpSpeed / maxUpSpeed), 0, avatarPanAngle * -(nowPanSpeed / maxPanSpeed) + avatarRotateAngle * -(nowRotateSpeed / maxRotateSpeed)), avatarAngleInterpolation * Time.deltaTime);
        }
    }

    public void OnMove(Vector3 input)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            newmaxForwardSpeed = maxForwardSpeed * 5;
            newforwardAcc = forwoardAcc * 5;
        }
        else
        {
            newmaxForwardSpeed = maxForwardSpeed;
            newforwardAcc = forwoardAcc;
        }

        this.input = input;
        // Rotation
        if (Input.GetKey(KeyCode.E))
        {
            nowRotateSpeed += rotateAcc * Time.fixedDeltaTime;
        }
        else
        {
            nowRotateSpeed = Mathf.Lerp(nowRotateSpeed, 0, rotateDamp * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            nowRotateSpeed += -rotateAcc * Time.fixedDeltaTime;
        }
        else
        {
            nowRotateSpeed = Mathf.Lerp(nowRotateSpeed, 0, rotateDamp * Time.fixedDeltaTime);
        }
        nowRotateSpeed = Mathf.Clamp(nowRotateSpeed, -maxRotateSpeed, maxRotateSpeed);

        nowRotateAngle = nowRotateAngle + nowRotateSpeed;
        m_rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, nowRotateAngle, 0), rotateDamp * Time.fixedDeltaTime));

        // Displacement
        //if (input.z > 0 || input.z < 0)
        //{
            //nowForwardSpeed += forwoardAcc * Time.fixedDeltaTime * input.z;
            //nowForwardSpeed = Mathf.Lerp(nowForwardSpeed, nowForwardSpeed + newforwardAcc * input.z, Time.fixedDeltaTime);
        nowForwardSpeed = Mathf.Lerp(nowForwardSpeed, nowForwardSpeed + newforwardAcc * 1, Time.fixedDeltaTime);
        //}
        //else
        //{
        //nowForwardSpeed = Mathf.Lerp(nowForwardSpeed, 0, forwardDamp * Time.fixedDeltaTime);
        //}
        nowForwardSpeed = Mathf.Clamp(nowForwardSpeed, -newmaxForwardSpeed, newmaxForwardSpeed);

        // UpDown
        if (input.y > 0 || input.y < 0)
        {
            nowUpSpeed = Mathf.Lerp(nowUpSpeed, nowUpSpeed + upAcc * input.y, Time.fixedDeltaTime);
        }
        else
        {
            nowUpSpeed = Mathf.Lerp(nowUpSpeed, 0, upDamp * Time.fixedDeltaTime);
        }
        nowUpSpeed = Mathf.Clamp(nowUpSpeed, -maxUpSpeed, maxUpSpeed);


        // Panning
        if (input.x > 0 || input.x < 0)
        {
            nowPanSpeed = Mathf.Lerp(nowPanSpeed, nowPanSpeed + panAcc * input.x, Time.fixedDeltaTime);
        }
        else
        {
            nowPanSpeed = Mathf.Lerp(nowPanSpeed, 0, panDamp * Time.fixedDeltaTime);
        }
        nowPanSpeed = Mathf.Clamp(nowPanSpeed, -maxPanSpeed, maxPanSpeed);

        moveDirection = transform.up * nowUpSpeed + transform.forward * nowForwardSpeed + transform.right * nowPanSpeed;
        m_rigidbody.MovePosition(transform.position + moveDirection);
    }

}
