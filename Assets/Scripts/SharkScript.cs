using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SharkScript : MonoBehaviour
{

    public float leftBoundary = -10f;
    public float rightBoundary = 10f;
    public float bottomBoundary = -5f;
    public float upBoundary = 5f;

    public int moveSpeed = 3;

    SpriteRenderer myRend;

    public Dialogue dialogue;

    public GameObject conversationBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public bool Line1;
    public bool Line2;
    public bool Line3;
    public bool Line4;
    public bool Line5;
    public bool Line6;
    public bool Line7;

    public bool shortScream = false;

    public bool conversationOn = false;
    public bool conversationOver = false;
    public float conversationCountDown = 5f;
    public GameObject boy;
    public GameObject Exit;

    public Sprite stateConfused;
    public Sprite stateOpenMouth;
    public Sprite stateBlood;

    private CameraShake myCameraShake;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<SpriteRenderer>();
        myCameraShake = GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        //Fixing Posistion
        if(transform.position.x <= leftBoundary)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if(transform.position.x >= rightBoundary)
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }

        if(transform.position.y <= bottomBoundary)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        else if (transform.position.y >= upBoundary)
        {
            transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0); ;
        }

        //Player movement
        if (!conversationOn)
        {
            if (transform.position.x >= leftBoundary && transform.position.x <= rightBoundary)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                    myRend.flipX = false;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                    myRend.flipX = true;
                }
            }

            if (transform.position.y >= bottomBoundary && transform.position.y <= upBoundary)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
                    myRend.flipY = false;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
                    myRend.flipY = true;
                }
            }
        }

        if (shortScream)
        {
            myCameraShake.Shake(0.1f);
            shortScream = false;
        }

        //Dialogue
        if (conversationOn && !conversationOver)
        {
            myRend.flipY = false;

            if (Line1)
            {
                nameText.text = "Boy";
                dialogueText.text = "*Scream";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Line1 = false;
                }
            }
            else if (Line2)
            {
                nameText.text = "Sharkenstein";
                dialogueText.text = "Child, what is the meaning of this? I do not intend to hurt you; listen to me.";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Line2 = false;
                }
            }
            else if (Line3)
            {
                nameText.text = "Boy";
                dialogueText.text = "Let me go, monster! Ugly wretch! You wish to eat me and tear me to pieces. You are an ogre. Let me go, or I will tell my papa.";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Line3 = false;
                }
            }
            else if (Line4)
            {
                nameText.text = "Sharkenstein";
                dialogueText.text = "Boy, you will never see your father again; you must come with me.";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Line4 = false;
                }
            }
            else if (Line5)
            {
                nameText.text = "Boy";
                dialogueText.text = "Hideous monster! Let me go. My papa is a syndic—he is M. Sharkenstein—he will punish you. You dare not keep me.";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Line5 = false;
                }
            }
            else if (Line6)
            {
                nameText.text = "Sharkenstein";
                dialogueText.text = "Sharkenstein! you belong then to my enemy—to him towards whom I have sworn eternal revenge; you shall be my first victim.";

                myRend.sprite = stateOpenMouth;
                myCameraShake.Shake(0.1f);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Line6 = false;
                }
            }
            else if (Line7)
            {
                nameText.text = "Boy";
                dialogueText.text = "*Scream out cursing epithets";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    conversationBox.SetActive(false);
                    boy.GetComponent<BoyScript>().conversationOn = false;
                    conversationOver = true;
                    Line7 = false;
                    conversationOn = false;
                }
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (!Line7)
        {
            //myCameraShake.Shake(0.1f);
            Destroy(collision.gameObject);
            myRend.flipY = false;
            myRend.sprite = stateBlood;
            Exit.SetActive(true);
        }
        else if (collision.gameObject.name == "Boy")
        {
            conversationBox.SetActive(true);
            collision.gameObject.GetComponent<BoyScript>().conversationOn = true;
            conversationOn = true;
            myRend.sprite = stateConfused;
            //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        if (collision.gameObject.name == "Exit")
        {
            SceneManager.LoadScene(0);
        }
    }

}
