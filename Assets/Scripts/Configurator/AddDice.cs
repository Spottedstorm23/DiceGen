using UnityEngine;
using UnityEngine.UI;

namespace Configurator
{
    /// <summary>
    /// Class for all necessary actions to add a dice to the current configuration. This includes backend settings as well as frontend settings.
    /// </summary>
    /// <description>
    /// <para>
    /// This class stores all necessary functions to add a dice in frontend as well as in backend.
    /// In general it is created to add up to 10 different dices.
    /// </para>
    /// <para>
    /// Set dice in <see cref="DiceManager"/>:
    /// On adding a dice it's configuration will be stored in the DiceManager
    /// </para>
    /// <para>
    /// Set dice in Frontend:
    /// When a dice is added, a graphic of its type and color will appear in the scene.
    /// </para>
    /// <param name="typeSelect">Dropdown to select a specif diceType. Set in Scene </param>
    /// <param name="colorSelect">Dropdown to select a specif color. Set in Scene </param>
    /// <param name="diceImages">10 Images where the dice graphics will be displayed. Set in Scene </param>
    /// <param name="Warning">Text and Icon to provide warning feedback. Set in Scene </param>
    /// </description>
    public class AddDice : MonoBehaviour
    {
        /*
         * Dropdowns to configure a dice, they are set in the scene
         */
        [SerializeField] private Dropdown typeSelect;
        [SerializeField] private Dropdown colorSelect;
        [SerializeField] private Image[] diceImages;

    
        /*
         *  Objects that are needed to display a warning if necessary
         */
        [SerializeField] private Text warningText;
        [SerializeField] private Image warningIcon;

        /*
         * private Objects as helpers
         */
        private Button _add;
        private DiceManager _diceManager;

        /// <summary>
        /// Sets the private Helperobjects <c>_add</c> and <c>_diceManager</c>.
        /// Also adds the onClick-ActionListener to the button the script is attached to.
        /// </summary>
        private void Start()
        {
            _add = GetComponent<Button>();
            _add.onClick.AddListener(AddDiceOnClick);
            _diceManager = DiceManager.Manager;
        }

        /// <summary>
        /// Combines all necessary actions to create a dice
        /// </summary>
        /// <description>
        /// <para>
        /// Function gets color and type of the dice from the Dropdowns.
        /// If these are not set a warning is issued to the user.
        /// </para>
        /// <para>
        /// If set the dice is added to the frontend as well as stored in <see cref="DiceManager"/>'s AllDice-Array.
        /// Also the counter of the dices in general will be updated.
        /// </para>
        /// </description>
        private void AddDiceOnClick()
        {
            var color = (DiceColors)colorSelect.value;
            var diceType = (DiceTypes)typeSelect.value;
            var spriteName = diceType + "_" + color;
            var numberOfDice = _diceManager.diceCounter;

            ResetWarning();

            if (diceType == DiceTypes.None || color == DiceColors.None)
            {
                warningText.text = "Please make sure to have Dice and Color selected!";
                warningIcon.gameObject.SetActive(true);
                return;
            }

            AddDiceToFrontend(numberOfDice, diceType.ToString(), spriteName);

            _diceManager.AddDiceToConfiguration(new Dice(diceType, color));
            _diceManager.CountUp();

            if (_diceManager.diceCounter == 10)
            {
                HideAddButton();
            }
        }

        /// <summary>
        /// Adds a dice graphic to its place in the frontend. 
        /// </summary>
        /// <param name="diceNumber">Integer with the current number of dices in configuration.</param>
        /// <param name="diceTypeString">String with the type e.g. "D2" or "D10"</param>
        /// <param name="spriteName">String with the Path/Name String corresponding to the combination"</param>
        private void AddDiceToFrontend(int diceNumber, string diceTypeString, string spriteName)
        {
            diceImages[diceNumber].gameObject.SetActive(true);
            diceImages[diceNumber].sprite = Resources.Load<Sprite>(diceTypeString + "/" + spriteName);
       }

        /// <summary>
        /// Resets the warning text to an empty text and hides the icon.
        /// </summary>
        private void ResetWarning()
        {
            warningText.text = "";
            warningIcon.gameObject.SetActive(false);
        }

        /// <summary>
        /// Hides the add button, so it cannot be click anymore.
        /// </summary>
        private void HideAddButton()
        {
            _add.gameObject.SetActive(false);
        }
    }
}