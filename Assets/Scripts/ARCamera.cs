using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCamera : MonoBehaviour
{
    private Canvas arCanvas;
    // Start is called before the first frame update
    void Start()
    {
        arCanvas = GetComponent<Canvas>();
        arCanvas.worldCamera = GameObject.FindWithTag("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
