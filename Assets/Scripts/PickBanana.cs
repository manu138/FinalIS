using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickBanana : MonoBehaviour
{
    public AudioClip bananaSound;

    public Text bananaText;

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(bananaSound, transform.position);
		int score = int.Parse (bananaText.text) + 1;
		bananaText.text = score.ToString();
        Destroy(gameObject);
    }
}