using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        StartCoroutine(CargarUnNivel(SceneManager.GetActiveScene().name));
    }
    IEnumerator CargarUnNivel(String nombreEscena)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nombreEscena);
    }
}
