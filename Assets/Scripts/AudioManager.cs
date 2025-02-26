using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Sound Effects")]
    public AudioClip coinPickupSound;
    public AudioClip shootingSound;
    public AudioClip hurtSound;
    public AudioClip jumpSound;
    public AudioClip victorySound;

    [Header("Volume Controls")]
    [Range(0f, 1f)] public float coinPickupVolume ;   
    [Range(0f, 1f)] public float shootingVolume ;      
    [Range(0f, 1f)] public float hurtVolume ;          
    [Range(0f, 1f)] public float jumpVolume ;          
    [Range(0f, 1f)] public float victoryVolume ;       

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Método para reproducir el sonido de la moneda
    public void PlayCoinPickupSound()
    {
        audioSource.PlayOneShot(coinPickupSound, coinPickupVolume);
    }

    // Método para reproducir el sonido de disparo
    public void PlayShootingSound()
    {
        audioSource.PlayOneShot(shootingSound, shootingVolume);
    }

    // Método para reproducir el sonido de herido
    public void PlayHurtSound()
    {
        audioSource.PlayOneShot(hurtSound, hurtVolume);
    }

    // Método para reproducir el sonido de salto
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound, jumpVolume);
    }

    // Método para reproducir el sonido de victoria
    public void PlayVictorySound()
    {
        audioSource.PlayOneShot(victorySound, victoryVolume);
    }
}
