using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    bool meEstoyMoviendo;
    Vector2 movimiento;
    [SerializeField]
    float topeMaximo = 7f;
    [SerializeField]
    float topeMinimo = -7f;
    [SerializeField]
    float velocidad = 10f;
    [SerializeField]
    float rotacion = 15f;
    [SerializeField]
    float velocidadRotacion = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarTransicion();
        ProcesarRotacion();
    }
    void OnMoverse(InputValue value) {
        movimiento = value.Get<Vector2>();
    }

    void ProcesarTransicion()
    {
        float xOffSet = movimiento.x * velocidad * Time.deltaTime;
        float yOffSet = movimiento.y * velocidad * Time.deltaTime;
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x + xOffSet, topeMinimo, topeMaximo), Mathf.Clamp( transform.localPosition.y + yOffSet, topeMinimo, topeMaximo), 0f);
    }
    void ProcesarRotacion()
    {
        Quaternion toRotation = Quaternion.Euler(-movimiento.y * rotacion, transform.localRotation.y, -movimiento.x * rotacion);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, toRotation, velocidadRotacion * Time.deltaTime);
    }
}
