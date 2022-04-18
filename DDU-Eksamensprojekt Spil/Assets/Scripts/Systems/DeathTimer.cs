using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTimer : MonoBehaviour
{
    public GameObject timerText;
    public float time; 

    // Start is called before the first frame update
    void Start()
    {
        time = 35; //start value of countdown
        Invoke("Timer", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (time == -1)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Timer()
    {
        timerText.GetComponent<TMPro.TextMeshProUGUI>().text = $"Time remaining: {time}";
        time--;
        Invoke("Timer", 1);
    }
}
