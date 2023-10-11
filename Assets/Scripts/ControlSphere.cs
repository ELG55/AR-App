using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ControlSphere : MonoBehaviour
{
    public float distance;
    public Vector3 startingPosition;
    private GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        //Leave an origin object for reference
        origin = new GameObject("Control sphere origin");
        origin.transform.SetParent(transform.parent);
        origin.transform.position = transform.position;
        origin.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        startingPosition = origin.transform.localPosition;
        distance = transform.localPosition.x - startingPosition.x;
    }
}
