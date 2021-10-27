using UnityEngine;


namespace InputManagement
{
    [RequireComponent(typeof(Camera))]
    public class ClickAndDragCamera : MonoBehaviour
    {
        #region Scene References
        [SerializeField] private RectTransform tf_panel;
        [SerializeField] private InputManager inputManager;
        #endregion

        #region Private Fields
        private Rect cameraWorldRect;
        private Vector2 minPos, maxPos, clickPos;
        private Vector3 startPos, delta;
        private bool isFocused;
        #endregion

        #region UnityEvents
        private void Awake()
        {
            SetBounds();
            startPos = transform.position;
            cameraWorldRect = new Rect(minPos, maxPos - minPos);
        }

        private void OnEnable()
        {
            inputManager.OnStartClick += SetStartPos;
            inputManager.OnPerformClick += SetCurrentPos;
        }

        private void OnDisable()
        {
            inputManager.OnStartClick -= SetStartPos;
            inputManager.OnPerformClick -= SetCurrentPos;
        }

        private void LateUpdate()
        {

        }
        #endregion

        #region Private Methods

        private void SetBounds()
        {
            Camera cam = this.GetComponent<Camera>();
            Vector2 camSize = cam.rect.size * cam.orthographicSize * new Vector2(cam.aspect, 1);
            minPos = tf_panel.rect.position + camSize;
            maxPos = minPos + tf_panel.rect.size - 2f * camSize;
        }

        private static Vector3 GetMouseWorldPosition(Vector3 mousePos)
        {
            Plane plane = new Plane(Vector3.back, Vector2.zero);
            Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
            plane.Raycast(mouseRay, out float dist);
            return mouseRay.GetPoint(dist);
        }

        private void SetStartPos(Vector2 pos)
        {
            delta = Vector3.zero;
            clickPos = pos;
            //Debug.Log("CLICK: " + clickPos);        
            startPos = transform.position;
        }
        private void SetCurrentPos(Vector2 pos)
        {
            delta = pos - clickPos;
            //Debug.Log("DELTA: " + delta);
            MoveCamera();
        }

        private void MoveCamera()
        {
            Vector3 newPos = startPos - delta * 0.02f;
            newPos.x = Mathf.Clamp(newPos.x, minPos.x, maxPos.x);
            newPos.y = Mathf.Clamp(newPos.y, minPos.y, maxPos.y);
            transform.position = newPos;
        }
        #endregion
    } 
}
