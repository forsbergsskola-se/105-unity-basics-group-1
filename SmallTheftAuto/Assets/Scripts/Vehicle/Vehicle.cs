using UnityEngine;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour
{
    private CameraFollow[] _cameras;
    public GameObject fire;
    private CarMovement _carMovement;
    private Player _player;
    private float _burn = 5;
    private float _carMaxHealth;
    public float carHealth;
    public bool isItMyCar;
    
    //testing 
    public Image healthBar;
    public GameObject _ps;
    private bool _onFire;
    

    private void Start()
    {
        _carMaxHealth = carHealth;
        _cameras = FindObjectsOfType<CameraFollow>();
        _player = FindObjectOfType<Player>();
        _carMovement = GetComponent<CarMovement>();

       // _ps = GetComponent<ParticleSystem>();
       _onFire = false;
    }

    private void Update()
    {
        if(isItMyCar && Input.GetButtonDown("Interact-Vehicle") && !_player.gameObject.activeInHierarchy) 
            Exit();
        Health();
    }

    public void Enter(Vehicle car)
    {
        foreach (var camera in _cameras)
        {
            camera.ChangeTarget(gameObject);
        }
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
        foreach (var camera in _cameras)
        {
            camera.ChangeTarget(_player.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
         //if you want to add enemy cars, call it CarE
         if (collision.gameObject.CompareTag("CarE"))
         {
             //So other cars take damage if we drive into them.
             collision.gameObject.GetComponent<Vehicle>().carHealth -= _carMovement.currSpeed;
             carHealth -= _carMovement.currSpeed;
         }
         else
         {
             // Takes damage on everything depending on carSpeed, so if we are driving we take damage on everything. We need if pedestrianTag dont take damage instead kill him
             carHealth -= _carMovement.currSpeed;
         }
    }

    private void Health()
    {
        healthBar.fillAmount = carHealth / _carMaxHealth;
        
        //Shows healthBar on cars when damaged
        if(carHealth < _carMaxHealth)
            healthBar.transform.parent.gameObject.SetActive(true);
        
        if (carHealth < 0)
        {
            Destroy(gameObject);
            //destroy firePS
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
            //To spawn fireOnCar once 
            if(!_onFire)
            {
                _ps.SetActive(true);
                _onFire = true;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        carHealth -= damage;
    }
}
