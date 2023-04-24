using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(End_co());
    }

    public IEnumerator End_co()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Intro");
    }
}
