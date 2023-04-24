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
        ItemUI.SetActive(false);
        Hp.SetActive(false);
        UI.SetActive(true);
        yield return new WaitForSeconds(3f);
        UI.SetActive(false);
        Hp.SetActive(true);
        ItemUI.SetActive(true);
        boss.SetActive(true);
        BossSpwan = true;
    }
}
