using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{   
    List<GridUnit> tiles = new List<GridUnit> ();
    int mapSize = 32;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < mapSize; i++) {
            tiles.Add(new GridUnit());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
