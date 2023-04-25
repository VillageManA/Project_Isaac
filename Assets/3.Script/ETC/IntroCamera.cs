using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroCamera : MonoBehaviour
{
    [SerializeField] AudioClip space;
    [SerializeField] AudioClip GameStart;
    [SerializeField] AudioSource audioSource;
    private bool isSound = false;
    void Update()
    {
        if (isSound)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.transform.position.y <= 0 && gameObject.transform.position.y > -36)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 12, -1);
                audioSource.PlayOneShot(space);
            }
            else if (gameObject.transform.position.y == -36)
            {
                isSound = true;
                StartCoroutine(StartAudio_co());

            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameObject.transform.position.y == 0)
            {
                //게임종료
            }
            else if (gameObject.transform.position.y >= -36)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 12, -1);
                audioSource.PlayOneShot(space);
            }

        }
    }

    public IEnumerator StartAudio_co()
    {
        audioSource.PlayOneShot(GameStart);
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene("Stage1");
        isSound =false;
    }
}
