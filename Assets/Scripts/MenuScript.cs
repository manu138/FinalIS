using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

   public void Onclick()
    {
        SceneManager.LoadScene(1);
    }

   public void Onclick2()
    {
        SceneManager.LoadScene(2);
    }
   public void Onclick3()
    {
        Application.Quit();
    }
}
