using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridUnit : MonoBehaviour
{
    bool award;
    public GridEffect myEffect {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        award = (Random.value <= 0.7);
        myEffect = generateEffect();
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
                if (Random.value <= Globals.EFFECT_PROB[effect]) {
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
