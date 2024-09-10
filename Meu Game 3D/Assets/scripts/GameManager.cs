using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI hud, msgVitoria;
    public int restantes;
    public AudioClip clipMoeda, clipVitoria;

    private AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out source);
        restantes = FindObjectsOfType<Moeda>().Length;
        
        hud.text = $"kwanazas restantes: {restantes}";
        source.PlayOneShot(clipMoeda);
    }

    public void SubtrairMoedas(int valor)
    {
        restantes -= valor;
        hud.text = $"kwanazas restantes: {restantes}";
        source.PlayOneShot(clipMoeda);

        if (restantes <= 0)
        {
            msgVitoria.text = "És brabo, nengue!";
            source.Stop();
            source.PlayOneShot(clipVitoria);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
