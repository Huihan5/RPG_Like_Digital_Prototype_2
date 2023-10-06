using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public float timeCountDown = 1.5f;

    public bool gameIsOn = false;

    public AudioSource mySource;
    public AudioClip effectSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameIsOn = true;
            mySource.PlayOneShot(effectSound);
            
        }

        if (gameIsOn)
        {
            timeCountDown--;
        }

        if(timeCountDown <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
