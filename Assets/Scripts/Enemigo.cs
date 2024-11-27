using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    int gorpesNecesarios = 2;
    [SerializeField]
    int puntosGanados = 1;
    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Arma")
        {
            ProcesarGorpe();
        }
    }
    void ProcesarGorpe()
    {
        gorpesNecesarios--;
        if (gorpesNecesarios <= 0)
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
