﻿using UnityEngine;
using System.Collections;

public class intro : MonoBehaviour {

	 public GameObject Food;
    private int food;
    public GameObject Piece;
    private GameObject lastPiece;
    public int Lives;
	private int countfood;
    public bool ShowHigh;
	private int count;
	public int flag=1;
	public int level=0;
	public float t=0;
	private int countflag=0;
	private char[] str={'A','P','P','E','A','L'};
	//private int[] flags={1,2,3,4,5};
	private int checkflag=0;
	private string checkstr="";
	private int startflag = 0;
	//1 for top
	//2 for right
	//3 for bottom
	//4 for left
    // Use this for initialization
    void Start()
    {
	//	if(startflag == 1)
	//		return;
	/*	checkflag=0;
		print (Lives);
		
        ShowHigh = false;
		countfood = 0;
		 int i = 0;
		while(i<6)
		{
        placeFood();
		
			countfood++;
			i++;
		}
       	food = 0;
		lastPiece = gameObject;
        if (PlayerPrefs.GetInt("Food") == 0)
        {
            PlayerPrefs.SetInt("Food", 1);
        }
       //if (PlayerPrefs.GetInt("Lives") <= 0)// && startflag == 0)
       // {
         //  PlayerPrefs.SetInt("Lives", 3);
		//	return;
        //}
        Lives = PlayerPrefs.GetInt("Lives");
		//if(startflag==0)
		//{
		//	PlayerPrefs.SetInt("Lives", 3);
		//	startflag = 1;
		//}
		print("Start Flag"+startflag);
  */  }

    // Update is called once per frame
    void Update()
    {
		
     /*   transform.Translate(new Vector3(0, 0, 0.066f));
        if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			if(flag!=4)
			{
				if(flag==1)
            		transform.Rotate(new Vector3(0, 90, 0));
				if(flag==3)
					transform.Rotate (new Vector3(0,-90,0));
				flag=2;
			}
		}
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			if(flag!=2)
			{
				if(flag==1)
            		transform.Rotate(new Vector3(0, -90, 0));
				else if(flag==3)
					transform.Rotate (new Vector3(0,90,0));
				flag=4;
			}
		}
		else if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			if(flag!=1)
			{
				if(flag==2)
            		transform.Rotate(new Vector3(0, 90, 0));
				else if(flag==4)
					transform.Rotate (new Vector3(0,-90,0));
				flag=3;
			}
		}
		else if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			if(flag!=3)
			{
				if(flag==2)
            		transform.Rotate(new Vector3(0, -90, 0));
				else if(flag==4)
					transform.Rotate (new Vector3(0,90,0));
				flag=1;
			}
		}
		//transform.position = new Vector3(Mathf.Clamp(Time.time, -35.0F, 35.0F), 0, Mathf.Clamp(Time.time, -35.0F, 35.0F));
	//	if(Lives<1)
	//		t=Mathf.Round(Time.timeSinceLevelLoad*100)/100;
       // if (Time.time % 10 < 0.05)
         //   placeFood();
*/    }

  /*  private void placeFood()
    {
		var rotation=Quaternion.identity;
		rotation.eulerAngles=new Vector3(90,0,0);
        var food = Instantiate(Food, new Vector3(Random.Range(-25, 15), 2.2f, Random.Range(-25, 15)), rotation);
		food.name = "Food"+countfood;
		TextMesh tm = new TextMesh();
		tm = (TextMesh)GameObject.Find("Food"+countfood).GetComponent("TextMesh");
    	tm.text = str[countfood].ToString();
		print(tm.text);
		//food.name="Food";
		//food.rotation = Quaternion.Euler(90, 0, 0);
	//	countfood++;
    }

    void OnTriggerEnter(Collider col)
    {
		
		int i;
		for(i=0;i<6;i++)
		{
        if (col.gameObject.name == "Food"+i)
        {
            food++;
            addPiece();
			TextMesh tm = new TextMesh();
			tm = (TextMesh)GameObject.Find("Food"+i).GetComponent("TextMesh");
			count++;
    		checkstr+=tm.text;
			int j;
            for(j=0;j<count;j++)
			{
					if(checkstr[j]!=str[j])
						checkflag=1;
			}
			if(checkflag==0)
			{
				Destroy(col.gameObject);
				print ("checkflag="+checkflag);
				countfood--;
				//checkflag=flags[i];
				//countflag++;
				if(countfood==0)
					t=Mathf.Round(Time.timeSinceLevelLoad*100)/100;
			}
			else{
				Application.LoadLevel(Application.loadedLevel);
            	var oldLives = PlayerPrefs.GetInt("Lives");
				if(oldLives>=1)
            		PlayerPrefs.SetInt("Lives", oldLives - 1);
			
		}
		}
		}
				
         //   placeFood();
        
        if (col.gameObject.name == "Piece")
        {
            Application.LoadLevel(Application.loadedLevel);
            var oldLives = PlayerPrefs.GetInt("Lives");
			if(oldLives>=1)
            		PlayerPrefs.SetInt("Lives", oldLives - 1);
			
           
        }
    }

    private void addPiece()
    {
        var newPiece = Instantiate(Piece, transform.position + new Vector3(20,0,20), Quaternion.identity) as GameObject;
        newPiece.name = "Piece";
        newPiece.GetComponent<SmoothFollow>().target = lastPiece.transform;
		print("Smoothly following\n");
        lastPiece = newPiece;
    }
	 */
    void OnGUI()
    {
		//GUILayout.Label();
		GUILayout.Label("\n\n\n\n\n\n\n\n\n\t\t\t");
		int flag=0;
        if (!ShowHigh && GUILayout.Button("Show High score"))
        {
            ShowHigh = true;
        }
        else if (ShowHigh && GUILayout.Button("Hide High score"))
        {
            ShowHigh = false;
        }
        if (ShowHigh)
        {
            GUILayout.Label("2 Words");
        }
		GUILayout.Label("\t\t\t");
       if (GUILayout.Button("Play"))
        	{
		//	PlayerPrefs.SetInt("Lives", 3);
			//Start();
            Application.LoadLevel(Application.loadedLevel+1);
            PlayerPrefs.SetInt("Lives", 3);
       	 	}
		GUILayout.Label("\t\t\t");
        if (GUILayout.Button("Quit"))
        {
		//	PlayerPrefs.SetInt("Lives", 3);
			//Start();
			Application.LoadLevel(3);

			
            //PlayerPrefs.SetInt("Lives", 3);
        }
		GUILayout.Label("\t\t\tInstructions:\nUnscramble the letters to form a word \nin the traditional snake way!\n");
    }
}
