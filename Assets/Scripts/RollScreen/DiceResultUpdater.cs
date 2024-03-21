using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceResultUpdater : MonoBehaviour
{
    
    public GameObject diceResultItem1;
    public GameObject diceResultItem2;
    public GameObject diceResultItem3;
    public GameObject diceResultItem4;
    public GameObject diceResultItem5;
    public GameObject diceResultItem6;
    public GameObject diceResultItem7;
    public GameObject diceResultItem8;
    public GameObject diceResultItem9;
    public GameObject diceResultItem10;

    void Start()
    {
    }

    public void ActivateResultItem(int currentDice)
    {
        switch (currentDice)
        {
            case 0 :
                diceResultItem1.SetActive(true);
                break;
            case 1 :
                diceResultItem2.SetActive(true);
                break;
            case 2 :
                diceResultItem3.SetActive(true);
                break;
            case 3 :
                diceResultItem4.SetActive(true);
                break;
            case 4 :
                diceResultItem5.SetActive(true);
                break;
            case 5 :
                diceResultItem6.SetActive(true);
                break;
            case 6 :
                diceResultItem7.SetActive(true);
                break;
            case 7 :
                diceResultItem8.SetActive(true);
                break;
            case 8 :
                diceResultItem9.SetActive(true);
                break;
            case 9 :
                diceResultItem10.SetActive(true);
                break;
            
        }
    }
    public void UpdateKeepIcon(int currentDice, bool keep)
    {
        Image keepDice;

        switch (currentDice)
        {
            case 0 :
                keepDice = diceResultItem1.transform.Find("Keep").GetComponent<Image>();
                keepDice.sprite = keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
                break;
            case 1 :
                keepDice = diceResultItem2.transform.Find("Keep").GetComponent<Image>();
                keepDice.sprite = keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
                break;
            case 2 :
                keepDice = diceResultItem3.transform.Find("Keep").GetComponent<Image>();
                keepDice.sprite = keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
                break;
            case 3 :
                keepDice = diceResultItem4.transform.Find("Keep").GetComponent<Image>();
                keepDice.sprite = keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
                break;
            case 4 :
                keepDice = diceResultItem5.transform.Find("Keep").GetComponent<Image>();
                keepDice.sprite = keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
                break;
            case 5 :
                keepDice = diceResultItem6.transform.Find("Keep").GetComponent<Image>();
                keepDice.sprite = keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
                break;
            case 6 :
                keepDice = diceResultItem7.transform.Find("Keep").GetComponent<Image>();
                keepDice.sprite = keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
                break;
            case 7 :
                keepDice = diceResultItem8.transform.Find("Keep").GetComponent<Image>();
                keepDice.sprite = keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
                break;
            case 8 :
                keepDice = diceResultItem9.transform.Find("Keep").GetComponent<Image>();
                keepDice.sprite = keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
                break;
            case 9 :
                keepDice = diceResultItem10.transform.Find("Keep").GetComponent<Image>();
                keepDice.sprite = keep ? Resources.Load<Sprite>("Icons/Keep") : Resources.Load<Sprite>("Icons/NoKeep");
                break;
            
        }
    }
    public void SetDiceName(int currentDice, string diceType, string diceColor)
    {
        Text diceName;

        switch (currentDice)
        {
            case 0 :
                diceName = diceResultItem1.transform.Find("Dice Name").GetComponent<Text>();
                diceName.text = diceType + " " + diceColor;
                break;
            case 1 :
                diceName = diceResultItem2.transform.Find("Dice Name").GetComponent<Text>();
                diceName.text = diceType + " " + diceColor;
                break;
            case 2 :
                diceName = diceResultItem3.transform.Find("Dice Name").GetComponent<Text>();
                diceName.text = diceType + " " + diceColor;
                break;
            case 3 :
                diceName = diceResultItem4.transform.Find("Dice Name").GetComponent<Text>();
                diceName.text = diceType + " " + diceColor;
                break;
            case 4 :
                diceName = diceResultItem5.transform.Find("Dice Name").GetComponent<Text>();
                diceName.text = diceType + " " + diceColor;
                break;
            case 5 :
                diceName = diceResultItem6.transform.Find("Dice Name").GetComponent<Text>();
                diceName.text = diceType + " " + diceColor;
                break;
            case 6 :
                diceName = diceResultItem7.transform.Find("Dice Name").GetComponent<Text>();
                diceName.text = diceType + " " + diceColor;
                break;
            case 7 :
                diceName = diceResultItem8.transform.Find("Dice Name").GetComponent<Text>();
                diceName.text = diceType + " " + diceColor;
                break;
            case 8 :
                diceName = diceResultItem9.transform.Find("Dice Name").GetComponent<Text>();
                diceName.text = diceType + " " + diceColor;
                break;
            case 9 :
                diceName = diceResultItem10.transform.Find("Dice Name").GetComponent<Text>();
                diceName.text = diceType + " " + diceColor;
                break;
            
        }
    }
    public void SetDiceImage(int currentDice, string diceType, string diceColor)
    {
        Image diceImage;

        switch (currentDice)
        {
            case 0 :
                diceImage = diceResultItem1.transform.Find("Dice Image").GetComponent<Image>();
                diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
                break;
            case 1 :
                diceImage = diceResultItem2.transform.Find("Dice Image").GetComponent<Image>();
                diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
                break;
            case 2 :
                diceImage = diceResultItem3.transform.Find("Dice Image").GetComponent<Image>();
                diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
                break;
            case 3 :
                diceImage = diceResultItem4.transform.Find("Dice Image").GetComponent<Image>();
                diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
                break;
            case 4 :
                diceImage = diceResultItem5.transform.Find("Dice Image").GetComponent<Image>();
                diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
                break;
            case 5 :
                diceImage = diceResultItem6.transform.Find("Dice Image").GetComponent<Image>();
                diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
                break;
            case 6 :
                diceImage = diceResultItem7.transform.Find("Dice Image").GetComponent<Image>();
                diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
                break;
            case 7 :
                diceImage = diceResultItem8.transform.Find("Dice Image").GetComponent<Image>();
                diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
                break;
            case 8 :
                diceImage = diceResultItem9.transform.Find("Dice Image").GetComponent<Image>();
                diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
                break;
            case 9 :
                diceImage = diceResultItem10.transform.Find("Dice Image").GetComponent<Image>();
                diceImage.sprite = Resources.Load<Sprite>(diceType + "/" + diceType + "_" + diceColor);
                break;
            
        }
    }
    public void SetEyeValue(int currentDice, string eyes)
    {
        Text resultField;

        switch (currentDice)
        {
            case 0 :
                resultField = diceResultItem1.transform.Find("Dice Result").GetComponent<Text>();
                resultField.text = eyes;
                break;
            case 1 :
                resultField = diceResultItem2.transform.Find("Dice Result").GetComponent<Text>();
                resultField.text = eyes;
                break;
            case 2 :
                resultField = diceResultItem3.transform.Find("Dice Result").GetComponent<Text>();
                resultField.text = eyes;
                break;
            case 3 :
                resultField = diceResultItem4.transform.Find("Dice Result").GetComponent<Text>();
                resultField.text = eyes;
                break;
            case 4 :
                resultField = diceResultItem5.transform.Find("Dice Result").GetComponent<Text>();
                resultField.text = eyes;
                break;
            case 5 :
                resultField = diceResultItem6.transform.Find("Dice Result").GetComponent<Text>();
                resultField.text = eyes;
                break;
            case 6 :
                resultField = diceResultItem7.transform.Find("Dice Result").GetComponent<Text>();
                resultField.text = eyes;
                break;
            case 7 :
                resultField = diceResultItem8.transform.Find("Dice Result").GetComponent<Text>();
                resultField.text = eyes;
                break;
            case 8 :
                resultField = diceResultItem9.transform.Find("Dice Result").GetComponent<Text>();
                resultField.text = eyes;
                break;
            case 9 :
                resultField = diceResultItem10.transform.Find("Dice Result").GetComponent<Text>();
                resultField.text = eyes;
                break;
            
        }
    }
}
