using UnityEngine;

namespace Game.Controller
{
    public class KeyboardInputController : BaseInputController
    {
        private void Update()
        {
            Press(KeyCode.W, OnMoveForward);
            Press(KeyCode.A, OnMoveLeft);
            Press(KeyCode.S, OnMoveBack);
            Press(KeyCode.D, OnMoveRight);

            Click(KeyCode.Escape, OnClose);
        }
    }
}
