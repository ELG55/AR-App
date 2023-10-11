using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphSphere : MonoBehaviour
{
    public LineRenderer xLineRenderer;
    public LineRenderer yLineRenderer;
    public SineFunction sineFunction;
    public ControlSphere controlSphere;
    private Vector3 startingPosition;
    private GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        //Leave an origin object for reference
        origin = new GameObject("Graph sphere origin");
        origin.transform.SetParent(transform.parent);
        origin.transform.position = transform.position;
        origin.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        startingPosition = origin.transform.localPosition;
        Draw();

        float distance = controlSphere.distance;
        float x = distance * 2;
        float yValue = sineFunction.CalculateYValue(x);
        transform.localPosition = new Vector3(startingPosition.x + x, startingPosition.y + yValue, startingPosition.z);
    }

    void Draw()
    {
        //Drawing the horizontal line (x)
        xLineRenderer.positionCount = 2;
        Vector3 xStartPosition = new Vector3(startingPosition.x, transform.localPosition.y, transform.localPosition.z);
        xLineRenderer.SetPosition(0, xStartPosition);
        xLineRenderer.SetPosition(1, transform.localPosition);

        //Drawing the vertical line (y)
        yLineRenderer.positionCount = 2;
        Vector3 yStartPosition = new Vector3(transform.localPosition.x, startingPosition.y, transform.localPosition.z);
        yLineRenderer.SetPosition(0, yStartPosition);
        yLineRenderer.SetPosition(1, transform.localPosition);
    }
}
