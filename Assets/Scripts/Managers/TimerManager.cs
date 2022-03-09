using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{

    [SerializeField]
    bool AutoStart;
    [SerializeField]
    int InitialTime;
    int TimeLeft;
    [SerializeField]
    int UpdateSeconds;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
        if (AutoStart)
        {
            StartTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        StartCoroutine(Time());
    }

    IEnumerator Time()
    {
        while(TimeLeft > 0)
        {
            yield return new WaitForSeconds(UpdateSeconds);
            TimeLeft -= UpdateSeconds;
        }
        TimeOver();
    }

    public void ResetTimer()
    {
        TimeLeft = InitialTime;
    }

    public int GetTimeLeft()
    {
        return TimeLeft;
    }

    public void TimeOver()
    {
        GameManager.Instance.GameOver();
    }
}
