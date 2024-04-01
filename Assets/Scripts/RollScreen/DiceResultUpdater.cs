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

        private void Start()
        {
            Updater = this;
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
        public void SetEyeValue(int currentDice, string eyes, bool isD2)
        {
            var resultField = diceResultItems[currentDice].transform.Find("Dice Result").GetComponent<Text>();
            if (isD2)
            {
                SmallerTextSize(resultField);
            }

            resultField.text = eyes;
        }
        
        private void SmallerTextSize(Text resultField)
        {
            resultField.fontSize = 15;
        }
    }
}