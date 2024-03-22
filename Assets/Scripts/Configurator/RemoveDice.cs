using UnityEngine;
using UnityEngine.UI;

namespace Configurator
{
    /// <summary>
    /// Removes Dice from frontend and DiceManager on a click.
    /// </summary>
    public class RemoveDice : MonoBehaviour
    {
        private DiceManager _diceManager;
        private Image _image;
        private Button _imgButton;

        /// <summary>
        /// Gets button and image of the Game object ist attached to and adds an listener for onClick.
        /// </summary>
        private void Start()
        {
            _diceManager = DiceManager.Manager;

            _image = GetComponent<Image>();
            _imgButton = GetComponent<Button>();
            _imgButton.onClick.AddListener(RemoveOnClick);
        }

        /// <summary>
        /// Hides the image and the Dice from DiceManager, only if the last image ist clicked.
        /// </summary>
        private void RemoveOnClick()
        {
            if (_image.name != "Dice Image " + _diceManager.diceCounter) return;
            _image.gameObject.SetActive(false);
            _diceManager.RemoveLastDice();
            _diceManager.CountDown();
        }
    }
}