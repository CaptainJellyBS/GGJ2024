using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Fierljeppen : MonoBehaviour
{
    public static Fierljeppen Instance { get; private set; }
    public List<KeyCode> noteKeys = new List<KeyCode>() { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    public Zwaardvis player;
    public Transform rhythmControl;

    public TextMeshProUGUI scoredText;
    public GameObject scorePanel;

    float scoreTimer = 0.0f;

    private void Awake()
    {
        if (Instance != null) { Destroy(Instance); }
        Instance = this;
    }

    public float CalculateNoteScore(ZFNote note)
    {
        return 1.5f - Mathf.Abs(rhythmControl.position.x - note.transform.position.x);
    }

    public void IncreasePlayerSpeed(float acc)
    {
        Debug.Log(acc);
        player.IncreaseSpeed(acc);
    }

    public KeyCode GetRandomKey()
    {
        return Utility.Pick(noteKeys);
    }

    public void IncreaseScore(int _score)
    {
        GameManager.Instance.Score += _score;
        StartCoroutine(ShowScore(_score));
    }

    IEnumerator ShowScore(int _score)
    {
        if (scoreTimer > 0.0f) { scoreTimer = 3.0f; yield break; }

        scorePanel.SetActive(true);
        scoredText.text = _score.ToString();
        scoreTimer = 3.0f;

        while (scoreTimer > 0.0f)
        {
            yield return null;
            scoreTimer -= Time.deltaTime;
        }

        scorePanel.SetActive(false);
        scoreTimer = 0.0f;

        GameManager.Instance.NextScene();
    }
}
