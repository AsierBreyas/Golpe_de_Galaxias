using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ArmaJugador : MonoBehaviour
{
    bool estoyDisparando;
    [SerializeField]
    GameObject[] laseres;
    [SerializeField]
    RectTransform puntero;
    [SerializeField]
    Transform boloncho;
    [SerializeField]
    float targetDistance = 100f;
    // Update is called once per frame
    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcesarDisparo();
        MoverPuntero();
        Apuntar();
    }
    void OnFire(InputValue value)
    {
        estoyDisparando = value.isPressed;
    }
    void ProcesarDisparo()
    {
        foreach(GameObject laser in laseres)
        {
            var emmisionModule = laser.GetComponent<ParticleSystem>().emission;
            emmisionModule.enabled = estoyDisparando;
        }
        //if (estoyDisparando)
        //    Debug.Log("PIUM PIUM");
    }
    void MoverPuntero()
    {
        puntero.position = Input.mousePosition;
        boloncho.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance));
    }
    void Apuntar()
    {
        foreach (GameObject laser in laseres)
        {
            Vector3 fireDirection = boloncho.position - this.transform.position;
            Quaternion apuntarAlEnemigo = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = apuntarAlEnemigo;
        }
    }
}
