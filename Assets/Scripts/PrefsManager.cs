using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initialisation de tous les parametres joueurs lors du 1er lancement du jeu 
        if (!PlayerPrefs.HasKey("Initialised"))
        {
            ResetProgression();
            ResetScore();
        }

        PlayerPrefs.SetInt("Initialised", 1);
    }

    // Reset the level progression
    public void ResetProgression()
    {
        PlayerPrefs.SetInt("levelProgression", 2); //Scene2 = level 1_1
    }

    // Reset the scores
    public void ResetScore()
    {
        // Reset tous les timers à -1
        for (int i=0; i < 8; i++)
        {
            PlayerPrefs.SetFloat("timerLevel" + i, -1);
        }
    }
}
