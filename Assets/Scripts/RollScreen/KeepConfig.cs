using UnityEngine;
using UnityEngine.UI;

namespace RollScreen
{
    /// <summary>
    /// Script to reset the number of rolls without having to redo the dice configuration
    /// </summary>
    public class KeepConfig : MonoBehaviour
    {
        [SerializeField] private Button enter;
        [SerializeField] private InputField newRounds;
        private RollDice _rollDice;

        
        /// <summary>
        /// Access all necessary objects on startup
        /// </summary>
        private void Start()
        {
            enter = GetComponent<Button>();
            enter.onClick.AddListener(SetNewRounds);

            _rollDice = GameObject.Find("Roll").GetComponent<RollDice>();
        }

        /// <summary>
        /// Give the new number of rolls to the DiceManager, hide the input again and reactivate the button to roll again.
        /// </summary>
        private void SetNewRounds()
        {
            DiceManager.Manager.SetRounds(int.Parse(newRounds.text));
            HideRoundInput();
            _rollDice.Reactivate();
        }

        /// <summary>
        /// Clears the input text and hides both input and button.
        /// </summary>
        private void HideRoundInput()
        {
            enter.gameObject.SetActive(false);
            newRounds.text = "";
            newRounds.gameObject.SetActive(false);
        }


    }
}