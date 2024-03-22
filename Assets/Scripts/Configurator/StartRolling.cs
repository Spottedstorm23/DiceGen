using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Configurator
{
    /// <summary>
    /// Script to Leave the ConfiguratorScene and change to the RollingScene.
    /// </summary>
    /// <description>
    /// If everything is set correctly a change to Rolling is issued.
    /// the roll count is read here as well.
    /// </description>
    /// <param name="warningIcon">Image that is used to display the warning icon if a warning is issued. Set in Scene</param>
    public class StartRolling : MonoBehaviour
    {
        private Button _roll;

        private Text _warning;
        private InputField _roundIn;

        private DiceManager _diceManager;

        public Image warningIcon;


        /// <summary>
        /// Sets all necessary private objects and adds the event listener.
        /// </summary>
        private void Start()
        {
            _roll = GetComponent<Button>();
            _roll.onClick.AddListener(ChangeToRolling);

            _warning = GameObject.Find("Warning").GetComponent<Text>();
            _roundIn = GameObject.Find("RoundCount").GetComponent<InputField>();
            _diceManager = DiceManager.Manager;
        }

        /// <summary>
        /// Function that changes the scene to the rolling screen.
        /// </summary>
        /// <description>
        /// At first the warning resets to avoid confusion for the user.
        /// If everything is set, meaning at least one dice is configured and a roll count is given, the scene changes.
        /// </description>
        void ChangeToRolling()
        {
            ResetWarning();

            if (!AreInputsValid())
            {
                return;
            }

            _diceManager.SetRounds(int.Parse(_roundIn.text));

            UnityEngine.SceneManagement.SceneManager.LoadScene("RollScreenScene");
        }

        /// <summary>
        /// Hides waringIcon and empties warningText
        /// </summary>
        private void ResetWarning()
        {
            _warning.text = "";
            warningIcon.gameObject.SetActive(false);
        }

        /// <summary>
        /// Checks if all necessary configurations are made and sets the necessary warnings.
        /// </summary>
        /// <returns>Returns <see langword="false">false</see> if no roll count is given or no dice is set, else <see langword="true">true</see></returns>
        private bool AreInputsValid()
        {
            var tmpBool = true;

            if (_diceManager.diceCounter == 0)
            {
                _warning.text = "Please add at least one dice! \n";
                warningIcon.gameObject.SetActive(true);
                tmpBool = false;
            }

            if (_roundIn.text == "" || int.Parse(_roundIn.text) < 1 || int.Parse(_roundIn.text) > 100)
            {
                _warning.text = _warning.text + "Set rolls to a number from 1 to 100!";
                warningIcon.gameObject.SetActive(true);
                tmpBool = false;
            }
        
            return tmpBool;
        }
    }
}