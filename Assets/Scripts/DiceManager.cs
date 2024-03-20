using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{

    public Dice[] allDice = new Dice[10];

    public int diceCounter = 0;
    public int rounds = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateDice(int diceNumber, Dice updatedDice)
    {
        allDice[diceNumber] = updatedDice;
    }

    public void removeLastDice(int lastKey)
    {
        allDice[lastKey] = null;

    }
}

public class Dice
{
    public string type;
    public string color;
    public int result;
    public bool keep = false;

    public Dice(string in_type, string in_color)
    {
        type = in_type;
        color = in_color;
    }

    public void SetResult(int eyes)
    {
        result = eyes;
    }
    
    public void SetKeep()
    {
        keep = !keep;
    }
}