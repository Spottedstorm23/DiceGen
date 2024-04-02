using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace RollScreen
{
    /// <summary>
    /// Includes all functions needed to roll a dice based on it's type and store the result
    /// </summary>
    /// <param name="roundText"> Textfield that displays the number of rolls that were done, as well as the amount that are set. Is set in Scene.</param>
    /// <param name="enterButton"> Button that enters the new amount of rolls. Is set in Scene.</param>
    /// <param name="roundInput"> InputField to enter new rounds. Set in scene</param>
    /// <param name="rollDelay"> The amount of second the code-side dice rolling should be delayed. Can be set in scene</param>
    public class RollDice : MonoBehaviour
    {
        private Button _roll;

        public Dice[] RollDices;
        [SerializeField] private Text roundText;
        [SerializeField] private Text rollingText;
        [SerializeField] private Button enterButton;
        [SerializeField] private InputField roundInput;
        [SerializeField] private float rollDelay = 2.5f;
        [SerializeField] private GameObject stats;
        [SerializeField] private Text[] statisticTexts;
        [SerializeField] private Text[] statisticOverRoundsTexts;
        [SerializeField] private Toggle showStats;

        private int[] _d6Counts = new[] { 0, 0, 0, 0, 0, 0 };
        private int[] _d6CountsOverRounds = new[] { 0, 0, 0, 0, 0, 0 };

        private Transform _diceResultText;

        private DiceResultUpdater _diceResultUpdater;
        private DiceManager _diceManager;

        private int _roundsGiven = 0;
        private int _diceGiven = 0;
        private int _roundsDone = 0;


        /// <summary>
        /// Access all fields and objects necessary.
        /// The function called upon a click/ tap on the rollButton is delayed, to give the impression of rolling the diceObjects first.
        /// </summary>
        private void Start()
        {
            _roll = GetComponent<Button>();
            _roll.onClick.AddListener(Feedback);
            _roll.onClick.AddListener(() => _roll.interactable = false);
            _roll.onClick.AddListener(() => Invoke(nameof(Roll), rollDelay));

            _diceManager = DiceManager.Manager;
            _roundsGiven = _diceManager.rounds;
            RollDices = _diceManager.AllDice;
            _diceGiven = _diceManager.diceCounter;

            _diceResultUpdater = DiceResultUpdater.Updater;
        }

        /// <summary>
        /// Give feedback to the user upon pressing roll that the dices are rolled
        /// </summary>
        private void Feedback()
        {
            rollingText.text = "Rolling...";
        }

        /// <summary>
        ///Iterates through the dices and rolls them based on their type and their locked status
        /// During this the roll button is disabled and will be enabled at the end
        /// </summary>
        private void Roll()
        {
            UpdateRounds();


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
                    case DiceTypes.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                CallToDiceResultUpdater(i);
                _roll.interactable = true;
                if (_roundsDone != _roundsGiven) continue;
                roundText.text = "";
                _roll.interactable = false;
                ActiveInput();
            }

            if (!AreAtLeastTwoD6())
            {
                showStats.interactable = false;
                return;
            }

            _d6Counts = new[] { 0, 0, 0, 0, 0, 0 };
            stats.SetActive(showStats.isOn);
            CreateStatistics();
            WriteStatistics();
            if (_roundsDone == _roundsGiven)
            {
                _d6CountsOverRounds = new[] { 0, 0, 0, 0, 0, 0 };
            }
        }

        /// <summary>
        /// Make all necessary calls to the <see cref="DiceResultUpdater"/> to generate the result list in frontend
        /// </summary>
        /// <param name="i"></param>
        private void CallToDiceResultUpdater(int i)
        {
            var type = RollDices[i].Type;
            var color = RollDices[i].Color;

            _diceResultUpdater.ActivateResultItem(i);
            _diceResultUpdater.UpdateLockIcon(i, RollDices[i].LockResult);
            _diceResultUpdater.SetDiceName(i, type.ToString(), color.ToString());
            _diceResultUpdater.SetDiceImage(i, type.ToString(), color.ToString());
            _diceResultUpdater.SetEyeValue(i, ResultString(type, RollDices[i].Result), type == DiceTypes.D2);
            _diceResultUpdater.MarkResultField(i, type, RollDices[i].Result);
        }

        /// <summary>
        /// Some dice types have different names for their result. These should be displayed.
        /// Coins show Head and Tails, while the 0 in a D00 is actually a 00
        /// </summary>
        /// <param name="type">Type of the current dice</param>
        /// <param name="result">The value of the result</param>
        /// <returns>Head | Tails | 00 | Result as string</returns>
        private static string ResultString(DiceTypes type, int result)
        {
            return type switch
            {
                DiceTypes.D2 => result == 1 ? "Head" : "Tails",
                DiceTypes.D00 => result == 0 ? "00" : result.ToString(),
                _ => result.ToString()
            };
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
        private static int RollD10()
        {
            return Random.Range(1, 11);
        }

        /// <summary>
        /// Simulates a d0 (d10 with other interpretation of values) roll
        /// </summary>
        /// <returns>0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 </returns>
        private static int RollD0()
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
            rollingText.text = "";
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
        private void ActiveInput()
        {
            enterButton.gameObject.SetActive(true);
            roundInput.text = "";
            roundInput.gameObject.SetActive(true);
        }

        /// <summary>
        ///Checks if there at least 2 D6 in the configuration 
        /// </summary>
        /// <returns>True if at least 2 D6 are counted, else false</returns>
        private bool AreAtLeastTwoD6()
        {
            var tempcount = 0;
            for (var i = 0; i < _diceGiven; i++)
            {
                if (RollDices[i].Type == DiceTypes.D6)
                {
                    tempcount++;
                }

                if (tempcount == 2)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Counts the values of the D6 in the configurationm
        /// </summary>
        private void CreateStatistics()
        {
            for (var i = 0; i < DiceManager.Manager.diceCounter; i++)
            {
                var dice = DiceManager.Manager.AllDice[i];
                if (dice.Type == DiceTypes.D6)
                {
                    _d6Counts[dice.Result - 1]++;
                    _d6CountsOverRounds[dice.Result - 1]++;
                }
            }
        }

        /// <summary>
        /// Shows the counted D6 values on Screen
        /// </summary>
        private void WriteStatistics()
        {
            for (var i = 0; i < 6; i++)
            {
                statisticTexts[i].text = _d6Counts[i] == 0 ? "-" : _d6Counts[i].ToString();
                statisticOverRoundsTexts[i].text =
                    _d6CountsOverRounds[i] == 0 ? "-" : _d6CountsOverRounds[i].ToString();
            }
        }
    }
}