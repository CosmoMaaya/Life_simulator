using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using TMPro;

public class GridUnit : MonoBehaviour
{
    bool award;
    public GridEffect myEffect {get; private set;}
    public TMP_Text gridContent;
    public string gridText;
    // Start is called before the first frame update
    void Start()
    {
        award = (UnityEngine.Random.value <= 0.7);
        myEffect = generateEffect();

        gridText = String.Format("Grid Effect: {0}",
                         myEffect.ToString());
        gridContent.text = gridText;
    }

    public void Copy(GridUnit toBeCopied) {
        myEffect = toBeCopied.myEffect;
        gridText = toBeCopied.gridText;
        gridContent.text=gridText;
    }

    GridEffect generateEffect() {
        //.Cast<GridEffect>()
        var effect_iterate = Globals.REWARD_ORDER;
        if (!award) {
            effect_iterate = Globals.PENALTY_ORDER;
        }
        while (true) {
            foreach (var effect in effect_iterate)
            {
                if (UnityEngine.Random.value <= Globals.EFFECT_PROB[effect]) {
                    return (GridEffect) effect;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
