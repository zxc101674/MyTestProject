using TMPro;
using UnityEngine;

namespace Result.UI
{
    public class DataUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void Show(SaveData data)
        {
            if (data.res)
            {
                text.text = "Вы выиграли: " + data.sec.ToString();
            }
            else
            {
                text.text = "Вы проиграли";
            }
        }
    }
}
