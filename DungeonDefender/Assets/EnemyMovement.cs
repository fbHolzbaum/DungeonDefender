using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour {

    public float speed = 1;
    private Rigidbody player;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void FixedUpdate () {
        
        //Player movement
        player.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

        //Raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f))
        {
            if(hit.transform.CompareTag("Wall"))
            {
                Debug.Log("Wand!");
                //Check if left way free
                if(!Physics.Raycast(transform.position, -transform.right, out hit, 1))
                {
                    Debug.Log("Turn left!");
                    player.transform.eulerAngles += new Vector3(0, -90, 0);
                }
                else
                {
                    Debug.Log("Move Right!");
                    player.transform.eulerAngles += new Vector3(0, +90, 0);
                }
            }
        } 
	}
}
