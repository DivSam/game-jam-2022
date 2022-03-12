using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXPlayer : MonoBehaviour
{
    AudioSource audioSource;
    float minDelay = 2f;
    float range = 10f;
    float pitchChangeMax = 0.2f;
    float volumeChangeMax = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySounds());
    }
    IEnumerator PlaySounds()
    {
        while (true)
        {
            audioSource.pitch = Random.Range(1 - pitchChangeMax, 1 + pitchChangeMax);
            audioSource.volume = Random.Range(0.7f - volumeChangeMax, 0.7f + volumeChangeMax);
            audioSource.panStereo = Random.Range(-0.5f, 0.5f);
            audioSource.Play();
            yield return new WaitForSeconds(Random.Range(minDelay, minDelay + range));
        }
    }

}
