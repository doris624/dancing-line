using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    private gameManager gameManager;
    public int pointValue;

    void Start()
    {
        gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
    }

    void Update()
    {
        transform.Rotate(2, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "player")
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
}
