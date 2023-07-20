using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum DiceResult {
    GreatSuccess,
    Success,
    Failure,
    TremendousFailure
}

public class DiceManager : MonoBehaviour
{   
    public Button rollButton;
    public Player player;
    public TMP_Text diceText;
    public int diceNumber, diceRange;
    // Change our dice type according to the current level of our player
    public void RollDiceMoving () {
        Debug.Log("HELLO");
        switch (player.myLevel)
        {
            case Level.Fengchu:
                diceNumber = 1;
                diceRange = 3;
                break;
            case Level.Qingxin:
                diceNumber = 2;
                diceRange = 4;
                break;
            case Level.Tengyun:
                diceNumber = 1;
                diceRange = 10;
                break;
            case Level.Huiyang:
                diceNumber = 3;
                diceRange = 10;
                break;
            case Level.Qianyuan:
                diceNumber = 1;
                diceRange = 50;
                break;
            case Level.Wuxiang:
                diceNumber = 2;
                diceRange = 50;
                break;
            default:
                break;
        }

        int result = 0;
        for (int i = 0; i < diceNumber; i++) {
            result += UnityEngine.Random.Range(1, diceRange);
        }
        diceText.text = result.ToString();
        // return result;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Button btn = rollButton.GetComponent<Button>();
        // btn.onClick.AddListener(RollDiceMoving);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
