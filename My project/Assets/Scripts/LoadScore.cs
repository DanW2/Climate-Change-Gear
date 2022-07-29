using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour
{
    private float time = 0;
    private string score;
    public Text UICounter;

    void Update()
    {
        time += Time.deltaTime;
        score = time.ToString("0.00");
        UICounter.text = score;
    }
}
