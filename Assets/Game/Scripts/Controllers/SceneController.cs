using UnityEngine.Events;
using UnityEngine;

namespace Game.Controller
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private BaseInputController input;
        [SerializeField] private TimeController timer;
        [SerializeField] private UIController ui;

        [HideInInspector] public UnityEvent<bool> OnMoveForward = new UnityEvent<bool>();
        [HideInInspector] public UnityEvent<bool> OnMoveBack = new UnityEvent<bool>();
        [HideInInspector] public UnityEvent<bool> OnMoveLeft = new UnityEvent<bool>();
        [HideInInspector] public UnityEvent<bool> OnMoveRight = new UnityEvent<bool>();

        [HideInInspector] public UnityEvent<float> OnUpdateTimer = new UnityEvent<float>();

        [HideInInspector] public UnityEvent<bool> OnFinish = new UnityEvent<bool>();

        private void Start()
        {
            input.OnMoveForward.AddListener((bool isPress) => OnMoveForward.Invoke(isPress));
            input.OnMoveBack.AddListener((bool isPress) => OnMoveBack.Invoke(isPress));
            input.OnMoveLeft.AddListener((bool isPress) => OnMoveLeft.Invoke(isPress));
            input.OnMoveRight.AddListener((bool isPress) => OnMoveRight.Invoke(isPress));

            input.OnClose.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(0));

            timer.OnUpdateTimer.AddListener((int seconds) => ui.ShowTime(seconds));

        }

        public void Finish(bool res)
        {
            OnFinish.Invoke(res);
            SaveController.Save(res, timer.Seconds);
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
