using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphSphere : MonoBehaviour
{
    public LineRenderer xLineRenderer;
    public LineRenderer yLineRenderer;
    public ControlSphere controlSphere;
    private Vector3 startingPosition;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
        transform.position = new Vector3(startingPosition.x + controlSphere.distance, startingPosition.y + Mathf.Sin(controlSphere.distance), startingPosition.z);
        //transform.position = new Vector3(controlSphere.transform.position.x, transform.position.y, transform.position.z);
        //distance = startingPosition.x - transform.position.x;
    }

    void Draw()
    {
        xLineRenderer.positionCount = 2;
        Vector3 xStartPosition = new Vector3(transform.parent.position.x, transform.position.y, transform.position.z);
        xLineRenderer.SetPosition(0, xStartPosition);
        xLineRenderer.SetPosition(1, transform.position);

        yLineRenderer.positionCount = 2;
        Vector3 yStartPosition = new Vector3(transform.position.x, transform.parent.position.y, transform.position.z);
        yLineRenderer.SetPosition(0, yStartPosition);
        yLineRenderer.SetPosition(1, transform.position);
    }
}
