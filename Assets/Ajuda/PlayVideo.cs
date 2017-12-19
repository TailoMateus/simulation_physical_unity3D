using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]

public class PlayVideo : MonoBehaviour {
		
       public MovieTexture video;
       public AudioSource audio;
 
       void Start () {
            GetComponent<RawImage>().texture = video as MovieTexture;
             audio = GetComponent<AudioSource>();
             audio.clip = video.audioClip;
             video.Play();
             audio.Play();
       }

       void Update () {
             if(Input.GetKey(KeyCode.Space) && video.isPlaying){
                   video.Pause();
             }
             if(Input.GetKey(KeyCode.Space) && !video.isPlaying){
                   video.Play();
             }
       }
}