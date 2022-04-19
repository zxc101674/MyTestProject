using UnityEngine.Events;
using UnityEngine;

namespace Game.Controller
{
    public class BaseInputController : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<bool> OnMoveForward = new UnityEvent<bool>();
        [HideInInspector] public UnityEvent<bool> OnMoveBack = new UnityEvent<bool>();
        [HideInInspector] public UnityEvent<bool> OnMoveLeft = new UnityEvent<bool>();
        [HideInInspector] public UnityEvent<bool> OnMoveRight = new UnityEvent<bool>();

        [HideInInspector] public UnityEvent OnClose = new UnityEvent();

        protected void Press(KeyCode key, UnityEvent<bool> e)
        {
            if (Input.GetKeyDown(key)) e.Invoke(true);
            if (Input.GetKeyUp(key)) e.Invoke(false);
        }

        protected void Click(KeyCode key, UnityEvent e)
        {
            if (Input.GetKeyDown(key)) e.Invoke();
        }
    }
}
