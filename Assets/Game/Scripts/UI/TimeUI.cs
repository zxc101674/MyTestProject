using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class TimeUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void Show(int seconds)
        {
            text.text = "Секунды: " + seconds.ToString();
        }
    }
}
