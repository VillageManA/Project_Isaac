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
                        playerStats.Speed += 0.3f;
                        playerControl.transform.localScale = new Vector3(1.2f, 1.2f, 1);
                        //공격력배율 1.5배
                    }
                    break;

                case EItem.SadOnion:
                    {
                        playerStats.AttackSpeed += 0.7f;

                    }
                    break;
                case EItem.WireCoatHanger:
                    {
                        playerStats.AttackSpeed += 0.7f;

                    }
                    break;
                case EItem.MiniMush:
                    {
                        playerStats.Speed += 0.3f;
                        playerControl.transform.localScale = new Vector3(0.7f, 0.7f, 1);
                    }
                    break;
                case EItem.MoneyEqualPower:
                    {
                        playerStats.Attack += playerStats.Money*0.04f;

                    }
                    break;
                case EItem.Sqeezuy:
                    {
                        playerStats.AttackSpeed += 0.4f;
                        obj = Instantiate(FullSoulHeart, transform.position, Quaternion.identity);
                        obj.transform.position = new Vector3(transform.position.x-0.4f, transform.position.y-0.4f, 0);
                        obj = Instantiate(FullSoulHeart, transform.position, Quaternion.identity);
                        obj.transform.position = new Vector3(transform.position.x+0.4f, transform.position.y-0.4f, 0);

                    }
                    break;
                case EItem.ToothPicks:
                    {
                        playerStats.AttackSpeed += 0.7f;
                        //눈물색변경
                    }
                    break;
                case EItem.Pyro:
                    {
                        playerStats.Boom = 99;

                    }
                    break;
                case EItem.MutantSpider:
                    {
                        //공속배수 0.42 
                        //눈물 4개

                    }
                    break;
                case EItem.Polyphemus:
                    {
                        playerStats.Attack += 4;
                        //데미지배수 2배
                        //공속 배수 0.42

                    }
                    break;
            }

        }
    }
}
