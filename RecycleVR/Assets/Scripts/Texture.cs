using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture : MonoBehaviour
{
    public float velocidadX = 0.1f; // Velocidad de desplazamiento horizontal de la textura.
    public float velocidadY = 0.0f; // Velocidad de desplazamiento vertical de la textura.

    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        float offsetHorizontal = Time.time * velocidadX;
        float offsetVertical = Time.time * velocidadY;

        rend.material.mainTextureOffset = new Vector2(offsetHorizontal, offsetVertical);
    }
}
