using UnityEngine;
using UnityEngine.UI;

namespace RollScreen
{
    /// <summary>
    /// Helper Script that updates the DiceList in the RollScreen
    /// </summary>
    /// <param name="diceResultItems">The GameObjects that are the items of the Dicelist. They are set in scene.</param>
    /// <access>
    /// with <c>DiceResultUpdater.Updater</c>
    /// </access>
    public class DiceResultUpdater : MonoBehaviour
    {
        [SerializeField] private GameObject[] diceResultItems;
        public static DiceResultUpdater Updater;
        [SerializeField] private Toggle rollForHighest;

        private readonly Color _red = new Color(0.9058824f, 0.1568628f, 0.05882353f);
        private readonly Color _green = new Color(0.4235294f, 0.8705882f, 0f);
        private readonly Color _blue = new Color(0.7216981f, 1f, 0.9568667f);

        private void Start()
        {
            Updater = this;
            rollForHighest.onValueChanged.AddListener((bool _) => InvertColors());
        }

        /// <summary>
        /// Sets the diceResultItem corresponding to the current dice to active
        /// </summary>
        /// <param name="currentDice">Number of the dice that is currently worked on</param>
        public void ActivateResultItem(int currentDice)
        {
            diceResultItems[currentDice].SetActive(true);
        }

        /// <summary>
        /// Updates the image that shows if a dice is locked to the state it should show
        /// </summary>
        /// <param name="currentDice">Number of the dice that should be changed</param>
        /// <param name="keep"> Boolean if said dice is locked</param>
        public void UpdateLockIcon(int currentDice, bool keep)
        {
            var keepDice = diceResultItems[currentDice].transform.Find("Keep").GetComponent<Image>();
            keepDice.sprite =
                keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
        }

        /// <summary>
        /// Sets the dice's name that is displayed in the list
        /// </summary>
        /// <param name="currentDice">Number of the dice that should be displayed</param>
        /// <param name="diceType">String of the type</param>
        /// <param name="diceColor">String of the color</param>
        public void SetDiceName(int currentDice, string diceType, string diceColor)
        {
            var diceName = diceResultItems[currentDice].transform.Find("Dice Name").GetComponent<Text>();
            diceName.text = diceType + " " + diceColor;
        }

        /// <summary>
        /// Sets the dice's image that is displayed in the list
        /// </summary>
        /// <param name="currentDice">Number of the dice that should be displayed</param>
        /// <param name="diceType">String of the type</param>
        /// <param name="diceColor">String of the color</param>
        public void SetDiceImage(int currentDice, string diceType, string diceColor)
        {
            var diceImage = diceResultItems[currentDice].transform.Find("Dice Image").GetComponent<Image>();
            diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
        }

        /// <summary>
        /// Set the dice's result in the list
        /// </summary>
        /// <param name="currentDice">Number of the dice looked at</param>
        /// <param name="eyes">Number of eyes that were rolled</param>
        /// <param name="isD2">A boolean if the dice is a D2</param>
        public void SetEyeValue(int currentDice, string eyes, bool isD2)
        {
            var resultField = diceResultItems[currentDice].transform.Find("Dice Result").GetComponent<Text>();
            if (isD2)
            {
                SmallerTextSize(resultField);
            }

            resultField.text = eyes;
        }

        /// <summary>
        /// For roleplays it is sometimes necessary to know if one rolled the highest or lowest possible value, to determine a success or failure. Thus these values are marked in the dice list
        /// </summary>
        /// <param name="currentDice">Current dice in the list</param>
        /// <param name="type">It's type as not all of them need the colors</param>
        /// <param name="eyes">The rolled value</param>
        public void MarkResultField(int currentDice, DiceTypes type, int eyes)
        {
            var resultField = diceResultItems[currentDice].transform.Find("Dice Result").GetComponent<Text>();


            switch (type)
            {
                // mark rolled ones as red
                case DiceTypes.D4 when eyes == 1:
                case DiceTypes.D6 when eyes == 1:
                case DiceTypes.D8 when eyes == 1:
                case DiceTypes.D10 when eyes == 1:
                case DiceTypes.D12 when eyes == 1:
                case DiceTypes.D20 when eyes == 1:
                    resultField.color = rollForHighest.isOn ? _red : _green;
                    resultField.fontStyle = FontStyle.Bold;
                    return;
                // mark the highest possible value green
                case DiceTypes.D4 when eyes == 4:
                case DiceTypes.D6 when eyes == 6:
                case DiceTypes.D8 when eyes == 8:
                case DiceTypes.D10 when eyes == 10:
                case DiceTypes.D12 when eyes == 12:
                case DiceTypes.D20 when eyes == 20:
                    resultField.color = rollForHighest.isOn ? _green : _red;
                    resultField.fontStyle = FontStyle.Bold;
                    return;
                // coins and the percentile dice to not have highest ore lowest and thus are not colored, as well as every other possible value
                case DiceTypes.None:
                case DiceTypes.D2:
                case DiceTypes.D0:
                case DiceTypes.D00:
                default:
                    resultField.color = _blue;
                    resultField.fontStyle = FontStyle.Normal;
                    break;
            }
        }


        /// <summary>
        /// Inverts the colors from red to green and vice versa
        /// </summary>
        private void InvertColors()
        {
            for (var i = 0; i < DiceManager.Manager.diceCounter; i++)
            {
                var resultField = diceResultItems[i].transform.Find("Dice Result").GetComponent<Text>();
                if (resultField.color == _green)
                {
                    resultField.color = _red;
                }
                else if (resultField.color == _red)
                {
                    resultField.color = _green;
                }
            }
        }

        /// <summary>
        /// For D2 values the fontsize in the resultField needs to be reduced
        /// </summary>
        /// <param name="resultField">Current Textfield that is in need of smaller fontsize</param>
        private void SmallerTextSize(Text resultField)
        {
            resultField.fontSize = 15;
        }
    }
}