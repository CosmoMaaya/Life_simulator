using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PracticableElementUI : MonoBehaviour
{
    public TMP_Text nameTMP, levelTMP, progTMP;

    // As a temp solution, both property name and skill name use the same UI class. 
    public bool IsProperty;
    public PropertyName propertyName;
    public SkillName skillName;
    // Start is called before the first frame update
    // IEnumerator Start()
    void Start()
    {
        // yield return new WaitForSeconds(1);
        registerToPracticable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void registerToPracticable() {
        if (IsProperty) {
            Player.Instance.PropertySet[propertyName].Subscribe(this);
        } else {
            Player.Instance.SkillSet[skillName].Subscribe(this);
        }
        return;
    }

    public void UpdateUI(int level, int prog, int progLimit) {
        if (IsProperty) {
            nameTMP.text=propertyName.ToString();
        } else {
            nameTMP.text=skillName.ToString();
        }
        levelTMP.text = level.ToString();
        progTMP.text= String.Format("{0}/{1}", prog, progLimit);
    }
}
