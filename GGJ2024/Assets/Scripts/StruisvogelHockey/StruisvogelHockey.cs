using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StruisvogelHockey : MonoBehaviour
{
    public static StruisvogelHockey Instance { get; private set; }
    public Transform[] targetPoints;
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public GameObject scorePanel, tutorialPanel;
    public TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        if(Instance != null) { Destroy(Instance); }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameLoopC());
    }

    IEnumerator GameLoopC()
    {        
        while(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) { yield return null; }

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 2.5f));
            tutorialPanel.SetActive(false);
            Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(5.0f);
        scoreText.text = score.ToString();
        scorePanel.SetActive(true);
        GameManager.Instance.Score += score;

        yield return new WaitForSeconds(3.0f);
        GameManager.Instance.NextScene();
    }

    public void ScoreBall()
    {
        score++;
    }

    public Transform GetRandomTarget()
    {
        return Utility.Pick(targetPoints);
    }
}
