using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public static DiceManager manager;   
    public Dice[] allDice; 

    public int diceCounter = 0;
    public int rounds = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        allDice = new Dice[10];
        manager = this;                          // linking the self-reference
        DontDestroyOnLoad(transform.gameObject); // set to dont destroy
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