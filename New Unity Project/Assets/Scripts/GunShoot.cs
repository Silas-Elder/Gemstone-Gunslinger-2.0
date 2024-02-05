using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour
{
    public Transform shootPos;
    public Transform guntipPos;
    public Transform firePos;
    public int ammo;
    public int full;
    public bool fire = true;
    public bool reloading = false;
    public float fireRate;
    public float reloadRate;
    public Text scoreText;
    public Text ammoText;
    public int score;
    public Slider hp;
    public int maxHp = 3;
    public int rnHp;

    public AudioSource pew;
    public AudioSource explosion;
    public AudioSource ding;
    public AudioSource superDing;
    public AudioSource click;
    

    public ParticleSystem flash;
    public ParticleSystem pop;
    public ParticleSystem colorPop;
    public ParticleSystem boom;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rnHp = maxHp;
        hp.value = rnHp;
        //line = GetComponent<LineRenderer>();
        ammo = full;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (reloading == true)
            return; */

        if (ammo == 0 || Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());
            ammoText.text = ammo.ToString() + " / 12";
        //return;

        if (Input.GetButtonDown("Fire1") && fire == true)
        {
            
            StartCoroutine(Shoot());
            
        }

        if(hp.value == 0)
        {
            FindObjectOfType<Game>().GameOver();
        }

        
    }

    void LateUpdate()
    {
      // StartCoroutine(DrawLine());
    }

    IEnumerator Reload()
    {
        anim.SetTrigger("Reload");
        reloading = true;
        
        yield return new WaitForSeconds(reloadRate);
        click.Play();
        ammo = full;
        reloading = false;
    }

    IEnumerator Shoot()
    {
        anim.SetTrigger("Shoot");
        fire = false;
        flash.Play();
        pew.Play();
        ammo--;
        ammoText.text = ammo.ToString() + " / 12";
        RaycastHit hit;
        if(Physics.Raycast(shootPos.position, shootPos.forward, out hit))
        {
            if(hit.collider.tag == "gem")
            {
                Destroy(hit.transform.gameObject);
                ding.Play();
                pop.Play();
                score++;
                scoreText.text = score.ToString();
            }

            else if(hit.collider.tag == "supergem")
            {
                Destroy(hit.transform.gameObject);
                superDing.Play();
                score += 3;
                colorPop.Play();
                scoreText.text = score.ToString();
            }
            else if(hit.collider.tag == "bomb")
            {
                Destroy(hit.transform.gameObject);
                explosion.Play();
                boom.Play();
                rnHp--;
                hp.value = rnHp;
            }
        }
        
        yield return new WaitForSeconds(fireRate);
        fire = true;

        
    }
    
}
