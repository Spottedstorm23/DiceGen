using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
    private Button _roll;

    public Dice[] Dices = new Dice[10];
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
        
        _diceManager = DiceManager.Manager; 
        _roundsGiven = _diceManager.rounds;
        Dices = _diceManager.AllDice;
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
            if (Dices[i] == null || Dices[i].LockResult)
            {
                continue;
            }
            switch (Dices[i].Type)
            {
                case DiceTypes.D2:
                    Dices[i].SetResult(FlipCoin());
                    break;
                
                case DiceTypes.D4:
                    Dices[i].SetResult(RollD4());
                    break;
                
                case DiceTypes.D6:
                    Dices[i].SetResult(RollD6());
                    break;
                
                case DiceTypes.D8:
                    Dices[i].SetResult(RollD8());
                    break;
                
                case DiceTypes.D10:
                    Dices[i].SetResult(RollD10());
                    break;
                
                case DiceTypes.D00:
                    Dices[i].SetResult(RollD00());
                    break;
                
                case DiceTypes.D12:
                    Dices[i].SetResult(RollD12());
                    break;
                
                case DiceTypes.D20:
                    Dices[i].SetResult(RollD20());
                    break;
            }
            _diceResultUpdater.ActivateResultItem(i);
            _diceResultUpdater.UpdateKeepIcon(i, Dices[i].LockResult);
            _diceResultUpdater.SetDiceName(i, Dices[i].Type.ToString(), Dices[i].Color.ToString());
            _diceResultUpdater.SetDiceImage(i, Dices[i].Type.ToString(), Dices[i].Color.ToString());
            _diceResultUpdater.SetEyeValue(i, Dices[i].Result.ToString());
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

    public void Reactivate()
    {
        _roll.interactable = true;
        _roundsDone = 0;
        _roundsGiven = _diceManager.rounds;
    }
    
}
