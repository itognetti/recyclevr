using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador : MonoBehaviour
{
    public int contadorColisiones = 0;
    public string caracteresEspecificos = "Bottle";
    public TextMesh textoPuntaje;

    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.name.Contains(caracteresEspecificos)){
            contadorColisiones++;
            textoPuntaje.text = contadorColisiones.ToString();
            Debug.Log("Colisiones: " + contadorColisiones);

            // Reproduce el sonido de puntuación.
            if (audioSource != null){
                audioSource.Play();
            }
        }
    }
}
