using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner _enemySpawner;
    WaveConfigSO _waveConf;
    List<Transform> _wayPoints;
    int _wayPointIndex = 0;

    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void Start()
    {
        _waveConf = _enemySpawner.GetCurrentWave(); //WaveConfigSO'nun referansini EnemySpawner'dan atýyoruz ve o atanan referansý
        _wayPoints = _waveConf.GetWayPoints();      //buradaki referansa veriyoruz
        transform.position = _wayPoints[_wayPointIndex].position;
    }

    private void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(_wayPointIndex < _wayPoints.Count)
        {
            Vector3 targetPos = _wayPoints[_wayPointIndex].position;
            float delta = _waveConf.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos,delta);

            if(transform.position==targetPos)
            {
                _wayPointIndex++;
            }

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
