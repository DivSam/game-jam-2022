using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXPlayer : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] audioClips;
    float minDelay = 1f;
    float range = 1f;
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

            int idx = Random.Range(0, audioClips.Length);
            Debug.Log("Playing audio clip");
            Debug.Log(idx);
            AudioSource.PlayClipAtPoint(audioClips[idx], Vector3.zero);
            yield return new WaitForSeconds(Random.Range(minDelay, minDelay + range));
        }
    }

}
