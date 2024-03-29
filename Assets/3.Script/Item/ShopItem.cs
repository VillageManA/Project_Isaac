using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShopItem : MonoBehaviour
{
    private PlayerStats playerStats;
    [SerializeField] private EItem item;
    private PlayerControl playerControl;
    private Animator animator;
    private HealthUI helthUI;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject EmptyPedestal;
    [SerializeField] private GameObject CurItem;

    [SerializeField] private AudioSource ETC;
    [SerializeField] private AudioClip Soul;
    [SerializeField] private AudioClip Coin;
    [SerializeField] private AudioClip Key;
    [SerializeField] private AudioClip GetItem;
    private GameObject obj;
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerControl = FindObjectOfType<PlayerControl>();
        helthUI = FindObjectOfType<HealthUI>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (item)
            {
                case EItem.Key:
                    {
                        if (playerStats.Money >= 5 && playerStats.Key < 99)
                        {
                            ETC.PlayOneShot(Key);
                            playerStats.Money -= 5;
                            playerStats.Key += 1;
                            Destroy(gameObject);
                        }
                    }
                    break;
                case EItem.FullHeart:
                    {
                        if (playerStats.Money >= 3 && playerStats.curHp < playerStats.MaxHp)
                        {
                            playerStats.Money -= 3;
                            playerStats.GetHp(1f);
                            Destroy(gameObject);
                            helthUI.UpdateHeart();
                        }
                    }
                    break;
                case EItem.FullSourHeart:
                    {
                        if (playerStats.Money >= 5 && playerStats.MaxHp + playerStats.SoulHp < 12)
                        {
                            ETC.PlayOneShot(Soul);
                            playerStats.Money -= 5;
                            playerStats.SoulHp += 1;
                            Destroy(gameObject);
                            helthUI.UpdateHeart();
                        }
                    }
                    break;
                case EItem.Dinner:
                    {
                        if (playerStats.Money >= 15 && playerStats.MaxHp < 12)
                        {
                            ETC.PlayOneShot(GetItem);
                            playerStats.Money -= 15;
                            playerStats.MaxHp += 1;
                            playerStats.curHp += 1;
                            helthUI.UpdateHeart();
                            Destroy(gameObject);
                            Instantiate(EmptyPedestal, transform.position, Quaternion.identity);
                            obj = Instantiate(CurItem, player.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                            playerControl.StartCoroutine(playerControl.GetItem_co());
                            Destroy(obj, 0.5f);
                        }
                    }
                    break;
                case EItem.CuppidArrow:
                    {
                        if (playerStats.Money >= 15)
                        {
                            ETC.PlayOneShot(GetItem);
                            playerStats.Money -= 15;
                            playerStats.Pierce = 1;
                            Destroy(gameObject);
                            Instantiate(EmptyPedestal, transform.position, Quaternion.identity);
                            obj = Instantiate(CurItem, player.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                            playerControl.StartCoroutine(playerControl.GetItem_co());
                            Destroy(obj, 0.5f);
                            // Destroy(obj);
                        }
                    }
                    break;
                case EItem.Bomb:
                    {
                        if (playerStats.Money >= 5 && playerStats.Boom < 99)
                        {
                            playerStats.Money -= 5;
                            playerStats.Boom += 1;
                            Destroy(gameObject);
                        }
                    }
                    break;

            }
        }
    }
    
}
