using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rg;
    public Camera cam;
    private float distX;
    private Vector3 goscreen;
    public float jump;
    private int died = 2;
    private float speed;
    public GameplayManger gm;
    // Start is called before the first frame update
    private void Awake() {
        rg = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameplayManger>();
    }
    private void OnTriggerEnter(Collider other) {
        if(died == 0){
            if(other.name == "Trig"){
                gm.addScore();
            }else{
                died = 1;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(died == 0){
            //move forward
            Vector3 newPos = this.transform.position;
            newPos += (transform.right * speed);
            this.transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 1);
            
            //move cam
            cam.transform.position = new Vector3(this.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            //jump
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
                rg.AddForce(Vector3.up * jump, ForceMode.VelocityChange);
            }
            //check top or bot collider
            Vector3 goscreen = Camera.main.WorldToScreenPoint(transform.position);
            float distY = Vector3.Distance(new Vector3(0f, Screen.height / 2, 0f), new Vector3(0f, goscreen.y, 0f));
            if(distY > Screen.height / 2){
                print(this.transform.position.y);
                died = 1;
            }
        }else if(died == 1){
            died = 2;
            gm.gameOver();
            rg.isKinematic = true;
        }else{

        }
    }

    void FixedUpdate() {
        rg.AddForce(Vector3.down * 1, ForceMode.Impulse);
    }

    public void Init(){
        died = 0;
        rg.isKinematic = false;
    }

    public void SetSpeed(float speed){
        this.speed = speed;
    }
}
