using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void spawnBall()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.HOEventBroadcasting.BUTTON_SPAWN_BALLS_PRESSED);
    }

    public void clearAll()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.HOEventBroadcasting.BUTTON_CLEAR_ALL_PRESSED);
    }

    public void ballCountChanged(string text)
    {
        int number = int.Parse(text);
        Parameters param = new Parameters();
        param.PutExtra("ballCount", number);
        EventBroadcaster.Instance.PostEvent(EventNames.HOEventBroadcasting.INPUT_NUMBER_BALLS_CHANGED, param);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
