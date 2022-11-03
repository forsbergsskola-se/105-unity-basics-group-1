
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;
    private CarMovement _carMovement;
    public int health;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        _carMovement = GetComponent<CarMovement>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Interact-Vehicle"))
            if(!player.activeInHierarchy)
                Exit();
                
        Health();
    }

    public void Enter()
    {
        Driver driver = player.GetComponent<Driver>();
        driver.gameObject.SetActive(false);
        _carMovement.enabled = true;
    }

    void Exit()
    {
        player.SetActive(true);
        //Move player a little so he doesn't spawn and push the car down 
        player.transform.position = transform.position + new Vector3(2.5f,0f,0f);
        _carMovement.enabled = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
         //if you want to add enemy cars, call it CarE
        if(collision.gameObject.CompareTag("Wall")||collision.gameObject.CompareTag("CarE")) 
            health -= 10;
        
        Debug.Log(collision.gameObject.name);
    }

    void Health()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
    
}
