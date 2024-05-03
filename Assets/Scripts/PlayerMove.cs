using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour

{
    public Vector3 newPosition = new Vector3(50, 5, 0);
    public float movementSpeed = 5;
    private float inputHorizontal;
    public bool jump = false;
    public Rigidbody2D rBody;
    public float jumpForce = 5;
    public GroundSensor sensor;
    public SpriteRenderer render;
    public Animator anim;
    AudioSource source;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip shootSound;

    public Transform bulletSpawn;

    public GameObject bulletPrefab;

    private bool canShoot = true;

    public float timer;

    public float rateOfFire = 1;
    
    public bool isDeath = false;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Teletrasnporta al personaje a la posicion dicha en la varaible
        //transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        //transform.position = transform.position + new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
        //transform.position += new Vector3(inputHorizontal, 0, 0) * movementSpeed * Time.deltaTime;

       /* if(jump == true)
        {
            Debug.Log("estoy saltando");
        }
        else if(jump == false)
        {
            Debug.Log("estoy en el suelo");
        }
        else
        {
            Debug.Log("yooooo");
        }*/
        
        
        Shoot();

        Jump();

        Movement();
    }

    void FixedUpdate()
    {
         rBody.velocity = new Vector2(inputHorizontal * movementSpeed, rBody.velocity.y);
        
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && sensor.isGrounded == true)
        {
               rBody.AddForce(new Vector2(0,1) * jumpForce, ForceMode2D.Impulse);   
               anim.SetBool("IsJumping", true);
               source.PlayOneShot(jumpSound);
        }
        
    }

    
    void Shoot()
    {
        if(!canShoot)
        {
            timer += Time.deltaTime;

            if(timer >= rateOfFire)
            {
                canShoot = true;
                timer = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            canShoot = false;

            source.PlayOneShot(shootSound);
        }
    }

    void Movement()
    {
        if(inputHorizontal < 0)
        {
            //render.flipX = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("IsRunning", true);
        }
        else if(inputHorizontal > 0)
        {
            //render.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("IsRunning", true);
        }
        else 
        {
            anim.SetBool("IsRunning", false);
        }
    }

    /*public void PlayerDeath()
        {
            source.PlayOneShot(deathSound);

            SceneManager.LoadScene(0);

            //StartCourtine(Die(7, 8.5f));
            //StartCourtine("Die");

            //StopCourtine("Die")
            //StopAllCourtines();
        }*/

    public IEnumerator Die()
    {
        isDeath = true;
        source.PlayOneShot(deathSound);

            //Time.timeScale = 0;

        yield return new WaitForSeconds(2);
        /* yield return new WaitForSecondsRealTime(2);
            yield return null;*/
            //yield return new WaitForEndOffFrame();

            //yield return Courrutina();

        SceneManager.LoadScene("Game over");
    }
}

