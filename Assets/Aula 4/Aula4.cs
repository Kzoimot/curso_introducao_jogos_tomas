using Unity.VisualScripting;
using UnityEngine;

public class Aula4 : MonoBehaviour
{

    [SerializeField]
    int Speed = 7;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField]
    Animator anim;

    KeyCode LastMove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        ResetAnimations();

        if (Input.GetKey(KeyCode.D) && (LastMove == KeyCode.None || LastMove == KeyCode.D))
        {
            LastMove = KeyCode.D;
            transform.position += Vector3.right * Time.deltaTime * Speed;
            anim.SetBool("isRight", true);
        }

        else if (Input.GetKey(KeyCode.A) && (LastMove == KeyCode.None || LastMove == KeyCode.A))
        {
            LastMove = KeyCode.A;
            transform.position += Vector3.left * Time.deltaTime * Speed;
            anim.SetBool("IsLeft", true);
        }

        else if (Input.GetKey(KeyCode.S) && (LastMove == KeyCode.None || LastMove == KeyCode.S))
        {
            LastMove = KeyCode.S;
            transform.position += Vector3.down * Time.deltaTime * Speed;
            anim.SetBool("IsDown", true);
        }

        else if (Input.GetKey(KeyCode.W) && (LastMove == KeyCode.None || LastMove == KeyCode.W))
        {
            LastMove = KeyCode.W;
            transform.position += Vector3.up * Time.deltaTime * Speed;
            anim.SetBool("IsUp", true);
        }
        else
        {
            LastMove = KeyCode.None;
        }
    }

    void ResetAnimations()
    {
        anim.SetBool("isRight", false);
        anim.SetBool("IsLeft", false);
        anim.SetBool("IsUp", false);
        anim.SetBool("IsDown", false);
    }
}
