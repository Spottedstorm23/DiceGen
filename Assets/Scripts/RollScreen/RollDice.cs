using UnityEngine;
using UnityEngine.UI;

namespace RollScreen
{
    /// <summary>
    /// Includes all functions needed to roll a dice based on it's type and store the result
    /// </summary>
    /// <param name="roundText"> Textfield that displays the number of rolls that were done, as well as the amount that are set. Is set in Scene.</param>
    /// <param name="enterButton"> Button that enters the new amount of rolls. Is set in Scene.</param>
    /// <param name="roundInput"> InputField to enter new rounds. Set in scene</param>
    public class RollDice : MonoBehaviour
    {
        private Button _roll;

        public Dice[] RollDices;
        public Text roundText;
        public Button enterButton;
        public InputField roundInput;

        private Transform _diceResultText;

        private DiceResultUpdater _diceResultUpdater;
        private DiceManager _diceManager;

        private int _roundsGiven = 0;
        private int _diceGiven = 0;
        private int _roundsDone = 0;


        /// <summary>
        /// Access all fields and objects necessary
        /// </summary>
        private void Start()
        {
            _roll = GetComponent<Button>();
            _roll.onClick.AddListener(Roll);

            _diceManager = DiceManager.Manager;
            _roundsGiven = _diceManager.rounds;
            RollDices = _diceManager.AllDice;
            _diceGiven = _diceManager.diceCounter;

            _diceResultUpdater = DiceResultUpdater.Updater;
        }

        /// <summary>
        ///Iterates through the dices and rolls them based on their type and their locked status
        /// </summary>
        private void Roll()
        {
            UpdateRounds();
            if (_roundsDone == _roundsGiven)
            {
                roundText.text = "";
                _roll.interactable = false;
                ActiveInput();
            }

            for (var i = 0; i < _diceGiven; i++)
            {
                // skip if no dice is set or the dice is locked
                if (RollDices[i] == null || RollDices[i].LockResult)
                {
                    continue;
                }

                switch (RollDices[i].Type)
                {
                    case DiceTypes.D2:
                        RollDices[i].SetResult(FlipCoin());
                        break;

                    case DiceTypes.D4:
                        RollDices[i].SetResult(RollD4());
                        break;

                    case DiceTypes.D6:
                        RollDices[i].SetResult(RollD6());
                        break;

                    case DiceTypes.D8:
                        RollDices[i].SetResult(RollD8());
                        break;

                    case DiceTypes.D10:
                        RollDices[i].SetResult(RollD10());
                        break;

                    case DiceTypes.D0:
                        RollDices[i].SetResult(RollD0());
                        break;

                    case DiceTypes.D00:
                        RollDices[i].SetResult(RollD00());
                        break;

                    case DiceTypes.D12:
                        RollDices[i].SetResult(RollD12());
                        break;

                    case DiceTypes.D20:
                        RollDices[i].SetResult(RollD20());
                        break;
                }

                CallToDiceResultUpdater(i);
            }
        }

        /// <summary>
        /// Make all necessary calls to the <see cref="DiceResultUpdater"/> to generate the result list in frontend
        /// </summary>
        /// <param name="i"></param>
        private void CallToDiceResultUpdater(int i)
        {
            _diceResultUpdater.ActivateResultItem(i);
            _diceResultUpdater.UpdateLockIcon(i, RollDices[i].LockResult);
            _diceResultUpdater.SetDiceName(i, RollDices[i].Type.ToString(), RollDices[i].Color.ToString());
            _diceResultUpdater.SetDiceImage(i, RollDices[i].Type.ToString(), RollDices[i].Color.ToString());
            _diceResultUpdater.SetEyeValue(i, RollDices[i].Result.ToString());
        }

        /// <summary>
        /// Simulates a coin flip
        /// </summary>
        /// <returns>1 or 2</returns>
        private static int FlipCoin()
        {
            return Random.Range(1, 3);
        }

        /// <summary>
        /// Simulates a d4 roll
        /// </summary>
        /// <returns>1 | 2 | 3 | 4</returns>
        private static int RollD4()
        {
            return Random.Range(1, 5);
        }

        /// <summary>
        /// Simulates a d6 roll
        /// </summary>
        /// <returns>1 | 2 | 3 | 4 | 5 | 6</returns>
        private static int RollD6()
        {
            return Random.Range(1, 7);
        }

        /// <summary>
        /// Simulates a d8 roll
        /// </summary>
        /// <returns>1 | 2 | 3 | 4 | 5 | 6 | 7 | 8</returns>
        private static int RollD8()
        {
            return Random.Range(1, 9);
        }

        /// <summary>
        /// Simulates a d10 roll
        /// </summary>
        /// <returns>1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 </returns>
        public int RollD10()
        {
            return Random.Range(1, 11);
        }

        /// <summary>
        /// Simulates a d0 (d10 with other interpretation of values) roll
        /// </summary>
        /// <returns>0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 </returns>
        public int RollD0()
        {
            return Random.Range(0, 10);
        }

        /// <summary>
        /// Simulates a d00 roll
        /// </summary>
        /// <returns>0 | 10 | 20 | 30 | 40 | 50 | 60 | 70 | 80 | 90</returns>
        private static int RollD00()
        {
            int temp = Random.Range(0, 10);
            if (temp == 0)
            {
                return 00;
            }

            return temp * 10;
        }

        /// <summary>
        /// Simulates a d12 roll
        /// </summary>
        /// <returns>1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 </returns>
        private static int RollD12()
        {
            return Random.Range(1, 13);
        }

        /// <summary>
        /// Simulates a d20 roll
        /// </summary>
        /// <returns>1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 |13 | 14 | 15 | 16 | 17 | 18 | 19 | 20 </returns>
        private static int RollD20()
        {
            return Random.Range(1, 21);
        }

        /// <summary>
        /// Counts the number of rolls. Adds one on call. Updates the text in the upper left corner
        /// </summary>
        private void UpdateRounds()
        {
            _roundsDone++;
            roundText.text = "Roll " + _roundsDone + " / " + _roundsGiven;
        }

        /// <summary>
        /// Resets the done rounds. gets the new number of rolls and activates the roll button again
        /// </summary>
        public void Reactivate()
        {
            _roll.interactable = true;
            _roundsDone = 0;
            _roundsGiven = _diceManager.rounds;
        }

        /// <summary>
        /// Makes input fields visible
        /// </summary>
        public void ActiveInput()
        {
            enterButton.gameObject.SetActive(true);
            roundInput.text = "";
            roundInput.gameObject.SetActive(true);
        }
    }
}