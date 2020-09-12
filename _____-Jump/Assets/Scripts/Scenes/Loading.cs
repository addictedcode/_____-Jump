using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    AsyncOperation loadingOperation;
    Slider progressBar;

    private void Start()
    {
        loadingOperation = SceneManager.LoadSceneAsync(1);
    }

    void Update()
    {
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
    }
}
