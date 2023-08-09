using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Practicable
{
    public int Level {get; set;}
    public int LevelLimit {get; protected set;}
    public int PracticeLevelLimit {get; protected set;}
    public int PracticeProg{get; set;}
    public int PracticeProgLimit{get; set;}
    
    public void Practice(int prog) {
        if (Level >= LevelLimit) {return;}
        PracticeProg += prog;
        if (PracticeProg >= PracticeProgLimit) {
            PracticeProg -= PracticeProgLimit;
            Level = Math.Min(PracticeLevelLimit, Level+1);
        }
    }

    public void ChangeLevel(int amount) {
        Level += amount;
        Level = Math.Max(Math.Min(LevelLimit, Level), 0);
    }
}

public class GeneralProperty : Practicable{
    public GeneralProperty() {
        Level = 10;
        LevelLimit = PracticeLevelLimit = 90;
        PracticeProg = 0;
        PracticeProgLimit = 100;
    }
}

public enum PropertyName {
    HEALTH,
    STAMINA,
    AGILITY,
    SPIRIT,
    INTELLECT
}
public class GeneralSkill : Practicable{
    public GeneralSkill() {
        Level = 10;
        LevelLimit = 90;
        PracticeLevelLimit = 70;
        PracticeProg = 0;
        PracticeProgLimit = 100;
    }
}

public enum SkillName {
    DUANTI,
    FASHU,
    ZHENFA,
    HUANSHU,
    DANYAO,
    FUZHI,
    LIANQI,
    TUIYAN
}

public class Player : MonoBehaviour
{
    public Level myLevel = Level.Fengchu;
    public int position = 0;
    public int exp = 0, money = 0, wuxing = 100;

    public Dictionary<PropertyName, GeneralProperty> PropertySet = new Dictionary<PropertyName, GeneralProperty>();
    public Dictionary<SkillName, GeneralSkill> SkillSet = new Dictionary<SkillName, GeneralSkill>();
    // Start is called before the first frame update
    void Start()
    {
        var property_values = Enum.GetValues(typeof(PropertyName)).Cast<PropertyName>();
        foreach (var value in property_values) {
            PropertySet.Add(value, new GeneralProperty());
        }

        var skill_values = Enum.GetValues(typeof(SkillName)).Cast<SkillName>();
        foreach (var value in skill_values) {
            SkillSet.Add(value, new GeneralSkill());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GeneralProperty GetARandomProperty() {
        System.Random random = new System.Random();
        int index = random.Next(PropertySet.Count);

        //string key = dictionary.Keys.ElementAt(index);
        //int value = dictionary.Values.ElementAt(index);
        KeyValuePair<PropertyName, GeneralProperty> pair = PropertySet.ElementAt(index);
        return pair.Value;
    }
    public void Move(int step) {
        position += step;
        position = Math.Min(position, Globals.LIFE_BOUND[myLevel]);
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
        probability /= 100;
        exp -= expUsed;

        return UnityEngine.Random.value <= probability;
    }
}
