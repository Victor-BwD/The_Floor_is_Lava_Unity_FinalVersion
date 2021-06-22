using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CountdownController : MonoBehaviour
{
    public int countdownTime;

    public Text countdownDisplay;

    bool gameHasEnded = false;

    public float restartDelay = 1f;

   

    private void Start()
    {
        StartCoroutine(CountdownToStart());
      
        
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime >= 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        
    }

    public void EndGame()
    {
        if(countdownTime <= 0)
        {
            if (gameHasEnded == false)
            {
                gameHasEnded = true;
                Debug.Log("Game Over");
                Invoke("Restart", restartDelay);

            }
        }

        
    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        EndGame();
    }

}
