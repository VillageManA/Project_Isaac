using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItem
{
    Coin,
    Key,
    Bomb,
    HalfHeart,
    FullHeart,
    FullSourHeart,
    Coin5,
    Coin10,
    Dinner,
    CuppidArrow


}

public class Item : MonoBehaviour
{
    private PlayerStats playerStats;

    [SerializeField] private EItem itemType;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (itemType)
            {
                case EItem.Coin:
                    {
                        playerStats.Money += 1;
                        Destroy(gameObject);
                    }
                    break;
                case EItem.Coin5:
                    {
                        playerStats.Money += 5;
                        Destroy(gameObject);
                    }
                    break;
                case EItem.Coin10:
                    {
                        playerStats.Money += 10;
                        Destroy(gameObject);
                    }
                    break;
                case EItem.Key:
                    {
                        playerStats.Key += 1;
                        Destroy(gameObject);
                    }
                    break;
                case EItem.Bomb:
                    {
                        playerStats.Boom += 1;
                        Destroy(gameObject);
                    }
                    break;

                default:
                    break;
            }


            if (playerStats.curHp < 12 && playerStats.curHp < playerStats.MaxHp)
            {
                switch (itemType)
                {
                    case EItem.FullHeart:
                        playerStats.curHp += 1;
                        Destroy(gameObject);
                        break;
                    case EItem.HalfHeart:
                        playerStats.curHp += 0.5f;
                        Destroy(gameObject);
                        break;
                }
            }
            if (playerStats.MaxHp + playerStats.SoulHp < 12)
                switch (itemType)
                {
                    case EItem.FullSourHeart:
                        playerStats.SoulHp += 1;
                        Destroy(gameObject);
                        break;
                }

        }
    }
}
