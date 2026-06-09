using System.Numerics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{

    [SerializeField]
    int Speed = 7;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int JumpForce = 10;
    [SerializeField]
    Animator anim;
    Rigidbody2D rb;
    KeyCode LastMove;

    [SerializeField]
    private AudioClip jumpSound;

    [SerializeField]
    private AudioClip death;

    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(UnityEngine.Vector2.up * JumpForce, ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }
    }

    

    void ResetAnimations()
    {
        anim.SetBool("isRight", false);
        anim.SetBool("IsLeft", false);
        anim.SetBool("IsUp", false);
        anim.SetBool("IsDown", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            audioSource.PlayOneShot(death);
            SceneManager.LoadScene("Main Menu");

        }
    }

}
