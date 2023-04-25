using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMap : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Hp;
    [SerializeField] GameObject ItemUI;
    [SerializeField] AudioSource Audio;
    [SerializeField] AudioClip Intro;
    [SerializeField] AudioClip BossRoom;
    private bool BossSpwan = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !BossSpwan)
        {
            StartCoroutine(BossUI());
        }
    }

    public IEnumerator BossUI()
    {
        Audio.clip = Intro;
        Audio.Play();
        ItemUI.SetActive(false);
        Hp.SetActive(false);
        UI.SetActive(true);
        yield return new WaitForSeconds(3f);
        Audio.clip = BossRoom;
        Audio.Play();
        UI.SetActive(false);
        Hp.SetActive(true);
        ItemUI.SetActive(true);
        boss.SetActive(true);
        BossSpwan = true;
    }
}
