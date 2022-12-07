using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PauseEtChrono : MonoBehaviour
{
    [SerializeField] GameObject MenuPause;
    [SerializeField] TextMeshProUGUI ChronoText;
    private bool isPaused;
    private float temps;
    private float tempsRestart;
    public static float temps2f = 0;

    private void Start()
    {
        temps = 0f;
    }

    private void Pause()
    {
        // On met le jeu en pause
        isPaused = true;
        this.GetComponent<FollowGyro>().enabled = false;
        Time.timeScale = 0f;
        // Affiche le menu pause
        MenuPause.SetActive(true);
    }

    void Update()
    {
        // Pause
        if (Input.touchCount == 2)
        {
            Pause();
        }

        // Chrono
        if (!isPaused)
        {
            temps += Time.deltaTime;
        }

        // Restart
        if (Input.touchCount == 1 && !isPaused)
        {
            tempsRestart += Time.deltaTime;
            if (tempsRestart > 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            tempsRestart = 0f;
        }

        AfficheTemps(); 
    }

    public void ResumeGame()
    {
        isPaused = false;
        MenuPause.SetActive(false);
        this.GetComponent<FollowGyro>().enabled = true;
        Time.timeScale = 1f;
    }

    private void AfficheTemps()
    {
        temps2f = (int) (temps * 100);
        temps2f = (float)temps2f / 100;
        ChronoText.text = "" + temps2f;
    }
}
