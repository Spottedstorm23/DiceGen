using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartRolling : MonoBehaviour
{
    
    private Button _roll;

    private Text _warning;
    private InputField _roundIn;

    private DiceManager _diceManager;
    
    public Image warningIcon;


    

    // Start is called before the first frame update
    void Start()
    {
        _roll = GetComponent<Button>();
        _roll.onClick.AddListener(ChangeToRolling);

        _warning = GameObject.Find("Warning").GetComponent<Text>();
        _roundIn = GameObject.Find("RoundCount").GetComponent<InputField>();
        _diceManager = GameObject.Find("DiceManager").GetComponent<DiceManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeToRolling()
    {
        _warning.text = "";
        warningIcon.gameObject.SetActive(false);


        if (!CheckInputsAreValid())
        {
            return;
        }
        _diceManager.rounds = int.Parse(_roundIn.text);
        
        SceneManager.LoadScene("RollScreenScene");
    }

    bool CheckInputsAreValid()
    {
        bool tmp_bool = true;
        
        if (_diceManager.diceCounter == 0)
        {
            _warning.text = "Please add at least one dice! \n";
            warningIcon.gameObject.SetActive(true);
            tmp_bool = false;
        }
        if (_roundIn.text == "" || int.Parse(_roundIn.text) < 1 || int.Parse(_roundIn.text) > 10)
        {
            _warning.text = _warning.text  + "Please enter 1 to 10 Rounds ";
            warningIcon.gameObject.SetActive(true);
            tmp_bool = false;
        }

        

        return tmp_bool;
    }
}
