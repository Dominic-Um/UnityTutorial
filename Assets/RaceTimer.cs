using UnityEngine;
using TMPro;

public class RaceTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;


        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}