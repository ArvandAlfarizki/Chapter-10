using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSetting : MonoBehaviour
{
    public Text TextTimer;
    public float Timer = 100;

    public bool Play = true;
    public GameObject GameOver;

    void SetText()
    {
        int Minutes = Mathf.FloorToInt(Timer / 60);
        int Seconds = Mathf.FloorToInt(Timer % 60);
        TextTimer.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");
    }

    float s;

    // Update is called once per frame
    private void Update()
    {
        if (Play)
        {
            s += Time.deltaTime;
            if(s >= 1)
            {
                Timer--;
                s = 0;
            }
        }

        if (Play && Timer <= 0)
        {
            Debug.Log("Time Out!");
            GameOver.SetActive(true);
            Play = false;
        }
        SetText();
    }
}
