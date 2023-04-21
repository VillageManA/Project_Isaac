using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour
{
    private float curhp;
    public float CurHp
    {
        get { return curhp; }
        set 
        { 
            curhp = value; 
            if (curhp<0)
            {
                curhp = 0;
            }
        }
    }

    private PlayerStats playerStats;
    private PlayerControl player;
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        player = FindObjectOfType<PlayerControl>();
    }


}
