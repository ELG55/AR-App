using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class Rotation : MonoBehaviour
{
    private float sensitivity = 0.15f;
    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private Vector3 rotation = Vector3.zero;
    private bool isRotating;

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            //Offset
            mouseOffset = (Input.mousePosition - mouseReference);
            //Apply rotation
            rotation.y = -(mouseOffset.x + mouseOffset.y) * sensitivity;
            //Rotate
            gameObject.transform.Rotate(rotation);
            //Store new mouse position
            mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        //Rotating flag
        isRotating = true;
        //Store mouse position
        mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        //Rotating flag
        isRotating = false;
    }
}
