using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoomControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int boomCount;
    [SerializeField] GameObject BoomEffects;
    [SerializeField] GameObject BoomDamage;
    [SerializeField] GameObject BoomShape;
    Vector3 initialScale;
    // Start is called before the first frame update
    void Start()
    {

        TryGetComponent(out spriteRenderer);
        TryGetComponent(out Transform transform);

        boomCount = 0;
        StartCoroutine(Boom_co());
        BoomShape.SetActive(true);
        BoomShape.GetComponent<CircleCollider2D>().enabled = false;
        initialScale = new Vector3(1, 1, 1);



    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            BoomShape.GetComponent<CircleCollider2D>().enabled = true;

        }
    }
    public IEnumerator Boom_co()
    {
        WaitForSeconds wfs = new WaitForSeconds(0.1f);

        while (boomCount < 4)
        {


            BoomShape.GetComponent<SpriteRenderer>().color = Color.red;
            yield return wfs;
            BoomShape.GetComponent<SpriteRenderer>().color = Color.yellow;
            yield return wfs;
            BoomShape.GetComponent<SpriteRenderer>().color = Color.white;
            yield return wfs;
            boomCount++;
            if (boomCount == 4)
            {
                break;
            }
        }

        while (boomCount < 8)
        {


            BoomShape.GetComponent<SpriteRenderer>().color = Color.red;
            BoomShape.transform.localScale = new Vector3(initialScale.x, initialScale.y * 1.2f, initialScale.z);
            yield return wfs;
            BoomShape.GetComponent<SpriteRenderer>().color = Color.yellow;
            BoomShape.transform.localScale = new Vector3(initialScale.x, initialScale.y * 0.8f, initialScale.z);
            yield return wfs;
            BoomShape.GetComponent<SpriteRenderer>().color = Color.white;
            BoomShape.transform.localScale = initialScale;
            yield return wfs;
            boomCount++;
            if (boomCount == 8)
            { break; }

        }
        gameObject.transform.position = BoomShape.transform.position;
        BoomShape.SetActive(false);
        BoomEffects.SetActive(true);
        BoomDamage.SetActive(true);
        yield return wfs;

        BoomDamage.SetActive(false);
        yield return wfs;
        Destroy(gameObject);

    }


}
