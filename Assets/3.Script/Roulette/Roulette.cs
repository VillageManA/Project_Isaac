using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject SlotRandom;
    [SerializeField] private GameObject SlotRandom2;
    [SerializeField] private GameObject SlotRandom3;
    public IEnumerator SlotStart_co()
    {
        animator.SetTrigger("SlotConfirm");
        SlotRandom.SetActive(true);
        SlotRandom2.SetActive(true);
        SlotRandom3.SetActive(true);
        yield return new WaitForSeconds(3f);
        SlotRandom.SetActive(false);
        SlotRandom2.SetActive(false);
        SlotRandom3.SetActive(false);
        //MeetPlayer = 0;

        //랜덤으로 아이템 배열에서 꺼내서 
    }
    public IEnumerator MoneyBeggarStart_co()
    {
        yield return new WaitForSeconds(3f);
    }
}
