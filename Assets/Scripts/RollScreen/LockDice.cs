using UnityEngine;
using UnityEngine.UI;

namespace RollScreen
{
    /// <summary>
    /// Script that listens to a click onn the diceResultItem and then updates the locked status of th dice
    /// </summary>
    public class LockDice : MonoBehaviour
    {
        // Start is called before the first frame update
        private Button _keep;
        private RollDice _rollDice;
        private DiceResultUpdater _diceResultUpdater;

        /// <summary>
        /// Set field that are needed as well as add the click listener 
        /// </summary>
        private void Start()
        {
            _keep = GetComponent<Button>();
            _keep.onClick.AddListener(LockClickedDice);
        
            _rollDice = GameObject.Find("Roll").gameObject.GetComponent<RollDice>();
            _diceResultUpdater = DiceResultUpdater.Updater;

        }

        /// <summary>
        /// Invert the locked status of the dice that is associated with the clicked GameObject.
        /// The status is stored in the <see cref="DiceManager"/> as well as shown in the list. Therefor the Icon needs to be changed on click.
        /// </summary>
        private void LockClickedDice()
        {
            switch (_keep.name)
            {
                case "Dice Result Item 1":
                    _rollDice.RollDices[0].InvertLockResult();
                    _diceResultUpdater.UpdateLockIcon(0, _rollDice.RollDices[0].LockResult);
                    break;
                case "Dice Result Item 2":
                    _rollDice.RollDices[1].InvertLockResult();
                    _diceResultUpdater.UpdateLockIcon(1, _rollDice.RollDices[1].LockResult);
                    break;
                case "Dice Result Item 3":
                    _rollDice.RollDices[2].InvertLockResult();
                    _diceResultUpdater.UpdateLockIcon(2, _rollDice.RollDices[2].LockResult);
                    break;
                case "Dice Result Item 4":
                    _rollDice.RollDices[3].InvertLockResult();
                    _diceResultUpdater.UpdateLockIcon(3, _rollDice.RollDices[3].LockResult);
                    break;
                case "Dice Result Item 5":
                    _rollDice.RollDices[4].InvertLockResult();
                    _diceResultUpdater.UpdateLockIcon(4, _rollDice.RollDices[4].LockResult);
                    break;
                case "Dice Result Item 6":
                    _rollDice.RollDices[5].InvertLockResult();
                    _diceResultUpdater.UpdateLockIcon(5, _rollDice.RollDices[5].LockResult);
                    break;
                case "Dice Result Item 7":
                    _rollDice.RollDices[6].InvertLockResult();
                    _diceResultUpdater.UpdateLockIcon(6, _rollDice.RollDices[6].LockResult);
                    break;
                case "Dice Result Item 8":
                    _rollDice.RollDices[7].InvertLockResult();
                    _diceResultUpdater.UpdateLockIcon(7, _rollDice.RollDices[7].LockResult);
                    break;
                case "Dice Result Item 9":
                    _rollDice.RollDices[8].InvertLockResult();
                    _diceResultUpdater.UpdateLockIcon(8, _rollDice.RollDices[8].LockResult);
                    break;
                case "Dice Result Item 10":
                    _rollDice.RollDices[9].InvertLockResult();
                    _diceResultUpdater.UpdateLockIcon(9, _rollDice.RollDices[9].LockResult);
                    break;
            }
        }
    }
}
