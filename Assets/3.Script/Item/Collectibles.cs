using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private EItem item;
    private PlayerStats playerStats;
    private HealthUI helthUI;
    private PlayerControl playerControl;
    [SerializeField] private GameObject FullSoulHeart;
    [SerializeField] private GameObject CurItem;
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
                case EItem.MagicMushRoom:
                    {
                        playerStats.MaxHp += 1;
                        playerStats.curHp += 1;
                        helthUI.UpdateHeart();
                        playerStats.Attack += 0.3f;
                        //playerStats.Speed += 0.3f;
                        playerControl.transform.localScale = new Vector3(1.2f, 1.2f, 1);
                        //공격력배율 1.5배
                        ItmeMotion();
                    }
                    break;

                case EItem.SadOnion:
                    {
                        playerStats.AttackSpeed += 0.4f;
                        ItmeMotion();
                    }
                    break;
                case EItem.WireCoatHanger:
                    {
                        playerStats.AttackSpeed += 0.4f;
                        ItmeMotion();
                    }
                    break;
                case EItem.MiniMush:
                    {
                        //playerStats.Speed += 0.3f;
                        playerControl.transform.localScale = new Vector3(0.7f, 0.7f, 1);
                        ItmeMotion();
                    }
                    break;
                case EItem.MoneyEqualPower:
                    {
                        playerStats.Attack += playerStats.Money * 0.04f;
                        ItmeMotion();
                    }
                    break;
                case EItem.Sqeezuy:
                    {
                        playerStats.AttackSpeed += 0.3f;
                        obj = Instantiate(FullSoulHeart, transform.position, Quaternion.identity);
                        obj.transform.position = new Vector3(transform.position.x - 0.6f, transform.position.y - 0.4f, 0);
                        obj = Instantiate(FullSoulHeart, transform.position, Quaternion.identity);
                        obj.transform.position = new Vector3(transform.position.x + 0.6f, transform.position.y - 0.4f, 0);
                        ItmeMotion();
                    }
                    break;
                case EItem.ToothPicks:
                    {
                        playerStats.AttackSpeed += 0.4f;
                        //눈물색변경
                        ItmeMotion();
                    }
                    break;
                case EItem.Pyro:
                    {
                        playerStats.Boom = 99;
                        ItmeMotion();
                    }
                    break;
                case EItem.MutantSpider:
                    {
                        ItmeMotion();
                        //공속배수 0.42 
                        //눈물 4개

                    }
                    break;
                case EItem.Polyphemus:
                    {
                        playerStats.Attack += 4;
                        ItmeMotion();
                        //데미지배수 2배
                        //공속 배수 0.42

                    }
                    break;
            }

        }
    }

    public void ItmeMotion()
    {
        Destroy(gameObject);
        obj = Instantiate(CurItem, playerControl.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        playerControl.StartCoroutine(playerControl.GetItem_co());
        Destroy(obj, 0.5f);
    }
}
