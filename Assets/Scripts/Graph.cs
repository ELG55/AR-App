using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject graphSphere;
    public SineFunction sineFunction;

    //public float amplitude = 0.5f;
    //public float frequency = 0.5f;
    public int points;
    private float offsetX;
    private float offsetY;
    //public float offsetX = -0.5f;
    //public float offsetY = 0.2f;

    public Vector2 xLimits = new Vector2(0, 1);

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        offsetX = graphSphere.transform.localPosition.x;
        offsetY = graphSphere.transform.localPosition.y;
        Draw();
    }

    void Draw()
    {
        float xStart = xLimits.x;
        //float tau = 2 * Mathf.PI;
        float xFinish = xLimits.y;

        lineRenderer.positionCount = points;
        for(int currentPoints = 0; currentPoints < points; currentPoints++)
        {
            float progress = (float)currentPoints / (points - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = sineFunction.CalculateYValue(x);
            //float y = amplitude * Mathf.Sin(tau * frequency * x);
            lineRenderer.SetPosition(currentPoints, new Vector3(offsetX + x, offsetY + y, transform.localPosition.z));

            //In case a simpler graph is needed
            //float y = Mathf.Sin(x);
        }
    }
}
