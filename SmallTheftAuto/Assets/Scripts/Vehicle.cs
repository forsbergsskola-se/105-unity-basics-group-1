
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private CarMovement _carMovement;
    private GameObject _player;
    public int health;
    public bool isItMyCar;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        _carMovement = GetComponent<CarMovement>();
    }

    private void Update()
    {
        //Todo: fix when we push getButton it shouldn't do a double getButton 'F'
        if(Input.GetButtonDown("Interact-Vehicle") && !_player.activeInHierarchy)
            Exit();
        
        Health();
    }

    public void Enter()
    {
        _player.SetActive(false);
        _carMovement.enabled = true;
    }

    private void Exit()
    {
        if (!isItMyCar) return;
        
        _player.SetActive(true);
        //Move player a little so he doesn't spawn and push the car down 
        _player.transform.position = transform.position + new Vector3(2.5f,0f,0f);
        _carMovement.enabled = false;
        isItMyCar = false;
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
