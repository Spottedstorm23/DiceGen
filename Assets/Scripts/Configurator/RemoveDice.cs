using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveDice : MonoBehaviour
{
    private DiceManager _diceManager;
    private Image _image;
    private Button _imgButton;
    // Start is called before the first frame update
    void Start()
    {
        _diceManager = GameObject.Find("DiceManager").GetComponent<DiceManager>();
        
        _image = GetComponent<Image>();
        _imgButton = GetComponent<Button>();
        _imgButton.onClick.AddListener(RemoveOnClick);
    }
    void RemoveOnClick()
    {
        if (_image.name == "Dice " + _diceManager.diceCounter)
        {
            _image.gameObject.SetActive(false);
            _diceManager.removeLastDice(_diceManager.diceCounter -1);
            _diceManager.diceCounter--;
            
        }
    }
}
