using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Variables Canvas.
    public GameObject PantallaGanar;
    public GameObject PantallaPerder;
    int vidas;
    public GameObject[] vidasUI;
    private int estrellas;
    public Text estrellasText;

    void Awake()
    {
        // if la instancia de este script no es igual a nulo, y la instancia no es esta (refiriendose al primer script game manager) me mato
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
        PantallaGanar.SetActive(false);
        PantallaPerder.SetActive(false);
        vidas = 3;
        
    }

    public void ContadorVida()
    {
        vidas --;
        if(vidas == 0)
        {
            PantallaPerder.SetActive(true);
            PlayerMovement.Instance.Destroy();
        }
        
        foreach(GameObject vida in vidasUI)
        {
            if(vida.activeInHierarchy)
            {
                vida.SetActive(false);
                return;
            }
        }
    } 

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Estrella()
    {
        AudioManager.Instance.SonidoRecoger();
        estrellas++;
        estrellasText.text = "x " + estrellas;
        if(estrellas == 3)
        {
            PantallaGanar.SetActive(true);
            PlayerMovement.Instance.Destroy();
        }
    }

}
