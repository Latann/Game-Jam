using UnityEngine;

public class CarryObject : MonoBehaviour
{
    public Transform player;
    public Transform playercam;
    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool Touched = false;

    private void Update()
    {
        // Check la distance entre l'objet et le joueur
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        // si on est a moin ou = 1.9 unité = can carry
        if (dist <= 1.9f)
        {
            hasPlayer = true;

        }
        else
        {
            hasPlayer = false;

        }
        // si on appuis sur R = on porte l'objet
        if (hasPlayer && Input.GetKey(KeyCode.R))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playercam;
            beingCarried = true;
        }
        // Objet en main 
        if (beingCarried)
        {
            // Si collision avec un mur / Objet
            if (Touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                Touched = false;
            }
            // Déposer un objet 
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;

            }
        }
    }
    // Le trigger pour voir le contact avec le collider
    private void OnTriggerEnter(Collider other)
    {
        if (beingCarried)
        {
            Touched = true;
        }
    }
    
}