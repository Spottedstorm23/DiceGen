using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepDice : MonoBehaviour
{
    // Start is called before the first frame update
    private Button _keep;
    private RollDice _rollDice;
    private DiceResultUpdater _diceResultUpdater;

    void Start()
    {
        _keep = GetComponent<Button>();
        _keep.onClick.AddListener(Keep);
        
        _rollDice = GameObject.Find("Roll").gameObject.GetComponent<RollDice>();
        _diceResultUpdater = GameObject.Find("ResultUpdater").gameObject.GetComponent<DiceResultUpdater>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Keep()
    {
        switch (_keep.name)
        {
            case "Dice Result Item 1":
                _rollDice._dices[0].SetKeep();
                _diceResultUpdater.UpdateKeepIcon(0, _rollDice._dices[0].keep);
                break;
            case "Dice Result Item 2":
                _rollDice._dices[1].SetKeep();
                _diceResultUpdater.UpdateKeepIcon(1, _rollDice._dices[1].keep);
                break;
            case "Dice Result Item 3":
                _rollDice._dices[2].SetKeep();
                _diceResultUpdater.UpdateKeepIcon(2, _rollDice._dices[2].keep);
                break;
            case "Dice Result Item 4":
                _rollDice._dices[3].SetKeep();
                _diceResultUpdater.UpdateKeepIcon(3, _rollDice._dices[3].keep);
                break;
            case "Dice Result Item 5":
                _rollDice._dices[4].SetKeep();
                _diceResultUpdater.UpdateKeepIcon(4, _rollDice._dices[4].keep);
                break;
            case "Dice Result Item 6":
                _rollDice._dices[5].SetKeep();
                _diceResultUpdater.UpdateKeepIcon(5, _rollDice._dices[5].keep);
                break;
            case "Dice Result Item 7":
                _rollDice._dices[6].SetKeep();
                _diceResultUpdater.UpdateKeepIcon(6, _rollDice._dices[6].keep);
                break;
            case "Dice Result Item 8":
                _rollDice._dices[7].SetKeep();
                _diceResultUpdater.UpdateKeepIcon(7, _rollDice._dices[7].keep);
                break;
            case "Dice Result Item 9":
                _rollDice._dices[8].SetKeep();
                _diceResultUpdater.UpdateKeepIcon(8, _rollDice._dices[8].keep);
                break;
            case "Dice Result Item 10":
                _rollDice._dices[9].SetKeep();
                _diceResultUpdater.UpdateKeepIcon(9, _rollDice._dices[9].keep);
                break;
        }
    }
}
