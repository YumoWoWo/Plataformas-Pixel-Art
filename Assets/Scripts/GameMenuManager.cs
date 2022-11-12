using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMenuManager : MonoBehaviour
{
   public GameObject title;
   public GameObject mainButtons;
   public GameObject optionsMenu;

   public string nivel1;

   public void OpenOptions()
   {
        // hi
        title.SetActive(false);
        mainButtons.SetActive(false);
        optionsMenu.SetActive(true);
   }

   public void PlayButton()
   {
        SceneManager.LoadScene(nivel1);
   }


}
