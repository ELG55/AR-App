using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int points;
    //public float amplitude = 1;
    //public float frequency = 1;
    public Vector2 xLimits = new Vector2(0, Mathf.PI);

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Draw();
    }

    void Draw()
    {
        float xStart = xLimits.x;
        float tau = 2 * Mathf.PI;
        float xFinish = xLimits.y;

        lineRenderer.positionCount = points;
        for(int currentPoints = 0; currentPoints < points; currentPoints++)
        {
            float progress = (float)currentPoints / (points - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = Mathf.Sin(x);
            lineRenderer.SetPosition(currentPoints, new Vector3(x, y, 0));

            //In case a more detailed graph is needed
            //float y = amplitude * Mathf.Sin(tau * frequency * x);
        }
    }
}
