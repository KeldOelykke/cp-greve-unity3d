using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamics : MonoBehaviour {

    public bool clone;
    public float time2Live = 5f;

    private float timeAtStart;
	// Use this for initialization
	void Start () {
        this.timeAtStart = Time.time;	
	}
	
	// Update is called once per frame
	void Update () {

        bool keyClone = Input.GetKeyUp(KeyCode.Space);

        if (!this.clone)
        {
            if (keyClone)
            {
                GameObject gameObject = Instantiate(this.gameObject);
                {
                    Dynamics dynamics = gameObject.GetComponent<Dynamics>();
                    dynamics.clone = true;
                }
                {
                    Rigidbody2D rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
                    rigidBody2d.gravityScale = 1f;
                    rigidBody2d.velocity = new Vector2(Random.Range(-5f, 5f), Random.Range(5f, 15f));
                    rigidBody2d.angularVelocity = rigidBody2d.velocity.x * 100f;
                }
            }
        }

        if (this.clone)
        {
            float deltaTime = Time.time - this.timeAtStart;
            if (this.time2Live < deltaTime)
            {
                this.enabled = false;
                DestroyObject(this.gameObject);
            }
        }
	}
}
