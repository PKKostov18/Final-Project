using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public Rigidbody2D RB;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float sens = 1f;

    public Camera viewCam;

    public GameObject bulletImpact; 
    public int ammo;

    public Animator gunAnim;
    public Animator anim;

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    private bool dead; 

    public Text healthText, ammoText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString() + "%";

        ammoText.text = ammo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead)
        {
        //script for the movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;

        RB.velocity = (moveHorizontal + moveVertical) * moveSpeed;
        //


        //script for the view
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * sens;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));
        //


        //script for shooting
        if (Input.GetMouseButtonDown(0))
        {
            if  (ammo > 0)
            {
            Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
	            Instantiate(bulletImpact, hit.point, transform.rotation);

                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                }
            }
            else
            {
                Debug.Log("I am looking at nothing!");
            }
            ammo--; 
            gunAnim.SetTrigger("Shoot");
            ammoText.text = ammo.ToString();
            UpdateAmmoUI();
         }
        }

        if(moveInput != Vector2.zero)
        {
            anim.SetBool("IsMoving", true);
        }

        else
        {
        anim.SetBool("IsMoving", false);
        }
    }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            dead = true;
            currentHealth = 0;
        }

          healthText.text = currentHealth.ToString() + "%";
    }

    public void AddHealth(int heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    
     healthText.text = currentHealth.ToString() + "%";
    
    }

    public void UpdateAmmoUI()
    {
        ammoText.text = ammo.ToString();
    }
}
