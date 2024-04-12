using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    private bool isChange;


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


    IEnumerator LoadMusic(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        // Find all AudioSources in the scene
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Iterate through each AudioSource and do something (e.g., mute or manipulate)
        foreach (AudioSource audioSource in allAudioSources)
        {
            // Do something with each audioSource (for example, mute it)
            audioSource.mute = true;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (isChange)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
                isChange = false;
            }
            else
            {

                this.gameObject.GetComponent<AudioSource>().Stop();
                isChange = true;
            }
        }
    }


}
