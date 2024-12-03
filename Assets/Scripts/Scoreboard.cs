using UnityEngine;
using TMPro;
using System.Collections;

public class Scoreboard : MonoBehaviour
{

    int puntuacion;
    [SerializeField]
    TextMeshProUGUI textoPuntuacion;
    [SerializeField]
    TextMeshProUGUI textoSuma;
    int sumandoPuntuacion;

    private void Start()
    {
        puntuacion = 0;
        textoPuntuacion.text = puntuacion.ToString();
        textoSuma.gameObject.SetActive(false);
    }

    public void añadirPuntuacion(int puntosGanados)
    {
        puntuacion += puntosGanados;
        sumandoPuntuacion =+ puntosGanados;
        textoSuma.gameObject.SetActive(true);
        textoSuma.text = "+ " + sumandoPuntuacion;
        StartCoroutine(ActualizarTexto(puntosGanados));
    }
    IEnumerator ActualizarTexto(int puntosGanados)
    {
        yield return new WaitForSecondsRealtime(1f);
        textoSuma.gameObject.SetActive(false);
        sumandoPuntuacion = 0;
        textoPuntuacion.text = puntuacion + "";
    }
}
