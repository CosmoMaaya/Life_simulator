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
        award = (Random.value <= 0.2);
        myEffect = generateEffect();
    }

    GridEffect generateEffect() {
        var effect_values = System.Enum.GetValues(typeof(GridEffect)).Cast<int>();
        //.Cast<GridEffect>()
        while (true) {
            foreach (var effect in effect_values)
            {
                if (award && effect < (int) GridEffect.SPLIT && Random.value <= Globals.EFFECT_PROB[(GridEffect) effect]) {
                    return (GridEffect) effect;
                }
                if (!award && effect > (int) GridEffect.SPLIT && Random.value <= Globals.EFFECT_PROB[(GridEffect) effect]) {
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
