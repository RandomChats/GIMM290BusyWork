using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    private int hp;
    
    // Start is called before the first frame update
    void Start() {
        hp = 5;
    }

    public void Hurt(int damage) {
        hp -= damage;
        Debug.Log("Health: " + hp);
    }
}
