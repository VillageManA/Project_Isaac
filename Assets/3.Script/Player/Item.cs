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
    CuppidArrow,
    MagicMushRoom,
    WireCoatHanger,
    MiniMush,
    MoneyEqualPower,
    Sqeezuy,
    TheWafer,
    SadOnion,
    ToothPicks,
    MutantSpider,
    Polyphemus,
    Pyro



}

public class Item : MonoBehaviour
{
    private HealthUI healthUI;
    private PlayerStats playerStats;

    [SerializeField] private EItem itemType;
    [SerializeField] private AudioSource ETC;
    [SerializeField] private AudioClip Soul;
    [SerializeField] private AudioClip Coin;
    [SerializeField] private AudioClip Key;

    [SerializeField] private AudioSource Audio;
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        healthUI = FindObjectOfType<HealthUI>();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (itemType)
            {
                case EItem.Coin:
                    {
                        if (playerStats.Money < 99)
                        {
                            StartCoroutine(Audio_co(Coin));
                            playerStats.Money += 1;
                            Destroy(gameObject);
                        }
                    }
                    break;
                case EItem.Coin5:
                    {
                        if (playerStats.Money < 99)
                        {
                            StartCoroutine(Audio_co(Coin));
                            playerStats.Money += 5;
                            Destroy(gameObject);
                        }
                    }
                    break;
                case EItem.Coin10:
                    {
                        if (playerStats.Money < 99)
                        {
                            StartCoroutine(Audio_co(Coin));
                            playerStats.Money += 10;
                            Destroy(gameObject);
                        }
                    }
                    break;
                case EItem.Key:
                    {
                        if (playerStats.Key < 99)
                        {
                            StartCoroutine(Audio_co(Key));
                            playerStats.Key += 1;
                            Destroy(gameObject);
                        }
                    }
                    break;
                case EItem.Bomb:
                    {
                        if (playerStats.Boom < 99)
                        {

                            playerStats.Boom += 1;
                            Destroy(gameObject);
                        }
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
                        playerStats.GetHp(1f);
                        Destroy(gameObject);
                        healthUI.UpdateHeart();
                        break;
                    case EItem.HalfHeart:
                        playerStats.GetHp(0.5f);
                        Destroy(gameObject);
                        healthUI.UpdateHeart();
                        break;
                }
            }
            if (playerStats.MaxHp + playerStats.SoulHp < 12)
                switch (itemType)
                {
                    case EItem.FullSourHeart:
                        StartCoroutine(Audio_co(Soul));
                        playerStats.SoulHp += 1;
                        Destroy(gameObject);
                        healthUI.UpdateHeart();
                        break;
                }

        }
    }

    public IEnumerator Audio_co(AudioClip Name)
    {
        Audio.PlayOneShot(Name);
        transform.position = new Vector3(-999, 999, 999);
        yield return new WaitForSeconds(1f);

    }
}
