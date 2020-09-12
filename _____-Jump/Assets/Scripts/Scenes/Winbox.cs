using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winbox : MonoBehaviour
{
    [SerializeField] private int nextSceneIndex = 0;
    [SerializeField] private GameObject loadingScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            loadingScreen.SetActive(true);
        }
    }
}
