using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    int score;
    public int Score
    {
        get { return score; }
        set { score = value; totalScore.text = score.ToString(); }
    }
    public TextMeshProUGUI totalScore, scoredText;
    public GameObject scorePanel;
    float scoreTimer = 0.0f;


    private void Awake()
    {
        if(Instance != null) { Destroy(Instance); }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int _score)
    {
        Score += _score;
        StartCoroutine(ShowScore(_score));
    }

    IEnumerator ShowScore(int _score)
    {
        if (scoreTimer > 0.0f) { scoreTimer = 3.0f; yield break; }

        scorePanel.SetActive(true);
        scoredText.text = _score.ToString();
        scoreTimer = 3.0f;

        while(scoreTimer > 0.0f)
        {
            yield return null;
            scoreTimer -= Time.deltaTime;            
        }

        scorePanel.SetActive(false);
        scoreTimer = 0.0f;
    }
}
