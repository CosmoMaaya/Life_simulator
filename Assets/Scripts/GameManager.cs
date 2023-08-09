using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

public enum GridEffect {
    REWARD_exp=0,
    REWARD_skill,
    REWARD_property,
    REWARD_coin,
    REWARD_wuxing,
    REWARD_dice,
    SPLIT,
    PENALTY_exp,
    PENALTY_wuxing,
    PENALTY_dice,
    PENALTY_coin,
};

public static class Globals {
    public static Dictionary<Level, int> LIFE_BOUND = new Dictionary<Level, int>() {
        {Level.Fengchu, 100},
        {Level.Qingxin, 300},
        {Level.Tengyun, 500},
        {Level.Huiyang, 1000},
        {Level.Qianyuan, 2000},
        {Level.Wuxiang, 5000}
    };
    public static Dictionary<Level, int> EXP_BOUND = LIFE_BOUND.ToDictionary(kvp => kvp.Key, kvp => kvp.Value * 3);

    public static Dictionary<GridEffect, float> EFFECT_PROB = new Dictionary<GridEffect, float>() {
        {GridEffect.REWARD_exp, 0.7f},
        {GridEffect.REWARD_skill, 0.25f},
        {GridEffect.REWARD_property, 0.15f},
        {GridEffect.REWARD_coin, 0.7f},
        {GridEffect.REWARD_wuxing, 0.5f},
        {GridEffect.REWARD_dice, 0.8f},
        {GridEffect.PENALTY_exp, 0.8f},
        {GridEffect.PENALTY_wuxing, 0.6f},
        {GridEffect.PENALTY_dice, 0.7f},
        {GridEffect.PENALTY_coin, 0.9f}
    };

    public static List<GridEffect> REWARD_ORDER = new List<GridEffect> () {
        GridEffect.REWARD_exp,
        GridEffect.REWARD_skill,
        GridEffect.REWARD_property,
        GridEffect.REWARD_coin,
        GridEffect.REWARD_wuxing,
        GridEffect.REWARD_dice,
    };

    public static List<GridEffect> PENALTY_ORDER = new List<GridEffect> () {
        GridEffect.PENALTY_exp,
        GridEffect.PENALTY_wuxing,
        GridEffect.PENALTY_dice,
        GridEffect.PENALTY_coin,
    };
}

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance {get; private set;}

    public GameObject grid_prefab;
    public GameObject GameBoard;
    
    List<GameObject> grids_holder = new List<GameObject>();

    public DiceManager dice;
    public Player player;


    public Button rollButton;
    // public Player player;
    public TMP_Text diceText;

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < 100; i++) {
            grids_holder.Add(Instantiate(grid_prefab, GameBoard.transform));
        }
    }
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

        player.ChangeExp((int) (Globals.EXP_BOUND[player.myLevel] / 100.0f * (10 - (int)player.myLevel)));

        diceText.text = movement.ToString();
        Debug.LogFormat("Player has moved forward by {0}", movement);

        ApplyGridEffect(grids_holder[player.position].GetComponent<GridUnit>().myEffect);
    }

    public void ApplyGridEffect(GridEffect effect) {
        Debug.LogFormat("Arrived Grid With Result {0}", effect);
        switch (effect) {
            case GridEffect.REWARD_exp:
            {
                player.ChangeExp(10);
                break;
            }
            case GridEffect.REWARD_skill:
            {
                break;
            }
            case GridEffect.REWARD_property:
            {
                break;
            }
            case GridEffect.REWARD_coin:
            {
                break;
            }
            case GridEffect.REWARD_wuxing: 
            {
                
                break;
            }
            case GridEffect.REWARD_dice:
			{
				break;
			}
            case GridEffect.SPLIT:
			{
				break;
			}
            case GridEffect.PENALTY_exp:
			{
				break;
			}
            case GridEffect.PENALTY_wuxing:
			{
				break;
			}
            case GridEffect.PENALTY_dice:
			{
				break;
			}
            case GridEffect.PENALTY_coin:
			{
				break;
			}
            default:
                break;
        }
    }
}
