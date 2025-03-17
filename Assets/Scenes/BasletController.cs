using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasletController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;
    void Start()
    {
        Application.targetFrameRate=60;
        this.aud=GetComponent<AudioSource>();
        this.director=GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Apple"){
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple();
        }else{
            this.aud.PlayOneShot(this.bombSE);
            this.director.GetComponent<GameDirector>().GetBomb();
        }
        Destroy(other.gameObject);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,Mathf.Infinity)){
                
                float x =Mathf.RoundToInt(hit.point.x);
                float z =Mathf.RoundToInt(hit.point.z);
                float Xdifference=x-this.transform.position.x;
                float Zdifference=z-this.transform.position.z;
                if(Xdifference<=1&&Xdifference>=-1&&Zdifference<=1&&Zdifference>=-1){
                    transform.position=new Vector3(x,0,z);
                }else{
                    Debug.Log("block!");
                }
                
                
            }
        }
    }
}
