using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepConfig : MonoBehaviour
{
    private Button _enter;
    private InputField _newRounds;
    private RollDice _rollDice;

    // Start is called before the first frame update
    void Start()
    {
        _enter = GetComponent<Button>();
        _enter.onClick.AddListener(SetNewRounds);

        _newRounds = GameObject.Find("Rounds").GetComponent<InputField>();
        _rollDice = GameObject.Find("Roll").GetComponent<RollDice>();
    }

    private void SetNewRounds()
    {
        DiceManager.manager.SetRounds(int.Parse(_newRounds.text));
        _enter.gameObject.SetActive(false);
        _newRounds.text = "";
        _newRounds.gameObject.SetActive(false);
        _rollDice.Reactivcate();
    }

    // Update is called once per frame
    void Update()
    {
    }
}