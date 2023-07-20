using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    Fengchu,
    Qingxin,
    Tengyun,
    Huiyang,
    Qianyuan,
    Wuxiang
}

public class GameManager : MonoBehaviour
{   
    public static GameManager instance = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null) {
            instance = this;
        }
        else {
            Destroy(this);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
