using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject startPanel;

    private void Start()
    {
        startPanel.SetActive(true);
        StartCoroutine(StartPanel());
    }


    IEnumerator StartPanel()
    {
        yield return new WaitForSeconds(2f);
        startPanel.SetActive(false);
    }
}
