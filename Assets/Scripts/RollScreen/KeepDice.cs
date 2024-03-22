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
                _rollDice.Dices[0].InvertLockResult();
                _diceResultUpdater.UpdateKeepIcon(0, _rollDice.Dices[0].LockResult);
                break;
            case "Dice Result Item 2":
                _rollDice.Dices[1].InvertLockResult();
                _diceResultUpdater.UpdateKeepIcon(1, _rollDice.Dices[1].LockResult);
                break;
            case "Dice Result Item 3":
                _rollDice.Dices[2].InvertLockResult();
                _diceResultUpdater.UpdateKeepIcon(2, _rollDice.Dices[2].LockResult);
                break;
            case "Dice Result Item 4":
                _rollDice.Dices[3].InvertLockResult();
                _diceResultUpdater.UpdateKeepIcon(3, _rollDice.Dices[3].LockResult);
                break;
            case "Dice Result Item 5":
                _rollDice.Dices[4].InvertLockResult();
                _diceResultUpdater.UpdateKeepIcon(4, _rollDice.Dices[4].LockResult);
                break;
            case "Dice Result Item 6":
                _rollDice.Dices[5].InvertLockResult();
                _diceResultUpdater.UpdateKeepIcon(5, _rollDice.Dices[5].LockResult);
                break;
            case "Dice Result Item 7":
                _rollDice.Dices[6].InvertLockResult();
                _diceResultUpdater.UpdateKeepIcon(6, _rollDice.Dices[6].LockResult);
                break;
            case "Dice Result Item 8":
                _rollDice.Dices[7].InvertLockResult();
                _diceResultUpdater.UpdateKeepIcon(7, _rollDice.Dices[7].LockResult);
                break;
            case "Dice Result Item 9":
                _rollDice.Dices[8].InvertLockResult();
                _diceResultUpdater.UpdateKeepIcon(8, _rollDice.Dices[8].LockResult);
                break;
            case "Dice Result Item 10":
                _rollDice.Dices[9].InvertLockResult();
                _diceResultUpdater.UpdateKeepIcon(9, _rollDice.Dices[9].LockResult);
                break;
        }
    }
}
