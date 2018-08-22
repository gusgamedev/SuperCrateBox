using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects: MonoBehaviour
{
	public static CameraEffects effects;

    private Vector2 velocity;
    private Transform target;
    private bool isShaking = false;

    public float smoothTimeX;
    public float smoothTimeY;
    public float shakeTime;
    public float shakeAmount;

    private void Awake() 
    {
		if (effects == null)
        {
			effects = this;
        }
		else if(effects != this) 
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        CameraFollow();
        
        if (isShaking)
            CameraShake();
    }

    private void CameraShake()
    {
        if (shakeTime >= 0)
        {
            Vector2 shakepos = Random.insideUnitCircle * shakeAmount;

            transform.position = 
                new Vector3(
                    transform.position.x + shakepos.x,
                    transform.position.y + shakepos.y,
                    transform.position.z);
            
            shakeTime -= Time.deltaTime;
        } 
        else 
        {
            isShaking = false;
        }
    }

    private void CameraFollow() {

        if (target != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, smoothTimeX);
			float posY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.y, smoothTimeY);

            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }

    public void StartShaking() {
        isShaking = true;
    }

}
