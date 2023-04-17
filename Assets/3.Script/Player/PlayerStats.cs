using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Text MoneyText;
    [SerializeField]
    private Text BombText;
    [SerializeField]
    private Text KeyText;

    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    private float attack;
    public float Attack
    {
        get { return attack; }
        set { attack = value; }
    }
    private float maxhp;
    public float MaxHp
    {
        get { return maxhp; }
        set { maxhp = value; }
    }
    private float curhp;
    public float curHp
    {
        get { return curhp; }
        set
        {
            curhp = value;
            if (curhp <= 0)
            {
                //데드
            }
        }
    }
    private float soulhp;
    public float SoulHp
    {
        get { return soulhp; }
        set { soulhp = value; }
    }
    //public float attackSpeed; 추후 추가될수도있음 샷스피드
    public float range;
    private int money;
    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            MoneyText.text = money.ToString();
            money = Mathf.Clamp(money, 0, 99);
        }
    }
    private int boom;
    public int Boom
    {
        get { return boom; }
        set 
        {
            boom = value;
            BombText.text = boom.ToString();
            boom = Mathf.Clamp(boom, 0, 99);
        }
    }
    private int key;
    public int Key
    {
        get { return key; }
        set
        {
            key = value;
            KeyText.text = key.ToString();
            key = Mathf.Clamp(key, 0, 99);
        }
    }
    private int pierce;
    public int Pierce
    {
        get { return pierce; }
        set { pierce = value; }
    }
    /*
    시간되면 만들것
   private float Luck;
   private float ShootSpeed;
   private float AcitveGage;
    */

    private void Awake()
    {

        speed = 0.02f;
        Attack = 0f;
        MaxHp = 3f;
        curHp = 3f ;
        range = 4f;
        Money = 50;
        Boom = 50;
        Key = 0;
        pierce = 0;
    }
}
