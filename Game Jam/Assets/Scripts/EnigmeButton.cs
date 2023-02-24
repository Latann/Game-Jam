using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeButton : MonoBehaviour
{
    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public GameObject zone4;
    public GameObject ObjetaUnlock;
 

    private int currentZone = 1;
    private int lastZone = 0;
    private Dictionary<int, GameObject> zoneGameObjects = new Dictionary<int, GameObject>();

    void Start()
    {
        // Stockage Boutton par zone
        zoneGameObjects.Add(1, zone1);
        zoneGameObjects.Add(2, zone2);
        zoneGameObjects.Add(3, zone3);
        zoneGameObjects.Add(4, zone4);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Zone" + currentZone))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                lastZone = currentZone;
                currentZone++;
                if (currentZone > 4)
                {
                    Destroy(ObjetaUnlock);
                }
                else
                {
                    // Change couleur du boutton
                    zoneGameObjects[currentZone - 1].GetComponent<Renderer>().material.color = Color.green;
                    
                }
            }
        }
        else if (other.gameObject.CompareTag("Zone" + (currentZone - 1)))
        {
            currentZone--;
        }
        else
        {
            // Reset l'ordre si erreur
            currentZone = 1;
            foreach (var zoneGameObject in zoneGameObjects.Values)
            {
                zoneGameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}


