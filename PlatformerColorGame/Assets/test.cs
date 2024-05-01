using System.Collections;
using UnityEngine;

public class test : MonoBehaviour
{
    private float speed = 5f;
    public float jump;

    private bool isJumping;

    public GameObject whiteCharacter;
    public GameObject redCharacter;
    public GameObject blueCharacter;
    public GameObject blackCharacter;

    public GameObject[] whiteGround;
    public GameObject[] redGround;
    public GameObject[] blueGround;
    public GameObject[] blackGround;

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
            if (whiteCharacter.activeSelf)
            {
                redCharacter.transform.position = whiteCharacter.transform.position;
                redCharacter.SetActive(true);
                whiteCharacter.SetActive(false);
            }
            else if(blueCharacter.activeSelf)
            {
                redCharacter.transform.position = blueCharacter.transform.position;
                redCharacter.SetActive(true);
                blueCharacter.SetActive(false);
            }
            else if (blackCharacter.activeSelf)
            {
                redCharacter.transform.position = blackCharacter.transform.position;
                redCharacter.SetActive(true);
                blackCharacter.SetActive(false);
            }


            for (int i = 0; i < whiteGround.Length; i++)
            {
                whiteGround[i].GetComponent<BoxCollider2D>().enabled = true;
            }

            for (int j = 0; j < redGround.Length; j++)
            {
                redGround[j].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int i = 0; i < blackGround.Length; i++)
            {
                blackGround[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int j = 0; j < blueGround.Length; j++)
            {
                blueGround[j].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if (collision.gameObject.CompareTag("White"))
        {
            isStarting = false;
            if (redCharacter.activeSelf)
            {
                whiteCharacter.transform.position = redCharacter.transform.position;
                whiteCharacter.SetActive(true);
                redCharacter.SetActive(false);
            }
            else if (blueCharacter.activeSelf)
            {
                whiteCharacter.transform.position = blueCharacter.transform.position;
                whiteCharacter.SetActive(true);
                blueCharacter.SetActive(false);
            }
            else if (blackCharacter.activeSelf)
            {
                whiteCharacter.transform.position = blackCharacter.transform.position;
                whiteCharacter.SetActive(true);
                blackCharacter.SetActive(false);
            }


            for (int i = 0; i < whiteGround.Length; i++)
            {
                whiteGround[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int j = 0; j < redGround.Length; j++)
            {
                redGround[j].GetComponent<BoxCollider2D>().enabled = true;
            }

            for (int i = 0; i < blackGround.Length; i++)
            {
                blackGround[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int j = 0; j < blueGround.Length; j++)
            {
                blueGround[j].GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        else if (collision.gameObject.CompareTag("Blue"))
        {
            isStarting = false;
            if (redCharacter.activeSelf)
            {
                blueCharacter.transform.position = redCharacter.transform.position;
                blueCharacter.SetActive(true);
                redCharacter.SetActive(false);
            }
            else if (whiteCharacter.activeSelf)
            {
                blueCharacter.transform.position = whiteCharacter.transform.position;
                blueCharacter.SetActive(true);
                whiteCharacter.SetActive(false);
            }
            else if (blackCharacter.activeSelf)
            {
                blueCharacter.transform.position = blackCharacter.transform.position;
                blueCharacter.SetActive(true);
                blackCharacter.SetActive(false);
            }


            for (int i = 0; i < whiteGround.Length; i++)
            {
                whiteGround[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int j = 0; j < redGround.Length; j++)
            {
                redGround[j].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int i = 0; i < blackGround.Length; i++)
            {
                blackGround[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int j = 0; j < blueGround.Length; j++)
            {
                blueGround[j].GetComponent<BoxCollider2D>().enabled = true;
            }
        }

        else if (collision.gameObject.CompareTag("Black"))
        {
            isStarting = false;
            if (redCharacter.activeSelf)
            {
                blackCharacter.transform.position = redCharacter.transform.position;
                blackCharacter.SetActive(true);
                redCharacter.SetActive(false);
            }
            else if (whiteCharacter.activeSelf)
            {
                blackCharacter.transform.position = whiteCharacter.transform.position;
                blackCharacter.SetActive(true);
                whiteCharacter.SetActive(false);
            }
            else if (blueCharacter.activeSelf)
            {
                blackCharacter.transform.position = blueCharacter.transform.position;
                blackCharacter.SetActive(true);
                blueCharacter.SetActive(false);
            }

            for (int i = 0; i < whiteGround.Length; i++)
            {
                whiteGround[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int j = 0; j < redGround.Length; j++)
            {
                redGround[j].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int i = 0; i < blueGround.Length; i++)
            {
                blueGround[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int j = 0; j < blackGround.Length; j++)
            {
                blackGround[j].GetComponent<BoxCollider2D>().enabled = true;
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
