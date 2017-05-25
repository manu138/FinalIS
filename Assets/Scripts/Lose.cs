using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour
{
    void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
        Invoke("Reload", 1.59f);
    }

    void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
