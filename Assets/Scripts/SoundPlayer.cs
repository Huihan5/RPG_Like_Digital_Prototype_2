using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public bool inConversation = false;

    public bool mute = false;

    public AudioSource mySource;

    public AudioClip BGM;

    // Start is called before the first frame update
    void Start()
    {
        mySource = GetComponent<AudioSource>();
        mySource.PlayOneShot(BGM);
    }

    // Update is called once per frame
    void Update()
    {
        if (inConversation)
        {
            if (!mute)
            {
                mySource.mute = !mySource.mute;
                inConversation = false;
                mute = true;
            }
        }
    }
}
