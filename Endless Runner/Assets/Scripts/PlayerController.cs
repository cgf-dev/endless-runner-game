using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Variables
    #region
    public float moveSpeed;
    public float jumpForce;

    public bool groundedCheck;
    private LayerMask Platform;

    public bool stoppedMoving;

    private Collider2D myCollider;

    private Rigidbody2D rb;

    public GameManager theGameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    public GameObject powerupParticles;
    public GameObject deathParticles;

    private PauseMenu thePauseMenu;

    #endregion

    void Start()
    {
        thePauseMenu = GameObject.FindObjectOfType<PauseMenu>().GetComponent<PauseMenu>();
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        Platform = LayerMask.GetMask("Platform");
        stoppedMoving = false;
    }


    void Update()
    {
        // Ground check
        groundedCheck = Physics2D.IsTouchingLayers(myCollider, Platform);

        // Jump controls
        if (Input.GetKeyDown(KeyCode.Space) && groundedCheck == true)
        {
            rb.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
            jumpSound.Play();
        }

        // Pause Button
        if (Input.GetKeyDown("escape"))
        {
            thePauseMenu.PauseGame();
        }

        // Check if player is still moving
        if (((rb.transform.InverseTransformDirection(rb.velocity).x < 0.1f && rb.transform.InverseTransformDirection(rb.velocity).x > -0.1f)) &&
            ((rb.transform.InverseTransformDirection(rb.velocity).y < 0.1f && rb.transform.InverseTransformDirection(rb.velocity).y > -0.1f)))
        {
            stoppedMoving = true;
            StartCoroutine(StoppedRestart());
        }
        else
            stoppedMoving = false;

    }

    IEnumerator StoppedRestart()
    {
        // Set timer to see if player is not moving
        // If they are not moving for 2 seconds, the game is restarted
        yield return new WaitForSeconds(2);
        if (stoppedMoving == true)
        {
            //Debug.LogError("STOPPED MOVING");
            deathSound.Play();
            Instantiate(deathParticles, transform.position, Quaternion.Euler(90, 0, 0));
            theGameManager.RestartGame();
        }
    }


    void FixedUpdate()
    {
        // Forwards movement
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        // Die if you hit an obstacle
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log("HIT OBSTACLE");
            deathSound.Play();
            Instantiate(deathParticles, transform.position, Quaternion.Euler(90, 0, 0));
            theGameManager.RestartGame();
        }
    }



}
