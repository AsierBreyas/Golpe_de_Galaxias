using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    int gorpesNecesarios = 2;
    [SerializeField]
    int puntosGanados = 1;
    [SerializeField]
    AudioClip matarEnemigo;
    private void OnParticleCollision(GameObject other)
    {
        ProcesarGorpe();
        
    }
    void ProcesarGorpe()
    {
        gorpesNecesarios--;
        if (gorpesNecesarios <= 0)
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            FindAnyObjectByType<Scoreboard>().añadirPuntuacion(puntosGanados);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(matarEnemigo, Camera.main.transform.position,10);
        }
    }
}
