using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public float speed = 1.0f;
    Rigidbody2D r2d;
    Animator _animator;
    Vector3 charPos;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] GameObject _camera;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); //caching spriterenderer
        r2d = GetComponent<Rigidbody2D>(); //caching 2d
        _animator = GetComponent<Animator>(); //caching animator
        charPos = transform.position; //character position       
    }

    private void FixedUpdate() // 50 fps  burada physics
    {
    }

    void Update() // per frame (60fps e en yakın olması için Fixed Timestep optimum 0.02 olmalı
    {
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y); // delta time her bir frame arasındaki zamanı tutuyor //time.fixedDeltaTime search
        transform.position = charPos; // hesapladığım pozisyon karakterime işlensin
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }

        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }

    }

    private void LateUpdate()
    {
        //   _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);     
    }




}
