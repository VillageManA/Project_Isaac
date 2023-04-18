using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemList")]
public class ItemList : ScriptableObject
{
    public string ItemName;
    public Sprite sprite;
    
    public float Money;
    public float Bomb;
    public float Key;

    public float CurHp;
    public float MaxHp;
    public float Attack;
    public float AttackSpeed;
    public float Speed;
    public float Range;
    public float SoulHp;

    //--����--
    public int Pierce;
    public int Multishot;
    public int Polyphemus;
    public enum ItemType
    {
        Money,
        Bomb,
        Key,
        HalfHeart,
        FullHeart,
        HalfSoulHeart,
        FullSoulHeart,

        //���⼭���� ���ɾ�����
        Sad_Onion,
        Mini_Mush,
        Money_Equal_Power,
        Mutant_Spider,
        Polyphemus


    }

}
