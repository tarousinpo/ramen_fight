using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip seHit;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            audioSource.PlayOneShot(seHit);
        }
    }
}
