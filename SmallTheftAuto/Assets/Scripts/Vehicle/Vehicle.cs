
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private Camera _camera;
    public GameObject fire;
    private CarMovement _carMovement;
    private Player _player;
    private float _burn = 5;
    private float _carMaxHealth;
    public float carHealth;
    public bool isItMyCar;
    

    private void Start()
    {
        _carMaxHealth = carHealth;
        _camera = FindObjectOfType<Camera>();
        _player = FindObjectOfType<Player>();
        _carMovement = GetComponent<CarMovement>();
    }

    private void Update()
    {
        if(isItMyCar && Input.GetButtonDown("Interact-Vehicle") && !_player.gameObject.activeInHierarchy)
            Exit();
        Health();
    }

    public void Enter(Vehicle car)
    {
        _camera.ChangeTarget(gameObject);
        _player.gameObject.SetActive(false);
        car._carMovement.enabled = true;
    }

    private void Exit()
    {
        if (!isItMyCar) return;
        
        _player.gameObject.SetActive(true);
        //Move player a little so he doesn't spawn and push the car down 
        _player.transform.position = transform.position + new Vector3(2.5f,0f,0f);
        _carMovement.enabled = false;
        isItMyCar = false;
        _camera.ChangeTarget(_player.gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
         //if you want to add enemy cars, call it CarE
        if(collision.gameObject.CompareTag("Wall")||collision.gameObject.CompareTag("CarE")) 
            carHealth -= 10;
    }

    private void Health()
    {
        if (carHealth < 0)
        {
            Destroy(gameObject);
            //Spawns fire when car dies
            Instantiate(fire, transform.position, transform.rotation );
            //Needs to know if player is in this car then take damage if so, else he dies when anyCar explodes
            if (!isItMyCar) return;
            if (!_player.gameObject.activeInHierarchy) _player.gameObject.SetActive(true);
            _player.TakeDamage(_player.playerInfo.maxHealth);
            Debug.Log("Car Exploded");
            carHealth = 0;
        }

        if (carHealth <= _carMaxHealth / 2)
        {
            carHealth -= _burn * Time.deltaTime;
            Debug.Log("Car is Burning!!");
        }
    }

    public void TakeDamage(int damage)
    {
        carHealth -= damage;
    }
}
