using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Start.Controller
{
    public class UIController : MonoBehaviour
    {
        public Button btn_res;

        public bool isDeleteSave;

        private void OnValidate()
        {
            if (isDeleteSave)
            {
                isDeleteSave = false;
                PlayerPrefs.DeleteAll();
                print("Saves is deleted");
            }
        }

        private void Start()
        {
            if (!SaveController.isHasSave)
            {
                btn_res.interactable = false;
            }
        }

        public void OpenGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

        public void OpenResult()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
