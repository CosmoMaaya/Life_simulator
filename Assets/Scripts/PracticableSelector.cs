using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PracticableSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Dropdown m_dropdown;
    public TMP_Text practiceButtonText;
    public Button practiceButton;
    void Start()
    {
        m_dropdown.ClearOptions();
        PopulateList();
        OnDropdownIndexChanged(m_dropdown.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDropdownIndexChanged(int index) {
        if (index < (int) PropertyName.Count) {
            practiceButtonText.text = String.Format("practice: {0}", (PropertyName)index);
        } else {
            practiceButtonText.text = String.Format("practice: {0}", (SkillName) (index- PropertyName.Count));
        }
    }

    void PopulateList()
    {
        string[] propertyNames = Enum.GetNames(typeof(PropertyName));
        List<string> namesList = new List<string>(propertyNames);
        
        string[] skillNames = Enum.GetNames(typeof(SkillName));
        List<string> skillNamesList = new List<string>(skillNames);
        
        m_dropdown.AddOptions(namesList.Concat(skillNamesList).ToList());
    }
}
