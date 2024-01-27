using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighscoreData
{
    public List<HighscoreEntry> highscores;

    public HighscoreData()
    {
        highscores = new List<HighscoreEntry>();
    }

    public void AddScore(HighscoreEntry entry)
    {
        for (int i = highscores.Count-1; i>0; i++)
        {
            highscores.Add(entry);
            if (highscores[i].score > highscores[i - 1].score) { Utility.Swap(ref highscores, i - 1, i); }
        }

        while(highscores.Count > 10)
        {
            highscores.RemoveAt(10);
        }
    }
}
