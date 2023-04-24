using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroCamera : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.transform.position.y <= 0 && gameObject.transform.position.y > -36)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 12,-1);
            }
            else if (gameObject.transform.position.y == -36)
            {
                SceneManager.LoadScene("Stage1");
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
                transform.position = new Vector3(transform.position.x, transform.position.y + 12);
            }

        }
    }
}
