using UnityEngine;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    AudioClip ostiarse;
    public void OnTriggerEnter(Collider other){

        Debug.Log($"Me he chocado contra {other.name}");
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        FindAnyObjectByType<LevelManager>().ReloadLevel();
        AudioSource.PlayClipAtPoint(ostiarse, Camera.main.transform.position, 100);
    }
}
