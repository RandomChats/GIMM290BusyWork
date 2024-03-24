using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] private GameObject fireBallPrefab;
    private GameObject fireBall;
    
    private bool alive;
    
    public float speed = 3.0f;
    public float obstRange = 5.0f;
    
    // Start is called before the first frame update
    void Start() {
        alive = true;
    }

    // Update is called once per frame
    void Update() {
        if (alive) {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>()) {
                Debug.Log("Hit Player");
                if (fireBall == null) {
                    fireBall = Instantiate(fireBallPrefab) as GameObject;
                    fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireBall.transform.rotation = transform.rotation;
                }
            } else if (hit.distance < obstRange) {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
                Debug.Log("Hit Wall");
            }
        }
        Debug.DrawRay(transform.position, ray.direction * 2, Color.red);
        
        
    }

    public void SetAlive(bool aliveSet) {   
        alive = aliveSet;
    }
    
}
