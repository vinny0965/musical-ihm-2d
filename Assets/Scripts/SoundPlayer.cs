using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] sounds; // Array de clips de som
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundsWithInterval()
    {
        StartCoroutine(PlaySounds());
    }

    private System.Collections.IEnumerator PlaySounds()
    {
        foreach (AudioClip sound in sounds)
        {
            audioSource.PlayOneShot(sound);
            yield return new WaitForSeconds(1f);
        }
    }
}
