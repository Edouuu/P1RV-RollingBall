using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cligonter : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Material PlayerText;
    [SerializeField] Material LevelText;
    [SerializeField] Material InvisibleText;

    private Color m_playerColor;
    private Color m_levelColor;

    private float _aPlayer;
    private float _aLevel;
    private bool _echange = false;

    private bool _playerVisible = true; // true = player visible; false = level visible

    private void Start()
    {
        m_playerColor = Player.GetComponent<Renderer>().material.color;
        m_levelColor = this.gameObject.GetComponent<Renderer>().material.color;
    }

    IEnumerator Clignoter()
    {
        var m_playerRenderer = Player.GetComponent<Renderer>();
        var m_levelRenderer = this.gameObject.GetComponent<Renderer>();
        _echange = true;

        // On fait clignoter le player et le level
        for (int i = 0; i < 3; i++)
        {
            m_playerColor.a = 0.5f;
            m_levelColor.a = 0.25f;
            m_playerRenderer.material.SetColor("_Color", m_playerColor);
            m_levelRenderer.material.SetColor("_Color", m_levelColor);
            yield return new WaitForSeconds(0.3f);

            m_playerColor.a = 1.0f;
            m_levelColor.a = 0.5f;
            m_playerRenderer.material.SetColor("_Color", m_playerColor);
            m_levelRenderer.material.SetColor("_Color", m_levelColor);
            yield return new WaitForSeconds(0.3f);
        }

        _playerVisible = !_playerVisible; // vaut 1 si visible=0 et 0 si visible=1
        // Et on donne leur texture finale
        switch (_playerVisible) 
        { 
            case true:
                m_playerRenderer.material = PlayerText;
                m_levelRenderer.material = InvisibleText;
                break;
            case false:
                m_playerRenderer.material = InvisibleText;
                m_levelRenderer.material = LevelText;
                break;
        }

        yield return new WaitForSeconds(1f);
        _echange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Collision.hasFallen == false && !_echange && !Collision.clignote && Input.touchCount > 0)
        {
            StartCoroutine(Clignoter());
        }
    }
}