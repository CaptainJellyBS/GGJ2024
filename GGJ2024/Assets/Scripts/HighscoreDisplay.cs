using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreDisplay : MonoBehaviour
{
    public GameObject nameInputPanel, highscoresPanel;
    public TextMeshProUGUI scoreValText;
    public TextMeshProUGUI[] names, scores;
    string playerName;

    private void Start()
    {
        scoreValText.text = GameManager.Instance.Score.ToString();
    }

    public void SetPlayerName(string _playerName)
    {
        playerName = _playerName;
    }

    public void SwitchScreens()
    {
        HighscoreEntry entry = new HighscoreEntry(playerName, GameManager.Instance.Score);
        HighscoreData hs = GameManager.Instance.highscoreManager.LoadData();
        hs.AddScore(entry);
        GameManager.Instance.highscoreManager.SaveData(hs);

        nameInputPanel.SetActive(false);
        for (int i = 0; i < names.Length; i++)
        {
            names[i].gameObject.SetActive(i < hs.highscores.Count);
            scores[i].gameObject.SetActive(i < hs.highscores.Count);

            if(i< hs.highscores.Count)
            {                
                names[i].text = hs.highscores[i].username;
                scores[i].text = hs.highscores[i].score.ToString();
            }
        }
        highscoresPanel.SetActive(true);
    }
}
