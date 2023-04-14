using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItem
{
    Coin,
    Coin5,
    Coin10,
    Key,
    Bomb,
    FullHeart,
    HalfHeart,
    FullSourHeart
}

public class Item : MonoBehaviour
{
    private PlayerStats Player;

    [SerializeField] private EItem itemType;

    private void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerStats>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (itemType)
            {
                case EItem.Coin:
                    Player.Money += 1;
                    break;
                case EItem.Coin5:
                    Player.Money += 5;
                    break;
                case EItem.Coin10:
                    Player.Money += 10;
                    break;
                case EItem.Key:
                    Player.Key += 1;
                    break;
                case EItem.Bomb:
                    Player.Boom += 1;
                    break;

                default:
                    break;
            }

            Destroy(gameObject);
            if (Player.curHp < 12 && Player.curHp < Player.MaxHp)
            {
                switch (itemType)
                {
                    case EItem.FullHeart:
                        Player.curHp += 1;
                        break;
                    case EItem.HalfHeart:
                        Player.curHp += 0.5f;
                        break;
                }
            }
            if (Player.MaxHp + Player.SoulHp < 12)
            switch(itemType)
            {
                case EItem.FullSourHeart:
                    Player.SoulHp += 1;
                    break;
            }

        }
    }
}
