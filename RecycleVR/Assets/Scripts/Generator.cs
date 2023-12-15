using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] prefabs; // Array de prefabs a generar
    public Transform plataforma; // De donde salen
    public Vector2 spawnInterval = new Vector2(0.5f, 0.5f); // Intervalo de tiempo entre generaciones

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + Random.Range(spawnInterval.x, spawnInterval.y);
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            GenerarPrefab();
            nextSpawnTime = Time.time + Random.Range(spawnInterval.x, spawnInterval.y);
        }
    }

    private void GenerarPrefab()
    {
        // Selecciona un prefab aleatorio del array
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

        // Genera una posición aleatoria dentro de la plataforma
        Vector3 spawnPosition = plataforma.position + new Vector3(Random.Range(-0.3f, 0.3f), 0.3f, 0.3f);

        // Instancia el prefab en la posición generada
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
