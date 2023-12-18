using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEx : MonoBehaviour
{
    public GameObject[] prefabs; // Array de prefabs a generar
    public Transform plataforma; // De donde salen
    public Vector2 spawnInterval = new Vector2(0.5f, 0.5f); // Intervalo de tiempo entre generaciones
    public float destroyHeight = -2f; // Altura Y a la que se deben destruir los objetos

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

        // Verificar y destruir objetos que han alcanzado la altura Y deseada
        DestroyObjectsBelowHeight();
    }

    private void GenerarPrefab()
    {
        // Selecciona un prefab aleatorio del array
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

        // Genera una posición en la plataforma
        Vector3 spawnPosition = plataforma.position;

        if (prefab.name == "trashbag1")
        {
            prefab.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }

        if (prefab.name == "trashbag2")
        {
            prefab.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
        
        // Instancia el prefab en la posición generada
        Instantiate(prefab, spawnPosition, prefab.transform.rotation);
        
        // Restaura la rotación a la identidad para evitar que afecte a futuras instancias
        prefab.transform.rotation = Quaternion.identity;
    }

    private void DestroyObjectsBelowHeight()
    {
        // Obtener todos los objetos con el componente Destroyable
        Destroyable[] destroyableObjects = FindObjectsOfType<Destroyable>();

        foreach (Destroyable destroyableObject in destroyableObjects)
        {
            // Verificar si el objeto está por debajo de la altura Y deseada
            if (destroyableObject.transform.position.y <= destroyHeight)
            {
                // Destruir el objeto
                Destroy(destroyableObject.gameObject);
            }
        }
    }
}
