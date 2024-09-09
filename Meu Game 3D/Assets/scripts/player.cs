using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public int velocidade = 5;
    public Rigidbody rb;
    public int forcaPulo = 10;
    public bool noChao = false;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        TryGetComponent(out rb);
        TryGetComponent(out source);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chão") 
        {
            noChao = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(x, 0, y);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            //pulo
            source.Play();
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
        
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

