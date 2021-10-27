using UnityEngine;
using UnityEngine.InputSystem;

namespace InputManagement
{
    public class InputManager : MonoBehaviour
    {
        private InputPlayerMap map;

        public delegate void StartClickEvent(Vector2 position);
        public event StartClickEvent OnStartClick;
        public delegate void EndClickEvent(Vector2 position);
        public event EndClickEvent OnEndClick;
        public delegate void PerformClickEvent(Vector2 position);
        public event PerformClickEvent OnPerformClick;


        private void Awake()
        {
            map = new InputPlayerMap();
        }

        private void OnEnable()
        {
            map.Enable();
        }

        private void OnDisable()
        {
            map.Disable();
        }

        private void Start()
        {
            map.Player.Click.started += ctx => StartClick(ctx);
            map.Player.Click.canceled += ctx => EndClick(ctx);
            map.Player.Position.performed += ctx => PerformClick(ctx);
        }

        private void StartClick(InputAction.CallbackContext ctx)
        {
            //Debug.Log("StartClick");
            OnStartClick?.Invoke(map.Player.Position.ReadValue<Vector2>());
        }

        private void EndClick(InputAction.CallbackContext ctx)
        {
            //Debug.Log("EndClick");
            OnEndClick?.Invoke(map.Player.Position.ReadValue<Vector2>());
        }

        private void PerformClick(InputAction.CallbackContext ctx)
        {
            if (map.Player.Click.phase == InputActionPhase.Performed || map.Player.Click.phase == InputActionPhase.Started)
            {
                //Debug.Log("Perform");
                OnPerformClick?.Invoke(ctx.ReadValue<Vector2>());
            }
        }
    } 
}


