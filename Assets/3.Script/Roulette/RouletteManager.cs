using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteManager : MonoBehaviour
{
    [SerializeField] private GameObject Slot;

    [SerializeField] private GameObject MoneyBeggar;
    [SerializeField] private GameObject KeyBeggar;
    [SerializeField] private GameObject HeartBeggar;
    [SerializeField] private GameObject BoomBeggar;
    [SerializeField] private PlayerStats playerStats;

    private Animator animator;

 
    private void Awake()
    {
        TryGetComponent(out playerStats);
        Slot.TryGetComponent(out animator);
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")// && playerStats.Money>0
            )
        {
            //StartCoroutine(SlotStart_co());
        }
    }



}
