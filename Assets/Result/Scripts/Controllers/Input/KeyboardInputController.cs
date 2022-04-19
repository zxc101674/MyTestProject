using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Result.Controller
{
    public class KeyboardInputController : BaseInputController
    {
        private void Update()
        {
            Click(KeyCode.Escape, OnClose);
        }
    }
}
