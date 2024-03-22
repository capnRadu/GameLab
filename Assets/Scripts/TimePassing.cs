using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimePassing : MonoBehaviour
{
    [SerializeField] private List<GameObject> seconds = new List<GameObject>();
    [SerializeField] private TextMeshProUGUI timeText;
    private int year = 1;
    private int month = 1;
    private int week = 1;
    private float secondsPassed = 0;

    [NonSerialized] public bool isPaused = true;

    private void Update()
    {
        if (!isPaused)
        {
            secondsPassed += Time.deltaTime;

            int dotsToActivate = Mathf.FloorToInt(secondsPassed / 1f);

            for (int i = 0; i < dotsToActivate; i++)
            {
                seconds[i].SetActive(true);
            }

            for (int i = dotsToActivate; i < seconds.Count; i++)
            {
                seconds[i].SetActive(false);
            }

            if (dotsToActivate > 5)
            {
                secondsPassed = 0;

                week++;
                if (week > 4)
                {
                    week = 1;
                    month++;
                    if (month > 12)
                    {
                        month = 1;
                        year++;
                    }
                }
            }

            timeText.text = $"Y{year} M{month} W{week}";
        }
    }
}
