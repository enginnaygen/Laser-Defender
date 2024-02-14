using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfs;
    [SerializeField] float delay = 2f;
    WaveConfigSO _currentWave;
    [SerializeField] bool isLooping;

    void Start()
    {
        SpawnEnemies();
    }

    public WaveConfigSO GetCurrentWave() //PathFindere buradaki WaveConfigSO'yu vermek icin olusturduk bu methodu
    {
        return _currentWave;
    }

    private void SpawnEnemies()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        do //en az bir kere calisacak
        {
            foreach (WaveConfigSO wave in waveConfs) //burada foreach loop kafami karistirdi??
            {
                _currentWave = wave;

                for (int index = 0; index < _currentWave.GetEnemyCount(); index++)
                {
                    Instantiate(_currentWave.GetEnemyPrefab(index),
                                _currentWave.GetStartingPoint().position,
                                Quaternion.identity, this.transform);
                    yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(delay);

            }
        }
        while (isLooping);

        
        /*for (int i = 0; i < waveConfs.Count; i++) 
        {
            _currentWave= waveConfs[i];

            for (int index = 0; index < _currentWave.GetEnemyCount(); index++)
            {
                Instantiate(_currentWave.GetEnemyPrefab(index),
                            _currentWave.GetStartingPoint().position,
                            Quaternion.identity, this.transform);
                yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
            }
        }*/

    }
}
