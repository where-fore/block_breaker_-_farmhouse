using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTextManager : MonoBehaviour
{
    private int startingScore = 0;

    private void Start()
    {
        UpdateScoreTo(startingScore);
    }

    public void UpdateScoreTo(int newScore)
    {
        GetComponent<TextMeshProUGUI>().text = newScore.ToString();
    }
}
