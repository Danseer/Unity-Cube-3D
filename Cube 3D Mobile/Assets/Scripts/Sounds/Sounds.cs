using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource=GetComponent<AudioSource>();
        Collisions.CollisionSound.AddListener(PlayCubeColl);

    }

    private void PlayCubeColl()
    {
        _audioSource.Play();
    }

}



