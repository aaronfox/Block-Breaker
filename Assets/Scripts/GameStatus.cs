using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// GameStatus uses the Singleton Pattern in the Awake function
// Therefor it uses the same GameStatus for every level

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1.0f;

    [SerializeField] int gameScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    public void IncrementScore() {
        gameScore += pointsPerBlockDestroyed;
        scoreText.text = gameScore.ToString();
    }

    // Singleton
    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = gameScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    // Call this method to reset the game
    public void DestroyGameStatus() {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled() {
        return isAutoPlayEnabled;
    }
}
