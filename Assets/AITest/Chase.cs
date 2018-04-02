using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {
    /*
    public AudioSource audioSource;
    public AudioClip swingClip;
    public AudioClip goblinLaughClip;
    */
    public Transform player;
    public Rigidbody enemyRigidBody;
    static Animator patrolCycle;

    private float rotationSpeed = .1f;
    private int agressionDistance = 3;
    private float enemyMovementSpeed = .00005f;
    private Vector3 direction;

    void Start() {
        patrolCycle = GetComponent<Animator>();
        enemyRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Vector3 distance = player.position - this.transform.position;
        if (distance.magnitude < agressionDistance) {

            direction = player.position - this.transform.position;
            lookAtTarget(direction);

            patrolCycle.SetBool("Idle", false);
            if (direction.magnitude > 1) {
                enemyRigidBody.AddForce(transform.forward * enemyMovementSpeed);
                patrolCycle.SetBool("Attacking", false);
                patrolCycle.SetBool("Chasing", true);
            }
            else {
                patrolCycle.SetBool("Attacking", true);
                patrolCycle.SetBool("Chasing", false);
            }
        }
        else {
            patrolCycle.SetBool("Idle", true);
            patrolCycle.SetBool("Attacking", false);
            patrolCycle.SetBool("Chasing", false);
            enemyRigidBody.angularVelocity = new Vector3(0f, 0f, 0f);
        }
    }


    /// <summary>
    /// private functions
    /// </summary>
    private void lookAtTarget(Vector3 direction) {
        direction.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);
    }
    /// <summary>
    /// public functions
    /// </summary>
    public float getRotationSpeed() {
        return rotationSpeed;
    }
    public void setRotationSpeed(float rotationSpeed) {
        this.rotationSpeed = rotationSpeed;
    }
}

