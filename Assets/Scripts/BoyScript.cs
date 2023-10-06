using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyScript : MonoBehaviour
{
    bool turnLeft = false;
    bool turnRight = true;

    public int moveSpeed = 3;

    [SerializeField]
    public bool conversationOn = false;

    SpriteRenderer myRend;

    public Sprite shockedFace;

    public AudioSource mySource;
    //public AudioClip walkingSound;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -8)
        {
            turnLeft = false;
            turnRight = true;
        }
        else if (transform.position.x >= 8)
        {
            turnRight = false;
            turnLeft = true;
        }

        if (!conversationOn)
        {
            if (turnLeft)
            {
                transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                myRend.flipX = true;
            }
            else if (turnRight)
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                myRend.flipX = false;
            }
        }

        if (conversationOn)
        {
            mySource.Stop();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myRend.sprite = shockedFace;
    }
}
