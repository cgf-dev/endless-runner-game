using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    // Variables
    public int scoreToGive;

    private ScoreManager theScoreManager;

    private AudioSource collectibleSound;

    public GameObject collectibleParticles;

    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        collectibleSound = GameObject.Find("Collectible_Sound").GetComponent<AudioSource>();
    }


    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theScoreManager.AddScore(scoreToGive);
            Instantiate(collectibleParticles, transform.position, Quaternion.Euler(90, 0, 0));
            Debug.Log("played");
            gameObject.SetActive(false);

            if (collectibleSound.isPlaying)
            {
                collectibleSound.Stop();
                collectibleSound.Play();
            }
            else
            {
                collectibleSound.Play();
            }
        }
    }
}
