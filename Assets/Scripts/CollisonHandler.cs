using UnityEngine;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    public void OnTriggerEnter(Collider other){

        Debug.Log($"Me he chocado contra {other.name}");
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }
}
