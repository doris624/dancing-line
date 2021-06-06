using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endscreen : MonoBehaviour
{
    public GameObject Endscreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Endscreen.gameObject.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
