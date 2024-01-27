using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishBowling : MonoBehaviour
{
    int pinsToppled = 0;
    public static FishBowling Instance { get; private set; }
    bool isScoring = false;
    public TextMeshProUGUI scoredText;
    public GameObject scorePanel;

    private void Awake()
    {
        if(Instance != null) { Destroy(Instance); }
        Instance = this;
    }

    public void ScorePin()
    {
        pinsToppled++;
    }

    public void CalculateScore()
    {
        StartCoroutine(CalculateScoreC());
    }

    IEnumerator CalculateScoreC()
    {
        if (isScoring) { yield break; }
        isScoring = true;
        yield return new WaitForSeconds(5.0f);
        scoredText.text = pinsToppled.ToString();
        GameManager.Instance.Score += pinsToppled;
        scorePanel.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        GameManager.Instance.NextScene();
    }
}
