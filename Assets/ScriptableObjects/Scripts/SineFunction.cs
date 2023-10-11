using UnityEngine;

[CreateAssetMenu(fileName = "NewSineFunction", menuName = "Graph/New Sine Function")]
public class SineFunction : ScriptableObject
{
    public float amplitude;
    public float frequency;
    public float CalculateYValue(float x)
    {
        float tau = 2 * Mathf.PI;
        float yValue = amplitude * Mathf.Sin(tau * frequency * x);
        return yValue;
    }
}
