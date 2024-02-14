using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip laserSFX, damageSFX;
    [SerializeField][Range(0f, 1f)] float audioVolume;

    private void Awake()
    {
        ManageSingelton();
    }
    void ManageSingelton()
    {
        int instance = FindObjectsOfType(GetType()).Length;
        if(instance>1)
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void PlayShooting()
    {
        if(laserSFX != null)
        {
            AudioSource.PlayClipAtPoint(laserSFX, Camera.main.transform.position,audioVolume);
        }
    }

    public void PlayDamage()
    {
        AudioSource.PlayClipAtPoint(damageSFX, Camera.main.transform.position, audioVolume);
    }
}
