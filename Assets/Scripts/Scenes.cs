using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    [SerializeField] AudioSource Nononon;
    [SerializeField] AudioSource MainTheme;
    [SerializeField] GameObject PanelLevelLocked;

    private int thisScene;

    // Retourner au MainMenu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    // Passer au niveau suivant
    public void NextLevel()
    {
        thisScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisScene + 1);
        SceneManager.UnloadSceneAsync(thisScene);
    }


    #region Levelx_x

    IEnumerator PauseMainTheme()
    {
        MainTheme.Pause();
        Nononon.Play();
        PanelLevelLocked.SetActive(true);
        yield return new WaitForSeconds(3f);
        PanelLevelLocked.SetActive(false);
        Nononon.Stop();
        MainTheme.UnPause();
    }

    // Gestion des niveaux
    public void Level1_1()
    {
        if (PlayerPrefs.GetInt("levelProgression") >= 2)
        {
            SceneManager.LoadScene("Level1_1");
        }
        else
        {
            StartCoroutine(PauseMainTheme());
        }
    }

    public void Level1_2()
    {
        if (PlayerPrefs.GetInt("levelProgression") >= 3)
        {
            SceneManager.LoadScene("Level1_2");
        }
        else
        {
            StartCoroutine(PauseMainTheme());
        }
    }

    public void Level1_3()
    {
        if (PlayerPrefs.GetInt("levelProgression") >= 4)
        {
            SceneManager.LoadScene("Level1_3");
        }
        else
        {
            StartCoroutine(PauseMainTheme());
        }
    }

    public void Level2_1()
    {
        if (PlayerPrefs.GetInt("levelProgression") >= 5)
        {
            SceneManager.LoadScene("Level2_1");
        }
        else
        {
            StartCoroutine(PauseMainTheme());
        }
    }

    public void Level2_2()
    {
        if (PlayerPrefs.GetInt("levelProgression") >= 6)
        {
            SceneManager.LoadScene("Level2_2");
        }
        else
        {
            StartCoroutine(PauseMainTheme());
        }
    }

    public void Level2_3()
    {
        if (PlayerPrefs.GetInt("levelProgression") >= 7)
        {
            SceneManager.LoadScene("Level2_3");
        }
        else
        {
            StartCoroutine(PauseMainTheme());
        }
    }
    #endregion
}
