using UnityEngine.Events;
using UnityEngine;

namespace Result.Controller
{
    public class BaseInputController : MonoBehaviour
    {
        [HideInInspector] public UnityEvent OnClose = new UnityEvent();

        protected void Click(KeyCode key, UnityEvent e)
        {
            if (Input.GetKeyDown(key)) e.Invoke();
        }
    }
}
