using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Level
{
    Fengchu,
    Qingxin,
    Tengyun,
    Huiyang,
    Qianyuan,
    Wuxiang
}

public class property {
    int HP, physique, speed, spirit, qi;
}

public class skills {
    
}

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance {get; private set;}

    public DiceManager dice;
    public Player player;


    public Button rollButton;
    // public Player player;
    public TMP_Text diceText;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer() {
        int movement = dice.RollDiceMoving(player.myLevel);
        player.Move(movement);

        diceText.text = movement.ToString();
        Debug.LogFormat("Player has moved forward by {0}", movement);
    }
}
