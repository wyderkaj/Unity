using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float force;
    private Rigidbody2D rb;
    private Animator anim;

    private int Points = 0;
    public Text ScoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {           
            ClickedOnMouse();
        }
        else
        {
            anim.SetBool("Clicked", false);
        }
    }

    void ClickedOnMouse()
    {
        rb.velocity = Vector2.up * force;
        anim.SetBool("Clicked", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Points++;
        ScoreText.text = Points.ToString();
        

    }
}
