using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameObjects
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private Controller.SceneController sceneController;

        private bool isFinished;
        private MainCharacter character;

        private void OnCollisionEnter(Collision collision)
        {
            character = collision.transform?.GetComponent<MainCharacter>();
            if (character && !isFinished)
            {
                isFinished = true;
                character.Stop();
                sceneController.Finish(true);
            }
        }
    }
}
