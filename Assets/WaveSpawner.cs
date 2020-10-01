using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    //Cantidad de enemigos que apareceran por ronda
    private int waveNumber = 0;

    //Tiempo que tarda en aparecer los primeros enemigos
    public float countdown = 2f;

    public Text waveCountdownText;

    void Update()
    {
        if (countdown <=0f)
        {
            //Las corutinas se llaman de esta manera
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        //Reduce el contador por uno cada vez que se ejecuta un frame
        countdown -= Time.deltaTime;

        waveCountdownText.text = Math.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        Debug.Log("Se aproxima una oleada");

        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }

        
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
