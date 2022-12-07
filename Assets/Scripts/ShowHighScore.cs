using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowHighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CeText;

    private float _level;
    private float _highscore;
    void Update()
    {
        // Recupere le numero du niveau et le highscore correspondant
        _level = this.gameObject.name.ToIntArray()[0] - 47f;
        _highscore = PlayerPrefs.GetFloat("timerLevel" + _level.ToString());
        print(_level.ToString());
        print(_highscore.ToString());
        // On change le text
        if (_highscore > 0)
        {
            this.CeText.text = "Level " + (float) ((_level+1) % 3 + 1) + " :        " + _highscore;
        }
        else
        {
            this.CeText.text = "Level " + (float) ((_level + 1) % 3 + 1) + " :        " + "--,--";

        }
    }
}
