using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Wave Config", menuName ="Wawe Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] float moveSpeed = 5f;

    public int GetEnemyCount() 
    {
        return enemyPrefab.Count;
    }

    public GameObject GetEnemyPrefab(int index) //listedeki belli bir prefab dusmanini getirmeye yariyor
    {
        return enemyPrefab[index];
    }

    public Transform GetStartingPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();

        foreach(Transform child in pathPrefab) //pathPrefab koleksiyon yapisi degil, otomatik olarak childlarina mi bakiyor??
        {
            wayPoints.Add(child); //wayPointsin içine disardan referans verdigimiz pathPrefabin childlarini veriyoruz
        }
        return wayPoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(0.5f, 1f);
        return spawnTime;
    }
}
