using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public static T Clamp<T> (T value, T min, T max) where T : IComparable<T> {
        if (value.CompareTo(min) < 0) {
            return min;
        }
        if (value.CompareTo(max) > 0) {
            return max;
        }
        return value;
    }
}