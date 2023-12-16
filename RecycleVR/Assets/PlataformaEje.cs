using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaEje : MonoBehaviour
{
   
    public float speed = 5;
    public Vector3 direccion = new Vector3(1f, 1f, 1f);
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += -direccion * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    
    }

}
