using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown(3));
    }

    // Update is called once per frame
    IEnumerator Countdown(int countdownTime)
    {
        while (countdownTime>0)
        {
                countdownText.text = countdownTime.ToString();

                yield return new WaitForSeconds(1f);

                countdownTime--;
        }
        countdownText.enabled = false;

        GameObject.FindWithTag("Player").AddComponent<Rigidbody2D>();
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 7;
        GameObject.FindWithTag("Player").GetComponent<PlayerLogic>().enabled = true;
        GameObject.FindWithTag("Spawner").GetComponent<PipeSpawner>().enabled = true;
    }
}
