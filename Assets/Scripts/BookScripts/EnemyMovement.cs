using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
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
            if (hit.distance < obstRange) {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
        Debug.DrawRay(transform.position, ray.direction * 2, Color.red);
    }

    public void SetAlive(bool aliveSet) {   
        alive = aliveSet;
    }
    
}
