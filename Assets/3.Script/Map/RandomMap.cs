using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    private float randomMon;
    public bool isSpwan;
    [SerializeField] private GameObject Sucker;
    [SerializeField] private GameObject Charger;
    [SerializeField] private GameObject KamiKazeLeech;
    [SerializeField] private GameObject Hopper;
    private void Awake()
    {
        isSpwan = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isSpwan)
        {
            randomMon = Random.Range(0, 5);
            switch (randomMon)
            {
                case 0:
                    {
                        Instantiate(Sucker, transform.position, Quaternion.identity);
                        Instantiate(Sucker, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                        Instantiate(Sucker, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                        Instantiate(Sucker, transform.position + new Vector3(1, 1, 0), Quaternion.identity);
                        isSpwan = true;
                    }
                    break;
                case 1:
                    {
                        Instantiate(Charger, transform.position, Quaternion.identity);
                        Instantiate(Charger, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                        Instantiate(Charger, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                        Instantiate(Charger, transform.position + new Vector3(1, 1, 0), Quaternion.identity);
                        isSpwan = true;

                    }
                    break;
                case 2:
                    {
                        Instantiate(KamiKazeLeech, transform.position, Quaternion.identity);
                        Instantiate(KamiKazeLeech, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                        Instantiate(KamiKazeLeech, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                        Instantiate(KamiKazeLeech, transform.position + new Vector3(1, 1, 0), Quaternion.identity);
                        isSpwan = true;
                    }
                    break;
                case 3:
                    {
                        Instantiate(Hopper, transform.position, Quaternion.identity);
                        Instantiate(Hopper, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                        Instantiate(Hopper, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                        Instantiate(Hopper, transform.position + new Vector3(1, 1, 0), Quaternion.identity);
                        isSpwan = true;
                    }
                    break;
                case 4:
                    {
                        Instantiate(Hopper, transform.position, Quaternion.identity);
                        Instantiate(Sucker, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                        Instantiate(KamiKazeLeech, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                        Instantiate(Charger, transform.position + new Vector3(1, 1, 0), Quaternion.identity);
                        isSpwan = true;
                    }
                    break;
                    
            }
        }
    }
}
