using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem explosionEffect;

    [SerializeField] bool applyCameraShake, enemy;
    CameraShake _cameraShake;

    AudioPlayer _audioPlayer;
    ScoreKeeper _scoreKeeper;
    LevelManager _levelManager;

    private void Awake()
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damage = collision.GetComponent<DamageDealer>();
        if(damage!=null)
        {
            TakeDamage(damage.GetDamageValue());
            PlayHitEffect();
            ShakeCamera();
            _audioPlayer.PlayDamage();
            damage.Hit();
          
            

        }
    }

  

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            /*if(enemy)
            {
                _scoreKeeper.IncreaseScore();
            }
            if(!enemy)
            {
                _scoreKeeper.ResetScore();
            }*/
            if(enemy)
            {
                _scoreKeeper.IncreaseScore(score);
            }
            if(!enemy)
            {
                _levelManager.LoadGameOverMenu();//burada coroutine calisiyor ama demek ki coroutineler gamobjecctten bagimsiz 
            }                                    //calisiyor biraz, cunku bu obje yok oluyor   
            Destroy(gameObject);
        }
    }

    void PlayHitEffect()
    {
        if(explosionEffect !=null) //nul exception almamak icin galiba
        {
            ParticleSystem instance = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration+instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(applyCameraShake && _cameraShake !=null)
        {
            _cameraShake.Play();
        }
    }

    public int GetHealth()
    {
        return health;
    }

 
}

