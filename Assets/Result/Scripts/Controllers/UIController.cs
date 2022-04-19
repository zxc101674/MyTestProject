using UnityEngine;

namespace Result.Controller
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UI.DataUI dataUI;

        public void Show(SaveData data) => dataUI.Show(data);
    }
}
