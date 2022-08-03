using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour
{
    private string score;
    public Text UICounter;

    void Update()
    {
        score = FindObjectOfType<GameManager>().getScore();
        UICounter.text = score;
    }
}
