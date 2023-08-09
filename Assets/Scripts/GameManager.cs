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

        player.ChangeExpBy((int) (Globals.EXP_BOUND[player.myLevel] / 100.0f * (10 - (int)player.myLevel)));

        diceText.text = movement.ToString();
        Debug.LogFormat("Player has moved forward by {0}", movement);

        ApplyGridEffect(grids_holder[player.position].GetComponent<GridUnit>().myEffect);
    }

    public void ApplyGridEffect(GridEffect effect) {
        Debug.LogFormat("Arrived Grid With Result {0}", effect);
        switch (effect) {
            case GridEffect.REWARD_exp:
            {
                player.ChangeExpBy(10);
                break;
            }
            case GridEffect.REWARD_skill:
            {
                var skill = player.GetRandomSkill();
                skill.ChangeLevelBy(1);
                break;
            }
            case GridEffect.REWARD_property:
            {
                var property = player.GetRandomProperty();
                property.ChangeLevelBy(1);
                break;
            }
            case GridEffect.REWARD_coin:
            {
                player.ChangeMoneyBy(10);
                break;
            }
            case GridEffect.REWARD_wuxing: 
            {
                player.ChangeWuxingBy(10);
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
                player.ChangeExpBy(-10);
				break;
			}
            case GridEffect.PENALTY_wuxing:
			{
                player.ChangeWuxingBy(-10);
				break;
			}
            case GridEffect.PENALTY_dice:
			{
				break;
			}
            case GridEffect.PENALTY_coin:
			{
                player.ChangeMoneyBy(-10);
				break;
			}
            default:
                break;
        }
    }
}
