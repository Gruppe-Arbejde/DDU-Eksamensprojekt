using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public GameObject scoreText;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "GameOver")
        {
            scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = $"Score: {DataHandling.totalScore}";
        }
        else
        {
            DataHandling.totalScore = 0;
            scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = $"Score: {DataHandling.totalScore}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreIncrease()
    {
        score += 100;
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = $"Score: {score}";
        DataHandling.totalScore = score;
    }
}
