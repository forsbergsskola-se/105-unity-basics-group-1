using UnityEngine;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour
{
    private CameraFollow[] _cameras;
    public GameObject fire;
    private CarMovement _carMovement;
    private Player _player;
    private float _burn = 5;
    //Working on:
    private float _carMaxHealth;
    private float _carHealth = 60f;
   
    public bool isItMyCar;
    
    //testing 
    public Image healthBar;
    public GameObject ps;
    private bool _onFire;
    

    private void Start()
    {
        _carMaxHealth = _carHealth;
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
        if(_carHealth <= _carMaxHealth / 2)
            TakeDamage(_burn * Time.deltaTime); 
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
             collision.gameObject.GetComponent<Vehicle>()._carHealth -= _carMovement.currSpeed;
             _carHealth -= _carMovement.currSpeed;
         }
         if (collision.gameObject.CompareTag("Player"))
         {
             //If colliding with player dont take damage(do nothing)
             //Physics.IgnoreCollision(_player.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
         }
         if (collision.gameObject.layer == 3)
         {
             //if colliding with layer ground take no damage.
         }
         else
         {
             // Takes damage on everything depending on carSpeed, so if we are driving we take damage on everything. We need if pedestrianTag dont take damage instead kill him
             _carHealth -= _carMovement.currSpeed;
         }
    }

    private float Health2
    {
        get => _carHealth;
        set
        {
            _carHealth = value;
            healthBar.fillAmount = value / _carMaxHealth;
            Health();
            /*
            //Shows healthBar on cars when damaged
            if(_carHealth < _carMaxHealth) 
                healthBar.transform.parent.gameObject.SetActive(true);
        
            if (value < 0)
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
                _carHealth = 0;
            }

            if (value <= _carMaxHealth / 2)
            {
                //TakeDamage(_burn * Time.deltaTime); 
                //To spawn fireOnCar once 
               
                if(!_onFire)
                {
                    ps.SetActive(true);
                    _onFire = true;
                }
            }
            */
        }
    }
    
    private void Health()
    {
        //Shows healthBar on cars when damaged
        if(_carHealth < _carMaxHealth) 
            healthBar.transform.parent.gameObject.SetActive(true);
    
        if (_carHealth < 0)
        {
            Destroy(gameObject);
            //Spawns fire when car dies
            Instantiate(fire, transform.position, transform.rotation );
            //Needs to know if player is in this car then take damage if so, else he dies when anyCar explodes
            if (!isItMyCar) return;
            if (!_player.gameObject.activeInHierarchy) _player.gameObject.SetActive(true);
            _player.TakeDamage(_player.playerInfo.maxHealth);
            _carHealth = 0;
        }

        if (_carHealth <= _carMaxHealth / 2)
            if(!_onFire)
            {
                ps.SetActive(true);
                _onFire = true;
            }
    }
    

    public void TakeDamage(float damage) => Health2 -= damage;
}
