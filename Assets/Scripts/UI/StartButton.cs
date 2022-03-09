using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour
{
    public void GoToInGameScene()
    {
        GameManager.Instance.GoToInGameScene();
    }
}