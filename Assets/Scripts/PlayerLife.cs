using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;

    bool dead = false;
    [SerializeField] Text deathCounter;
    int deathCount = 0;
    string ranVal;

    private void Start()
    {
        ranVal = "Deaths: " + (Memorizer.deathText).ToString();
        deathCount = Memorizer.deathText;
        deathCounter.text = ranVal;
    }

    private void Update()
    {
        if (transform.position.y < - 2f && !dead)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body")) 
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;            
            Die();
        }
    }

    void Die()
    {       
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
        deathSound.Play();        
    }



    public void ReloadLevel()
    {
        deathCount++;
        deathCounter.text = "Deaths: " + deathCount;
        Memorizer.deathText = deathCount;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


