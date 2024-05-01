using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    public float jump;

    private bool isJumping;

    public GameObject whiteCharacter;
    public GameObject redCharacter;

    public GameObject[] whiteGround;
    public GameObject[] redGround;

    private Rigidbody2D rb;

    public Animator animator;

    public float scaleX;
    public float scaleY;

    public bool isStarting;


    private void Start()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;

        StartCoroutine(WaitSeconds());

        for (int i = 0; i < whiteGround.Length; i++)
        {
            whiteGround[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        for (int j = 0; j < redGround.Length; j++)
        {
            redGround[j].GetComponent<BoxCollider2D>().enabled = true;
        }
        whiteCharacter.SetActive(true);
        redCharacter.SetActive(false);
        rb = GetComponent<Rigidbody2D>();

        if (whiteCharacter.activeSelf)
        {
            for (int i = 0; i < whiteGround.Length; i++)
            {
                whiteGround[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int j = 0; j < redGround.Length; j++)
            {
                redGround[j].GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < whiteGround.Length; i++)
            {
                whiteGround[i].GetComponent<BoxCollider2D>().enabled = true;
            }

            for (int j = 0; j < redGround.Length; j++)
            {
                redGround[j].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(2f);
        isStarting = false;
    }

    private void Update()
    {
        if (!isStarting)
        {
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 move = new Vector3(horizontal, 0, 0);
            transform.Translate(move * speed * Time.deltaTime);

            animator.SetFloat("Speed", Mathf.Abs(horizontal));

            FlipCharacter(horizontal);

            if (Input.GetButtonDown("Jump") && isJumping == false)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jump));
            }
        }
        
        
    }

    public void FlipCharacter(float horizontal)
    {
        if (horizontal > 0 && scaleX < 0)
        {
            scaleX = Mathf.Abs(scaleX);
            transform.localScale = new Vector2(scaleX, scaleY);
        }

        else if (horizontal < 0 && scaleX > 0)
        {
            scaleX = -Mathf.Abs(scaleX);
            transform.localScale = new Vector2(scaleX, scaleY);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Red"))
        {
            isStarting = false;
            redCharacter.transform.position = whiteCharacter.transform.position;
            redCharacter.SetActive(true);
            whiteCharacter.SetActive(false);

            for (int i = 0; i < whiteGround.Length; i++)
            {
                whiteGround[i].GetComponent<BoxCollider2D>().enabled = true;
            }

            for (int j = 0; j < redGround.Length; j++)
            {
                redGround[j].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if (collision.gameObject.CompareTag("White"))
        {
            isStarting = false;
            whiteCharacter.transform.position = redCharacter.transform.position;
            redCharacter.SetActive(false);
            whiteCharacter.SetActive(true);


            for (int i = 0; i < whiteGround.Length; i++)
            {
                whiteGround[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int j = 0; j < redGround.Length; j++)
            {
                redGround[j].GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WhiteGround") || collision.gameObject.CompareTag("RedGround"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WhiteGround") || collision.gameObject.CompareTag("RedGround"))
        {
            isJumping = true;
        }
    }
}
