using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighscoreEntry
{
    public string username;
    public int score;

    public HighscoreEntry(string _name, int _score)
    {
        username = _name;
        score = _score;
    }

    public static bool operator ==(HighscoreEntry left, HighscoreEntry right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) { return true; }
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) { return false; }

        return left.username == right.username && left.score == right.score;
    }

    public static bool operator !=(HighscoreEntry left, HighscoreEntry right)
    {
        return !(left == right);
    }

    public override bool Equals(object obj)
    {
        return obj is HighscoreEntry entry &&
            username == entry.username &&
            score == entry.score;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(username, score);
    }
}
