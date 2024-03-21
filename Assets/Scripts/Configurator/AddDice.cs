using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddDice : MonoBehaviour
{
    public Dropdown diceSelect;
    public Dropdown colorSelect;
    public Image dice1_img;
    public Image dice2_img;
    public Image dice3_img;
    public Image dice4_img;
    public Image dice5_img;
    public Image dice6_img;
    public Image dice7_img;
    public Image dice8_img;
    public Image dice9_img;
    public Image dice10_img;
    public Text warning;
    public Image warningIcon;
    private Button _add;
    private DiceManager _diceManager;

    // Start is called before the first frame update
    void Start()
    {
        _add = GetComponent<Button>();
        _add.onClick.AddListener(AddDiceOnClick);
        _diceManager = GameObject.Find("DiceManager").GetComponent<DiceManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void AddDiceOnClick()
    {
        warning.text = "";
        warningIcon.gameObject.SetActive(false);

        
        string color = SelectColor(colorSelect.value);
        string diceType = SelectDiceType(diceSelect.value);
        string spriteName = diceType + "_" + color;
        int tmpCount = _diceManager.diceCounter;

        if (diceType == "none" || color == "none")
        {
            warning.text = "Please make sure to have Dice and Color selected!";
            warningIcon.gameObject.SetActive(true);
            return;
        }
        
        if (tmpCount == 0)
        {
            dice1_img.gameObject.SetActive(true);
            dice1_img.sprite = Resources.Load<Sprite>(diceType+ "/" + spriteName);
        }
        else if (tmpCount == 1)
        {
            dice2_img.gameObject.SetActive(true);;
            dice2_img.sprite = Resources.Load<Sprite>(diceType+ "/" + spriteName);
        }
        else if (tmpCount == 2)
        {
            dice3_img.gameObject.SetActive(true);;
            dice3_img.sprite = Resources.Load<Sprite>(diceType+ "/" + spriteName);
        }
        else if (tmpCount == 3)
        {
            dice4_img.gameObject.SetActive(true);;
            dice4_img.sprite = Resources.Load<Sprite>(diceType+ "/" + spriteName);
        }
        else if (tmpCount == 4)
        {
            dice5_img.gameObject.SetActive(true);;
            dice5_img.sprite = Resources.Load<Sprite>(diceType+ "/" + spriteName);
        }
        else if (tmpCount == 5)
        {
            dice6_img.gameObject.SetActive(true);;
            dice6_img.sprite = Resources.Load<Sprite>(diceType+ "/" + spriteName);
        }
        else if (tmpCount == 6)
        {
            dice7_img.gameObject.SetActive(true);;
            dice7_img.sprite = Resources.Load<Sprite>(diceType+ "/" + spriteName);
        }
        else if (tmpCount == 7)
        {
            dice8_img.gameObject.SetActive(true);;
            dice8_img.sprite = Resources.Load<Sprite>(diceType+ "/" + spriteName);
        }
        else if (tmpCount == 8)
        {
            dice9_img.gameObject.SetActive(true);;
            dice9_img.sprite = Resources.Load<Sprite>(diceType+ "/" + spriteName);
        }
        else if (tmpCount == 9)
        {
            dice10_img.gameObject.SetActive(true);;
            dice10_img.sprite = Resources.Load<Sprite>(diceType+ "/" + spriteName);
        }

        _diceManager.UpdateDice(_diceManager.diceCounter, new Dice(diceType, color));
        _diceManager.diceCounter++;
        if(_diceManager.diceCounter == 10)
        {
            RemoveAddButton();
        }
    }
    
    void RemoveAddButton(){
        _add.gameObject.SetActive(false);
    }
    
    string SelectColor(int colorDropValue)
    {
        switch (colorDropValue)
        {
            case 1:
                return "White";
            case 2:
                return "Black";
            case 3:
                return "Red";
            case 4:
                return "Blue";
            case 5:
                return "Green";
            case 6:
                return "Cyan";
            case 7:
                return "Magenta";
            case 8:
                return "Yellow";
            default:
                return "none";
        }
    }

    string SelectDiceType(int diceDropValue)
    {
        switch (diceDropValue)
        {
            case 1:
                return "D2";
            case 2:
                return "D4";
            case 3:
                return "D6";
            case 4:
                return "D8";
            case 5:
                return "D10";
            case 6:
                return "D00";
            case 7:
                return "D12";
            case 8:
                return "D20";
            default:
                return "none";
        }
    }
}


