using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject SlotRandom;
    [SerializeField] private GameObject SlotRandom2;
    [SerializeField] private GameObject SlotRandom3;
    private PlayerStats playerStats;
    private EItem item;

    public enum Beggar
    {
        Slot,
        MoneyBeggar,
        HeartBeggar,
        KeyBeggar,
        BoomBeggar
    }
    [SerializeField] private Beggar roulette;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerStats = FindObjectOfType<PlayerStats>();

    }
    public IEnumerator SlotStart_co()
    {
        animator.SetTrigger("SlotStart");
        SlotRandom.SetActive(true);
        SlotRandom2.SetActive(true);
        SlotRandom3.SetActive(true);
        yield return new WaitForSeconds(2.6f);
        SlotRandom.SetActive(false);
        SlotRandom2.SetActive(false);
        SlotRandom3.SetActive(false);


        //Instantiate(item[Random.Range(0,6)], transform.position, Quaternion.identity);
        //MeetPlayer = 0;

        //랜덤으로 아이템 배열에서 꺼내서 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (roulette)
            {
                case Beggar.Slot:
                    {
                        if (playerStats.Money > 0)
                        {
                            playerStats.Money -= 1;
                            StartCoroutine(SlotStart_co());
                        }
                    }
                    break;
                case Beggar.HeartBeggar:
                    {
                        if (playerStats.curHp > 0f)
                        {
                            playerStats.curHp -= 0.5f;
                        }
                    }
                    break;
                case Beggar.MoneyBeggar:
                    {
                        if (playerStats.Money > 0)
                        {
                            playerStats.Money -= 1;
                        }
                    }
                    break;
                case Beggar.KeyBeggar:
                    {
                        if(playerStats.Key>0)
                        {
                            playerStats.Key -= 1;
                        }
                    }
                    break;
                case Beggar.BoomBeggar:
                    {
                        if(playerStats.Boom>0)
                        {
                            playerStats.Boom -= 1;
                        }
                    }
                    break;
                default:
                    break;
            }

        }
    }

    public IEnumerator BeggarStart_co()
    {
        animator.SetTrigger("Confirm");
        yield return new WaitForSeconds(5f);
    }
}
