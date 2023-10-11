using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionReset : MonoBehaviour
{
    void Start()
    {
        GetComponent<ARSession>().Reset();
    }
}
