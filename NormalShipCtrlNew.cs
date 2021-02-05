using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShipCtrlNew : MonoBehaviour
{
    internal Vector3 input;
    internal ShipMoveNew shipMove;

    // Start is called before the first frame update
    void Start()
    {
        shipMove = GetComponent<ShipMoveNew>();
    }

    // Update is called once per frame
    void Update()
    {
        input.Set(Input.GetAxis("Horizontal"), Input.GetAxis("UpDown"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        shipMove.OnMove(input);
    }
}
