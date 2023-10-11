using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphSphere : MonoBehaviour
{
    public LineRenderer xLineRenderer;
    public LineRenderer yLineRenderer;
    public ControlSphere controlSphere;
    private Vector3 startingPosition;
    private GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
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
        float customDistance = distance * 2;
        float amplitude = 0.5f;
        float frequency = 0.5f;
        //float offsetY = 0.2f;
        float tau = 2 * Mathf.PI;
        float yValue = amplitude * Mathf.Sin(tau * frequency * customDistance);
        transform.localPosition = new Vector3(startingPosition.x + customDistance, startingPosition.y + yValue, startingPosition.z);
    }

    void Draw()
    {
        xLineRenderer.positionCount = 2;
        Vector3 xStartPosition = new Vector3(startingPosition.x, transform.localPosition.y, transform.localPosition.z);
        xLineRenderer.SetPosition(0, xStartPosition);
        xLineRenderer.SetPosition(1, transform.localPosition);

        yLineRenderer.positionCount = 2;
        Vector3 yStartPosition = new Vector3(transform.localPosition.x, startingPosition.y, transform.localPosition.z);
        yLineRenderer.SetPosition(0, yStartPosition);
        yLineRenderer.SetPosition(1, transform.localPosition);
    }
}
