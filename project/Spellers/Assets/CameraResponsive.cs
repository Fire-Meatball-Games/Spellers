using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;

public class CameraResponsive : MonoBehaviour
{
    public float widthUnits = 10;
    public float minHeightUnits = 5;
    public Transform tf_side;
    public Transform center_side;
    private Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponent<Camera>();
       
    }

    private void OnEnable()
    {
        Events.OnBattleBegins.AddListener(MoveToSide);
    }

    private void OnDisable()
    {
        Events.OnBattleBegins.RemoveListener(MoveToSide);
    }
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

    private void MoveToSide()
    {
        StartCoroutine(MoveCameraCorroutine(10, center_side.position, tf_side.position));
    }
    private IEnumerator MoveCameraCorroutine(int ticks, Vector3 startPos, Vector3 endPos)
    {
        startPos = new Vector3(startPos.x, startPos.y, cam.transform.position.z);
        endPos = new Vector3(endPos.x, endPos.y, cam.transform.position.z);
        cam.transform.position = startPos;
        float delta = 1.0f / ticks;
        for (int i = 0; i < ticks; i++)
        {
            float inc = (i + 1) * delta;
            cam.transform.position = Vector3.Lerp(startPos, endPos, inc);
            yield return new WaitForFixedUpdate();
        }
    }
   
}
