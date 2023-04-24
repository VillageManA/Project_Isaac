using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldRoomMap : MonoBehaviour
{
    [SerializeField] private GameObject SadOnion;
    [SerializeField] private GameObject MagicMushRoom;
    [SerializeField] private GameObject WireCoatHanger;
    [SerializeField] private GameObject MiniMush;
    [SerializeField] private GameObject Sqeezuy;
    [SerializeField] private GameObject ToothPicks;
    [SerializeField] private GameObject Pyro;
    [SerializeField] private GameObject MoneyEqualPower;

    private bool isGone = false;
    private int RandomColItem;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isGone)
        {
            RandomColItem = Random.Range(0, 8);
            switch (RandomColItem)
            {
                case 0:
                    {
                        Instantiate(SadOnion, transform.position, Quaternion.identity);
                        isGone = true;
                    }
                    break;
                case 1:
                    {
                        Instantiate(MagicMushRoom, transform.position, Quaternion.identity);
                        isGone = true;
                    }
                    break;
                case 2:
                    {
                        Instantiate(WireCoatHanger, transform.position, Quaternion.identity);
                        isGone = true;
                    }
                    break;
                case 3:
                    {
                        Instantiate(MiniMush, transform.position, Quaternion.identity);
                        isGone = true;
                    }
                    break;
                case 4:
                    {
                        Instantiate(Sqeezuy, transform.position, Quaternion.identity);
                        isGone = true;
                    }
                    break;
                case 5:
                    {
                        Instantiate(ToothPicks, transform.position, Quaternion.identity);
                        isGone = true;
                    }
                    break;
                case 6:
                    {
                        Instantiate(Pyro, transform.position, Quaternion.identity);
                        isGone = true;
                    }
                    break;
                case 7:
                    {
                        Instantiate(MoneyEqualPower, transform.position, Quaternion.identity);
                        isGone = true;
                    }
                    break;
            }
        }
    }
}
