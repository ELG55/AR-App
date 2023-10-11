using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject graphSphere;
    public SineFunction sineFunction;

    public int points;
    private float offsetX;
    private float offsetY;

    public Vector2 xLimits = new Vector2(0, 1);

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        offsetX = graphSphere.transform.localPosition.x;
        offsetY = graphSphere.transform.localPosition.y;
        Draw();
    }

    //Draws the graph
    void Draw()
    {
        float xStart = xLimits.x;
        float xFinish = xLimits.y;

        //Sets the total number of points in the graph and then cycles through them to set their positions
        lineRenderer.positionCount = points;
        for(int currentPoints = 0; currentPoints < points; currentPoints++)
        {
            float progress = (float)currentPoints / (points - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = sineFunction.CalculateYValue(x);
            lineRenderer.SetPosition(currentPoints, new Vector3(offsetX + x, offsetY + y, transform.localPosition.z));
        }
    }
}
