using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float spawnRate = 0.2f;
    public float timeBetweenWaves = 5.5f;
    public Text waveCountdownText;


    private float countdown = 2f;
    private int waveNumber = 0;

    public void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(spawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        string nextWaveIn = "Next Wave in: ";
        waveCountdownText.text = nextWaveIn + Mathf.Round(countdown).ToString();
    }

    IEnumerator spawnWave()
    { 

        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }

        
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
