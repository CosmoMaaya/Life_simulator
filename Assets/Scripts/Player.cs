using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Level myLevel = Level.Fengchu;
    public int position = 0;
    public int exp = 0, money = 0, wuxing = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int step) {
        position += step;
    }

    public void ChangeExp(int amount) {
        exp += amount;
        exp = Math.Max(exp, 3 * Globals.LIFE_BOUND[myLevel]);
    }

    public bool LevelUp(int expUsed) {
        if (exp < Globals.EXP_BOUND[myLevel] / 3.0f) {
            return false;
        }

        // 2/6 = 50%, 5/6 = 90%, max 90%
        float probability = 80.0f * (expUsed / Globals.EXP_BOUND[myLevel] - 2.0f / 6.0f) + 50.0f;

        float res = UnityEngine.Random.Range(0.0f, 100.0f);

        exp -= expUsed;
        // TODO: A mechanism to reflect the probability of success.
        return res <= probability;
    }
}
