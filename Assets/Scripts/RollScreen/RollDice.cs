using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
    private Button _roll;

    public Dice[] _dices = new Dice[10];
    public Text roundText;
    
    public GameObject enterButton;
    
    public GameObject roundsInput;

    private Transform _diceResultText;

    private DiceResultUpdater _diceResultUpdater;
    private DiceManager _diceManager;

    private int _roundsGiven = 0;
    private int _diceGiven = 0;
    private int _roundsDone = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        _roll = GetComponent<Button>();
        _roll.onClick.AddListener(Roll);
        
        _diceManager = DiceManager.manager; 
        _roundsGiven = _diceManager.rounds;
        _dices = _diceManager.allDice;
        _diceGiven = _diceManager.diceCounter;
        
        _diceResultUpdater = GameObject.Find("ResultUpdater").gameObject.GetComponent<DiceResultUpdater>();
    }

    void Roll()
    {
        UpdateRounds();
        if (_roundsDone == _roundsGiven)
        {
            _roll.interactable = false;
            roundText.text = "";
            enterButton.SetActive(true);
            roundsInput.SetActive(true);
        }
        for (int i = 0; i < _diceGiven; i++) 
        {
            if (_dices[i] == null || _dices[i].keep)
            {
                continue;
            }
            switch (_dices[i].type)
            {
                case "D2":
                    _dices[i].SetResult(FlipCoin());
                    break;
                
                case "D4":
                    _dices[i].SetResult(RollD4());
                    break;
                
                case "D6":
                    _dices[i].SetResult(RollD6());
                    break;
                
                case "D8":
                    _dices[i].SetResult(RollD8());
                    break;
                
                case "D10":
                    _dices[i].SetResult(RollD10());
                    break;
                
                case "D00":
                    _dices[i].SetResult(RollD00());
                    break;
                
                case "D12":
                    _dices[i].SetResult(RollD12());
                    break;
                
                case "D20":
                    _dices[i].SetResult(RollD20());
                    break;
            }
            _diceResultUpdater.ActivateResultItem(i);
            _diceResultUpdater.UpdateKeepIcon(i, _dices[i].keep);
            _diceResultUpdater.SetDiceName(i, _dices[i].type, _dices[i].color);
            _diceResultUpdater.SetDiceImage(i, _dices[i].type, _dices[i].color);
            _diceResultUpdater.SetEyeValue(i, _dices[i].result.ToString());
        }
    }

    int FlipCoin()
    {
        return Random.Range(1, 3);
    }
    int RollD4()
    {
        return Random.Range(1, 5);

    }
    int RollD6()
    {
        return Random.Range(1, 7);
    }
    int RollD8()
    {
        return Random.Range(1, 9);

    }
    int RollD10()
    {
        return Random.Range(1, 11);

    }
    int RollD00()
    {
        int temp = Random.Range(0, 10);
        return temp * 10;
    }
    int RollD12()
    {
        return Random.Range(1, 13);
    }
    int RollD20()
    {
        return Random.Range(1, 21);
    }

    void UpdateRounds()
    {
        _roundsDone++;
        roundText.text = "Roll " + _roundsDone + " / " + _roundsGiven;
    }

    public void Reactivcate()
    {
        _roll.interactable = true;
        _roundsDone = 0;
        _roundsGiven = _diceManager.rounds;
    }
    
}
