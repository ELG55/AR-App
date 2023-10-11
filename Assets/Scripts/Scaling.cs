using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    private float initialFingersDistance;
    private Vector3 initialScale;
    private static Transform ScaleTransform;

    // Update is called once per frame
    void Update()
    {
		int fingersOnScreen = 0;

		foreach (Touch touch in Input.touches)
		{
			//Count touches on screen as this iterates through all screen touches
			fingersOnScreen++;

			//Two fingers on screen needed to pinch
			if (fingersOnScreen == 2)
			{
				//Set the initial distance between fingers so it can be compared
				if (touch.phase == TouchPhase.Began)
				{
					initialFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
					initialScale = ScaleTransform.localScale;
				}
				else
				{
					float currentFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);

					float scaleFactor = currentFingersDistance / initialFingersDistance;

					ScaleTransform.localScale = initialScale * scaleFactor;
				}
			}
		}
	}

	void OnMouseDown()
	{
		ScaleTransform = transform;
	}
}
