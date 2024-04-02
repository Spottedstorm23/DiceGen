using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
    /// <summary>
    /// As a serif font is used in the tutorials, this adds the option to change it to a non serif font for better readability
    /// </summary>
    public class FontChange : MonoBehaviour
    {
        [SerializeField] private Text[] allTexts;
        [SerializeField] private Toggle noSerif;
        [SerializeField] private Font serifFont;
        [SerializeField] private Font noSerifFont;


        private void Start()
        {
            noSerif.onValueChanged.AddListener((_ => ChangeFont()));
        }

        /// <summary>
        /// Inverts the font to either serif font or no serif font and sets the necessary textsize
        /// </summary>
        private void ChangeFont()
        {
            foreach (var t in allTexts)
            {
                t.font = t.font == noSerifFont ? serifFont : noSerifFont;
                t.fontSize = t.font == noSerifFont ? 16 : 18;
            }
        }
    }
}