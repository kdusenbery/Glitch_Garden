using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Timer in SECONDS")]
    [SerializeField] float levelTime = 10f;

    bool timerFinished = false;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if(triggeredLevelFinished) { return; };

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().SetTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
