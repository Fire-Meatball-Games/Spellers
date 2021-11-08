using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResponsive : MonoBehaviour
{
    public float widthUnits = 10;
    public float minHeightUnits = 5;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    [ExecuteInEditMode]
    private void Update()
    {
        SetResponsiveCamera();
    }

    private void SetResponsiveCamera()
    {
        if(cam == null)
            cam = GetComponent<Camera>();
        cam.orthographicSize = Mathf.Max(widthUnits / cam.aspect, minHeightUnits);
    }
   
}
