using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace Game.Controller
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UI.TimeUI timeUI;

        public void ShowTime(int sec) => timeUI.Show(sec);
    }
}
