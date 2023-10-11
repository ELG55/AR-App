using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheresController : MonoBehaviour
{
    public GameObject controlSphere;
    public GameObject touchPointer;

    public Camera arCamera;
    private Vector2 touchPosition = default;
    private bool onTouchHold = false;
    public Vector2 xLimits = new Vector2(0, 1);

    void Awake()
    {
        arCamera = GameObject.FindWithTag("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.transform.CompareTag("ControlSphere"))
                    {
                        onTouchHold = true;
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
        }

        if (onTouchHold)
        {
            //Store control sphere position for convenience
            Vector3 controlSpherePosition = controlSphere.transform.localPosition;
            //Get a Vector3 indicating where was a touch made on an imaginary plane based on the control sphere
            Vector3 touchPositionAlongSpherePlane = GetTouchPositionOnYPlane(controlSphere);
            //An empty GameObject was made to position it on the touch location,
            //then retrieve its local position and assign the x axis on the sphere
            touchPointer.transform.position = touchPositionAlongSpherePlane;
            Vector3 newPosition = new Vector3(touchPointer.transform.localPosition.x, controlSpherePosition.y, controlSpherePosition.z);

            //If new position is between the range of xLimits, taking into account the initial position
            if (newPosition.x >= (controlSphere.GetComponent<ControlSphere>().startingPosition.x + xLimits.x) &&
                newPosition.x <= (controlSphere.GetComponent<ControlSphere>().startingPosition.x + xLimits.y))
            {
                controlSphere.transform.localPosition = newPosition;
            }
        }
    }

    //This method creates an imaginary plane on an object (control sphere), then returns a Vector3
    //with the location where the touch of the screen colllides with the imaginary plane
    Vector3 GetTouchPositionOnYPlane(GameObject movingObject)
    {
        Plane p = new Plane(movingObject.transform.up, movingObject.transform.position);
        //Only for debugging:
        //DrawPlane(movingObject.transform.position, movingObject.transform.up);
        Ray r = arCamera.ScreenPointToRay(touchPosition);
        float d;
        if (p.Raycast(r, out d))
        {
            Vector3 v = r.GetPoint(d);
            return v;
        }

        throw new UnityException("Touch position not intersecting sphere plane.");
    }

    //Method for debugging below. This draws a debug plane
    /*public void DrawPlane(Vector3 position, Vector3 normal)
    {
        Vector3 v3;

        if (normal.normalized != Vector3.forward)
            v3 = Vector3.Cross(normal, Vector3.forward).normalized * normal.magnitude;
        else
            v3 = Vector3.Cross(normal, Vector3.up).normalized * normal.magnitude; ;

        var corner0 = position + v3;
        var corner2 = position - v3;
        var q = Quaternion.AngleAxis(90.0f, normal);
        v3 = q * v3;
        var corner1 = position + v3;
        var corner3 = position - v3;

        Debug.DrawLine(corner0, corner2, Color.green);
        Debug.DrawLine(corner1, corner3, Color.green);
        Debug.DrawLine(corner0, corner1, Color.green);
        Debug.DrawLine(corner1, corner2, Color.green);
        Debug.DrawLine(corner2, corner3, Color.green);
        Debug.DrawLine(corner3, corner0, Color.green);
        Debug.DrawRay(position, normal, Color.red);
    }*/
}
