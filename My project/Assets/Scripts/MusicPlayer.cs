using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake(){
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(){
        if(!audioSource.isPlaying){
            audioSource.Play();
        }

    }
}
