using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject spherePrefab;
    private int numberOfBallsToSpawn = 1;

    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(
            EventNames.HOEventBroadcasting.INPUT_NUMBER_BALLS_CHANGED,
            this.UpdateBallNumber
            );
        EventBroadcaster.Instance.AddObserver(
            EventNames.HOEventBroadcasting.BUTTON_SPAWN_BALLS_PRESSED,
            this.SpawnBalls
            );
        EventBroadcaster.Instance.AddObserver(
            EventNames.HOEventBroadcasting.BUTTON_CLEAR_ALL_PRESSED,
            this.ClearBalls
            );
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(
            EventNames.HOEventBroadcasting.INPUT_NUMBER_BALLS_CHANGED,
            this.UpdateBallNumber);
        EventBroadcaster.Instance.RemoveActionAtObserver(
            EventNames.HOEventBroadcasting.BUTTON_SPAWN_BALLS_PRESSED,
            this.SpawnBalls);
        EventBroadcaster.Instance.RemoveActionAtObserver(
            EventNames.HOEventBroadcasting.BUTTON_CLEAR_ALL_PRESSED,
            this.ClearBalls);
    }

    private void UpdateBallNumber(Parameters param)
    {
        numberOfBallsToSpawn = param.GetIntExtra("ballCount", 0);
    }
    private void SpawnBalls()
    {
        for(int i = 0; i < numberOfBallsToSpawn; i++)
        {
            Instantiate(spherePrefab, Vector3.zero, Quaternion.identity, this.transform);
        }
    }
    private void ClearBalls()
    {
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }



}
