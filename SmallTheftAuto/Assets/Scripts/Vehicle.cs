
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private CarMovement _carMovement;
    public GameObject player;
    public int health;
    public bool isItMyCar;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        _carMovement = GetComponent<CarMovement>();
    }

    private void Update()
    {
        //Todo: fix when we push getButton it shouldn't do a double getButton 'F'
        if(Input.GetButtonDown("Interact-Vehicle") && !player.activeInHierarchy)
            Exit();
        
        Health();
    }

    public void Enter()
    {
        Driver driver = player.GetComponent<Driver>();
        driver.gameObject.SetActive(false);
        _carMovement.enabled = true;
    }

    private void Exit()
    {
        //Vehicle [] _vehicles = FindObjectsOfType<Vehicle>();
        if(isItMyCar)
        {
            player.SetActive(true);
            //Move player a little so he doesn't spawn and push the car down 
            player.transform.position = transform.position + new Vector3(2.5f,0f,0f);
            _carMovement.enabled = false;
            isItMyCar = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
         //if you want to add enemy cars, call it CarE
        if(collision.gameObject.CompareTag("Wall")||collision.gameObject.CompareTag("CarE")) 
            health -= 10;
    }

    private void Health()
    {
        //Todo: After Destroy make player.health = 0;
        if (health == 0)
            Destroy(gameObject);
    }
    
}
