using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public Player player;

    public GameObject panel;

    public ParticleSystem whiteConfetti;
    public ParticleSystem redConfetti;

    private void Start()
    {
        whiteConfetti.Stop();
        redConfetti.Stop();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            if (player.whiteCharacter.activeSelf)
            {
                whiteConfetti.Play();
                StartCoroutine(NextLevel());
            }
            else if (player.redCharacter.activeSelf)
            {
                redConfetti.Play();
                StartCoroutine(NextLevel());
            }

        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2f);
        panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SampleScene");
    }
}
