using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public int velocidade = 5;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        TryGetComponent(out rb);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(x, 0, y);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

