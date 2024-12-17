using UnityEngine;

public class DetectorDeJugadores : MonoBehaviour
{
    bool tenerloTiro;
    GameObject objetoADisparar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Te tengo a tiro");
            tenerloTiro = true;
            objetoADisparar = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            tenerloTiro = false;
    }
    public bool estaATiro()
    {
        return tenerloTiro;
    }
    public GameObject obtenerObjetivo()
    {
        return objetoADisparar;
    }
}
