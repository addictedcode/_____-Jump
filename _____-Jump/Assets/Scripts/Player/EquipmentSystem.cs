using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject SpringPrefab; // 0
    [SerializeField] private GameObject Hand;
    [SerializeField] private float springThrowForce;

    [SerializeField] private GameObject activeItem;

    private int selectedItem = 0;
    [SerializeField] private int SpringAmmo = 3;
    [SerializeField] private int RocketAmmo = 3;

    private void Awake()
    {
        SelectWeapon();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // throw Spring
        {
            if (SpringAmmo > 0)
            {
                activeItem.transform.eulerAngles = Vector3.zero;
                Collider[] colliders = activeItem.GetComponents<Collider>();
                for (int j = 0; j < colliders.Length; j++)
                {
                    colliders[j].enabled = true;
                }
                activeItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                activeItem.GetComponent<Spring>().enabled = true;
                activeItem.GetComponent<Rigidbody>().AddForce(transform.forward * springThrowForce);
                activeItem.transform.parent = null;

                SpringAmmo--;
                if (SpringAmmo > 0)
                {
                    SelectWeapon();
                }
            }
        }
    }


    void SelectWeapon()
    {
        int i = 0;

        if(i == 0) // Spring
        {
            activeItem = GameObject.Instantiate(SpringPrefab, Hand.transform.position, this.transform.rotation, this.transform);
            Collider[] colliders = activeItem.GetComponents<Collider>();
            for (int j = 0; j < colliders.Length; j++) {
                colliders[j].enabled = false;
            } 
            activeItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            activeItem.GetComponent<Spring>().enabled = false;

        }
        else if (i == 1) // Rocket
        {

        }


    }
    void ThrowSpring()
    {

    }

    void ShootRocket()
    {

    }
}
