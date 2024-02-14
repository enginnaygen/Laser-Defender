using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Values")]   
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime=2f;
    [SerializeField] float firingRate = 0.2f;
    [Header("Boolen")]
    [SerializeField] bool  useIA;
    [Header("Bullet")]
    [SerializeField] GameObject projectilePrefab;


    [HideInInspector] public bool isFiring;

    Coroutine _firingCourotine;

    AudioPlayer _audioPlayer;

    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }


    private void Start()
    {
        if(useIA)  
        {
            isFiring = true; //bu sekilde surekli ates ediyor oluyor
            projectileSpeed *= -1;
            RandomSpawnTime(); 
        }
    }
    private void Update()
    {
        Fire();       
    }
    float RandomSpawnTime()
    {
        firingRate = Random.Range(0.5f, 2f);
        return firingRate;
        
    }
    void Fire()
    {
        if(isFiring && _firingCourotine==null) //Fire tusuna basili tutulursa yeni corotindeler olusturmayacak cunku
        {                                      //_firingCoroutine null olmayacak 
           
            _firingCourotine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && _firingCourotine != null)
        {
            StopCoroutine(_firingCourotine);
            _firingCourotine = null;
        }
    }

    IEnumerator FireContinuously()
    {
       while(true) //bu döngü basýlý tutulursa ateslensin diye var
        {
           

            GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.up * projectileSpeed;
            Destroy(bullet, projectileLifeTime);
            _audioPlayer.PlayShooting();
            yield return new WaitForSeconds(firingRate); //basili tuttugumuz surece ates edilecek, basili tutarken bu kursunlarin ust uste binmemesi icin ne kadar sure beklemesi gerektigi
        }



    }
}
