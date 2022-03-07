using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip otherClip;

    /*Music: 
     * Vidya Vidya - Safari Fruits [NCS Release] - YouTube link: https://www.youtube.com/watch?v=PbIjuqd4ENY&list=PLRBp0Fe2GpgnZOm5rCopMAOYhZCPoUyO5&index=3&ab_channel=NoCopyrightSounds
     * Desembra - Hit 'Em [NCS Release] - YouTube link: https://www.youtube.com/watch?v=paGOde3BO1Q&list=PLRBp0Fe2GpgnZOm5rCopMAOYhZCPoUyO5&index=10&ab_channel=NoCopyrightSounds
     */

    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = otherClip;
        audio.Play();
    }
}
