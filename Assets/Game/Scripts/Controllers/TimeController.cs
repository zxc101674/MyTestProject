using System.Collections;
using UnityEngine.Events;
using UnityEngine;

namespace Game.Controller
{
    public class TimeController : MonoBehaviour
    {
        private int seconds;

        public int Seconds => seconds;

        [HideInInspector] public UnityEvent<int> OnUpdateTimer = new UnityEvent<int>();

        void Start()
        {
            seconds = 0;
            StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                seconds += 1;
                OnUpdateTimer.Invoke(seconds);
            }
        }
    }
}
