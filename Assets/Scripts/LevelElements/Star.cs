using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star: MonoBehaviour {
    bool isCollected;
    // Start is called before the first frame update
    void Start() {
        isCollected = false;
    }

    // Update is called once per frame
    void Update() {
        if(isCollected) {
            Destroy(gameObject);
	    }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameManager.Instance().IncrementStarCount();
        isCollected = true;
    }
}
