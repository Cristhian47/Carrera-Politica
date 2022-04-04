using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class MapController : MonoBehaviour
{
    private bool moviendo = false;
    private int indiceSiguiente;
    private bool asignandoPosicion = false;
    private Vector3 posicionAMover;

    private Vector3 posicionAnterior;

    private float distancia;

    public GameObject personaje;
    public List<Transform> recorrido;
    public int indiceActual;
    public int mapaActual;
    public Button botonJugar;
    public Button botonSiguiente;
    public Button botonAtras;
    public Button botonCerrar;
    public List<UnityEvent> eventosMundosACargar = new List<UnityEvent>();


    public void OnEnable()
    {

        RealizarRecorrido(indiceActual);
        if (mapaActual == 1)
        {
            AsignarEventoJugarPVZMundo1();
        }else if(mapaActual == 2)
        {
            AsignarEventoJugarPVZMundo2();
        }
        else if (mapaActual == 3)
        {
            AsignarEventoJugarPVZMundo3();
        }
        else if (mapaActual == 4)
        {
            AsignarEventoJugarPVZMundo4();
        }
    }

    public void ActivarBotones()
    {
        botonJugar.interactable = true;
        botonSiguiente.interactable = true;
        botonAtras.interactable = true;
        botonCerrar.interactable = true;
    }

    public void DesactivarBotones()
    {
        botonJugar.interactable = false;
        botonSiguiente.interactable = false;
        botonAtras.interactable = false;
        botonCerrar.interactable = false;
    }

    public void RealizarRecorrido(int indiceEnRecorrido)
    {
        int indiceAnterior = indiceActual;
        int direccion = (indiceEnRecorrido - indiceActual);

        if (!moviendo)
        {
            botonJugar.interactable = false;
            botonSiguiente.interactable = false;
            botonAtras.interactable = false;
            botonCerrar.interactable = false;
            if (direccion < 0)
            {
                StartCoroutine(Retroceder(indiceActual, Mathf.Abs(direccion)));
            }
            else
            {
                StartCoroutine(Avanzar(indiceActual, Mathf.Abs(direccion)));
            }
        }
    }

    public IEnumerator Retroceder(int actual, int pasos)
    {
        moviendo = true;
        indiceSiguiente = actual - pasos;
        Debug.Log("0");
        for (int i = 0; i < pasos; i++)
        {
            posicionAMover = recorrido[actual - i - 1].transform.position;
            distancia = Vector3.Distance(personaje.transform.position, posicionAMover);
            while (distancia > 5)
            {
                distancia = Vector3.Distance(personaje.transform.position, posicionAMover);
                asignandoPosicion = true;
                yield return null;
                Debug.Log("prueba while");
            }
            asignandoPosicion = false;
            yield return null;
        }
        Debug.Log("1");
        yield return null;
        indiceActual = actual - (pasos);
        moviendo = false;
        Debug.Log("2");
        botonJugar.interactable = true;
        botonSiguiente.interactable = true;
        botonAtras.interactable = true;
        botonCerrar.interactable = true;
        Debug.Log("3");
    }

    public IEnumerator Avanzar(int actual, int pasos)
    {

        moviendo = true;
        indiceSiguiente = actual + pasos;
        Debug.Log("0");
        for (int i = 0; i < pasos; i++)
        {
            posicionAMover = recorrido[actual + i + 1].transform.position;
            distancia = Vector3.Distance(personaje.transform.position, posicionAMover);
            while (distancia > 5)
            {
                distancia = Vector3.Distance(personaje.transform.position, posicionAMover);
                asignandoPosicion = true;
                yield return null;
                Debug.Log("prueba while");
            }
            asignandoPosicion = false;
            yield return null;
        }

        Debug.Log("1");
        yield return null;
        indiceActual = actual + (pasos);
        moviendo = false;
        Debug.Log("2");
        botonJugar.interactable = true;
        botonSiguiente.interactable = true;
        botonAtras.interactable = true;
        botonCerrar.interactable = true;
        Debug.Log("3");
    }

    void Update()
    {
        if (asignandoPosicion)
        {
            personaje.transform.position = Vector2.MoveTowards(personaje.transform.position,
                    posicionAMover, 1000 * Time.deltaTime);
            if(personaje.transform.position == posicionAnterior)
            {
                personaje.transform.position = posicionAMover;
                Debug.Log("entra");
            }
            else
            {
                posicionAnterior = personaje.transform.position;
            }
            
        }
        
    }

    public void AsignarEventoJugarPVZMundo1()
    {
        botonJugar.onClick.RemoveAllListeners();
        if (indiceSiguiente == 0)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[0].Invoke(); });
        }else if(indiceSiguiente == 1)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[1].Invoke(); });
        }
        else if (indiceSiguiente == 3)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[2].Invoke(); });
        }
        else if (indiceSiguiente == 4)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[3].Invoke(); });
        }
        else if (indiceSiguiente == 5)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[4].Invoke(); });
        }
        else if (indiceSiguiente == 6)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[5].Invoke(); });
        }
        else if (indiceSiguiente == 7)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[6].Invoke(); });
        }
        else if (indiceSiguiente == 8)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[7].Invoke(); });
        }
        else if (indiceSiguiente == 9)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[8].Invoke(); });
        }
        else if (indiceSiguiente == 11)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[9].Invoke(); });
        }
    }

    public void AsignarEventoJugarPVZMundo2()
    {
        botonJugar.onClick.RemoveAllListeners();
        if (indiceSiguiente == 0)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[0].Invoke(); });
        }
        else if (indiceSiguiente == 1)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[1].Invoke(); });
        }
        else if (indiceSiguiente == 3)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[2].Invoke(); });
        }
        else if (indiceSiguiente == 4)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[3].Invoke(); });
        }
        else if (indiceSiguiente == 5)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[4].Invoke(); });
        }
        else if (indiceSiguiente == 6)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[5].Invoke(); });
        }
        else if (indiceSiguiente == 8)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[6].Invoke(); });
        }
        else if (indiceSiguiente == 9)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[7].Invoke(); });
        }
        else if (indiceSiguiente == 10)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[8].Invoke(); });
        }
        else if (indiceSiguiente == 11)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[9].Invoke(); });
        }
    }

    public void AsignarEventoJugarPVZMundo3()
    {
        botonJugar.onClick.RemoveAllListeners();
        if (indiceSiguiente == 0)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[0].Invoke(); });
        }
        else if (indiceSiguiente == 1)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[1].Invoke(); });
        }
        else if (indiceSiguiente == 3)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[2].Invoke(); });
        }
        else if (indiceSiguiente == 4)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[3].Invoke(); });
        }
        else if (indiceSiguiente == 5)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[4].Invoke(); });
        }
        else if (indiceSiguiente == 6)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[5].Invoke(); });
        }
        else if (indiceSiguiente == 7)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[6].Invoke(); });
        }
        else if (indiceSiguiente == 8)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[7].Invoke(); });
        }
        else if (indiceSiguiente == 10)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[8].Invoke(); });
        }
        else if (indiceSiguiente == 11)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[9].Invoke(); });
        }
    }

    public void AsignarEventoJugarPVZMundo4()
    {
        botonJugar.onClick.RemoveAllListeners();
        if (indiceSiguiente == 0)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[0].Invoke(); });
        }
        else if (indiceSiguiente == 1)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[1].Invoke(); });
        }
        else if (indiceSiguiente == 3)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[2].Invoke(); });
        }
        else if (indiceSiguiente == 5)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[3].Invoke(); });
        }
        else if (indiceSiguiente == 6)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[4].Invoke(); });
        }
        else if (indiceSiguiente == 7)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[5].Invoke(); });
        }
        else if (indiceSiguiente == 9)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[6].Invoke(); });
        }
        else if (indiceSiguiente == 10)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[7].Invoke(); });
        }
        else if (indiceSiguiente == 11)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[8].Invoke(); });
        }
        else if (indiceSiguiente == 12)
        {
            botonJugar.onClick.AddListener(() => { eventosMundosACargar[9].Invoke(); });
        }
    }

    
}
