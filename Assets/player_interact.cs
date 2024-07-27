using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class player_interact : MonoBehaviour
{
    private int coins,p1=0,p2=0,p3=0;
    public TextMeshProUGUI cointxt;
    public TextMeshProUGUI fshop,pin1,pin2,pin3;

    private string shoptxt,guardtxt;
    public bool apples;
    public GameObject guards,canvas;

    public Button up1,up2,up3,down1,down2,down3;
    
    private void OnTriggerEnter(Collider other){
        
        if(other.transform.tag=="Coin"){
            coins++;
            cointxt.text="Coins:"+coins.ToString();
            Destroy(other.gameObject);
        }

        else if(other.transform.tag=="Shop"){
            if (coins==5){
                fshop.text="Here you go the apples are for you";
                cointxt.text="Inventory:Apples";
                apples=true;
            }  
            else{
                fshop.text="Any fruit you buy here costs 5 coins.Get that for me first then you will get your fruits";
            }  
            
        }

        else if(other.transform.tag=="Guard"){
            if (apples==true){
                fshop.text="Thank you for the food. You may enter and take whatever you neec.";
                cointxt.text="";

            }  
            else{
                fshop.text="Hey, if you want anything from in here, you need to give me some food first.";
            }  
            
        }
        else if(other.transform.tag=="TimeMachine"){
            if (apples==true){
                canvas.SetActive(true);
                up1.onClick.AddListener(Up1Click);
                up2.onClick.AddListener(Up2Click);
                up3.onClick.AddListener(Up3Click);
                down1.onClick.AddListener(Down1Click);
                down2.onClick.AddListener(Down2Click);
                down3.onClick.AddListener(Down3Click);
            }
            
        }
            
    }

    void check(){
            if(p1==1 && p2==5 && p3==3){
                SceneManager.LoadScene("EndScene");
        }
    }

    private void OnTriggerExit(Collider other){
        fshop.text="";
        canvas.SetActive(false);
    }

    void Up1Click(){
		if(p1!=9){
            p1+=1;
        }
        else{
            p1=0;
        }
        pin1.text=p1.ToString();
        check();
	}
    void Up2Click(){
		if(p2!=9){
            p2+=1;
        }
        else{
            p2=0;
        }
        pin2.text=p2.ToString();
        check();
	}
    void Up3Click(){
		if(p3!=9){
            p3+=1;
        }
        else{
            p3=0;
        }
        pin3.text=p3.ToString();
        check();
	}
    void Down1Click(){
		if(p1!=0){
            p1-=1;
        }
        else{
            p1=9;
        }
        pin1.text=p1.ToString();
        check();
	}
    void Down2Click(){
		if(p2!=0){
            p2-=1;
        }
        else{
            p2=9;
        }
        pin2.text=p2.ToString();
        check();
	}
    void Down3Click(){
		if(p3!=0){
            p3-=1;
        }
        else{
            p3=9;
        }
        pin3.text=p3.ToString();
        check();
	}

}
