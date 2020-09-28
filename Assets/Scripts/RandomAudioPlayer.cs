using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
   private GameObject[] audioObjects;
   public float span = 0.25f;
   private float currentTime = 0f;

    private void Start ()
    {
        audioObjects = GameObject.FindGameObjectsWithTag ( "AudioObject" );
    }

    private void Update ()
    {
        currentTime += Time.deltaTime;

        if(currentTime > span){
            var audioObject = audioObjects[Random.Range(0, audioObjects.Length)];

            audioObject.GetComponent<AudioSource> ().Play ();

            currentTime = 0f;
        }

    }
}
