using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to store dice configuration, number of dice and number of rolls.
/// </summary>
/// <remarks>
/// The GameObject attached to this script is not Destroyed on a scene change to keep the values.
/// </remarks>
/// <functions>
/// <list type="table">
/// <item><see cref="AddDiceToConfiguration"/></item>
/// <item><see cref="RemoveLastDice"/></item>
/// <item><see cref="SetRounds"/></item>
/// <item><see cref="CountUp"/></item>
/// <item><see cref="CountDown"/></item>
/// </list>
/// </functions>
/// <access>
/// with <c>DiceManager.Manager</c>
/// </access>
public class DiceManager : MonoBehaviour
{
    public static DiceManager Manager;
    public Dice[] AllDice;

    public int diceCounter = 0;
    public int rounds = 0;

    /// <summary>
    /// Initializes the state of the DiceManager and marks it as DontDestroyOnLoad.
    /// </summary>
    private void Start()
    {
        AllDice = new Dice[10];
        Manager = this; // linking the self-reference
        DontDestroyOnLoad(transform.gameObject); // set to dont destroy
    }

    /// <summary>
    /// Adds the dice to <c>AllDice</c>
    /// </summary>
    /// <param name="updatedDice"> <see cref="Dice"/> that should be added to the configuration.</param>
    public void AddDiceToConfiguration(Dice updatedDice)
    {
        AllDice[diceCounter] = updatedDice;
    }

    /// <summary>
    /// Removes the last dice in the configuration.
    /// </summary>
    public void RemoveLastDice()
    {
        AllDice[diceCounter - 1] = null;
    }

    /// <summary>
    /// Sets the number of rolls the user can roll/ re-roll the dices
    /// </summary>
    /// <param name="roundsIn">Integer number of rolls</param>
    public void SetRounds(int roundsIn)
    {
        rounds = roundsIn;
    }

    /// <summary>
    /// Sets the diceCounter one higher.
    /// </summary>
    public void CountUp()
    {
        diceCounter++;
    }

    /// <summary>
    /// Sets the diceCounter one lower.
    /// </summary>
    public void CountDown()
    {
        diceCounter--;
    }
}

/// <summary>
/// Definition of a Dice Object.
/// </summary>
/// <fields>
/// <list type="table">
/// <item>
/// <term>Type</term>
/// <description> <see cref="DiceTypes"/></description>
/// </item>
/// <item>
/// <term>Color</term>
/// <description> <see cref="Color"/></description>
/// </item>
/// <item>
/// <term>Result</term>
/// <description>Integer that stores the rolled number</description>
/// </item>
/// <item>
/// <term>LockResult</term>
/// <description> Boolean that decides if a dice is locked</description>
/// </item>
/// </list>
/// </fields>
public class Dice
{
    public readonly DiceTypes Type;
    public readonly DiceColors Color;
    public int Result;
    public bool LockResult = false;

    /// <summary>
    /// Creates a new Dice.
    /// </summary>
    /// <param name="inType">Type the dice should have</param>
    /// <param name="inColor">Color the dice should have</param>
    public Dice(DiceTypes inType, DiceColors inColor)
    {
        Type = inType;
        Color = inColor;
    }

    /// <summary>
    /// Stores the rolled result.
    /// </summary>
    /// <param name="eyes"> Number of eyes that were rolled.</param>
    public void SetResult(int eyes)
    {
        Result = eyes;
    }

    /// <summary>
    /// If a dice is locked it is unlocked and vice versa.
    /// </summary>
    public void InvertLockResult()
    {
        LockResult = !LockResult;
    }
}

/// <summary>
/// Enum definition of all possible colors a dice might have.
/// </summary>
/// <Colors>None | White | Black | Red | Blue | Green | Cyan | Magenta | Yellow | Multi</Colors>
/// <remarks>
/// Keep the order of the options in the DropDown parallel to the definition here to ensure compatibility.
/// </remarks>
public enum DiceColors
{
    None,
    White,
    Black,
    Red,
    Blue,
    Green,
    Cyan,
    Magenta,
    Yellow,
    Multi
}
/// <summary>
/// Enum definition of all possible types a dice might have.
/// </summary>
/// <Types>None | D2 | D4 | D6 | D8 | D10 | D0 | D00 | D12 | D20</Types>
/// <remarks>
/// <para>
/// Keep the order of the options in the DropDown parallel to the definition here to ensure compatibility.
/// </para>
/// <para>
/// To understand dice types search for DnD Dices
/// <see href="https://www.dicedragons.co.uk/blogs/dice-advice/dnd-dice-explained">DnD Dices explained</see>
/// </para>
/// </remarks>
public enum DiceTypes
{
    None,
    D2,
    D4,
    D6,
    D8,
    D10,
    D0,
    D00,
    D12,
    D20
}