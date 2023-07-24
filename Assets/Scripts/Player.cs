using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Level myLevel = Level.Fengchu;
    public int position = 0;
    public int xiuwei = 0, money = 0, wuxing = 100;
    public int breakThes;
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

    public bool LevelUp() {
        if (xiuwei < breakThes) {
            return false;
        }

        // TODO: A mechanism to reflect the probability of success.
        return true;
    }
}
