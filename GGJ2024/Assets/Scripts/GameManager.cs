using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    int score;
    public int Score
    {
        get { return score; }
        set { score = value; totalScore.text = score.ToString(); }
    }
    public TextMeshProUGUI totalScore;
    public int[] sceneIndices = new int[]{ 0, 1 };
    public int currentIndex = 0;

    private void Awake()
    {
        if(Instance != null) { Destroy(Instance.gameObject); }
        Instance = this;
        DontDestroyOnLoad(gameObject);
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

    public void NextScene()
    {
        currentIndex++; currentIndex %= sceneIndices.Length;        
        SceneManager.LoadScene(sceneIndices[currentIndex]);
    }
    
}
