using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Result.Controller
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private BaseInputController input;
        [SerializeField] private UIController ui;

        private void Start()
        {
            if (SaveController.isHasSave)
            {
                ui.Show(SaveController.Load());
            }

            input.OnClose.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(0));
        }
    }
}
