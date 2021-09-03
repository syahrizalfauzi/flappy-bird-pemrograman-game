using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerLogic : MonoBehaviour
{
    [SerializeField] string tagName = "Finish";
    public int score = 0;
    public bool isDead = false;

    [SerializeField] float jumpVelocity = 20f;
    [SerializeField] float rotateSpeed = 90f;
    float currentRotation = 0f;
    Rigidbody2D rb;


    [SerializeField] AudioClip flapSound;
    [SerializeField] AudioClip deadSound;
    AudioSource az;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        az = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isDead) return;
        HandleJump(); RotatePlayer();
    }

    void HandleJump()
    {
        if (!Input.GetButtonDown("Fire1") && !Input.GetButtonDown("Jump"))
            return;

        az.clip = flapSound;
        az.Play();

        rb.velocity = Vector2.up * jumpVelocity;
        currentRotation = 15f;
    }

    void RotatePlayer()
    {
        currentRotation -= rotateSpeed * Time.deltaTime;
        currentRotation = Mathf.Clamp(currentRotation, -90f, 15f);

        transform.localEulerAngles = Vector3.forward * currentRotation;
    }

    //Detect kena ground / pipe
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            az.clip = deadSound;
            az.Play();

            Time.timeScale = 0;
            isDead = true;
        }
    }

    //Dipanggil dari pipe kalo udah ngelewatin player
    public void AddScore()
    {
        score++;
    }
}
