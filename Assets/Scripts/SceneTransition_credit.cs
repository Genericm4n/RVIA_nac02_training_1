using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition_credit : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("SceneTransitionStart");
    }

    private IEnumerator SceneTransitionStart()
    {
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("_1");
    }
}