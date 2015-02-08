using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour
{

    public GameObject Food;
    private int food;
    public GameObject Piece;
    private GameObject lastPiece;
    public int Lives=3;
	private int countfood;
    public bool ShowHigh;
	public int flag=1;
	public int level=0;
	public float t=0;
	private int countflag=0;
	private char[] str={'A','P','E','A','L'};
	private int[] flags={1,2,3,4,5};
	private int checkflag=0;
	private string checkstr="";
	//1 for top
	//2 for right
	//3 for bottom
	//4 for left
    // Use this for initialization
    void Start()
    {
		checkflag=0;
		//print (Lives);
        ShowHigh = false;
		countfood = 0;
		 int i = 0;
		while(i<5)
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
        if (PlayerPrefs.GetInt("Lives") <= 0)
        {
            PlayerPrefs.SetInt("Lives", 3);
        }
        Lives = PlayerPrefs.GetInt("Lives");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 0.066f));
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

       // if (Time.time % 10 < 0.05)
         //   placeFood();
    }

    private void placeFood()
    {
		var rotation=Quaternion.identity;
		rotation.eulerAngles=new Vector3(90,0,0);
        var food = Instantiate(Food, new Vector3(Random.Range(-20, 10), 2.2f, Random.Range(-20, 10)), rotation);
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
		for(i=0;i<5;i++)
		{
        if (col.gameObject.name == "Food"+i)
        {
            food++;
            addPiece();
			TextMesh tm = new TextMesh();
			tm = (TextMesh)GameObject.Find("Food"+i).GetComponent("TextMesh");
    		checkstr+=tm.text;
			int j;
            for(j=0;j<checkstr.Length;j++)
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

        lastPiece = newPiece;
    }

    void OnGUI()
    {
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
            GUILayout.Label(PlayerPrefs.GetInt("Food") + " Food");
        }
        if (Lives < 1)
        {
            transform.position = new Vector3(0, -100, 0);
            GUILayout.Label("GAME OVER");
			t=Mathf.Round(Time.timeSinceLevelLoad*100)/100;
			GUILayout.Label("Time:" + t);
			//level++;
			//Application.LoadLevel(level);
        }
		if(countfood == 0)
		{
				
          	GUILayout.Label("Congratulations !! You Win !!");
		//	t=Mathf.Round(Time.timeSinceLevelLoad*100)/100;
			GUILayout.Label("Time:" + t);
			transform.position = new Vector3(0, -100, 0);
			//Application.Quit();
			level++;
			Application.LoadLevel(level);
		}
        if (GUILayout.Button("Start again"))
        {
            Application.LoadLevel(Application.loadedLevel);
            PlayerPrefs.SetInt("Lives", 3);
        }
        else
        {
            GUILayout.Label("Food:" + food);
			GUILayout.Label("Count Food:" + countfood);
			GUILayout.Label("Lives:" + Lives);
            GUILayout.Label("Time:" + Mathf.Round(Time.timeSinceLevelLoad*100)/100);
            if (food>PlayerPrefs.GetInt("Food"))
            {
              PlayerPrefs.SetInt("Food", food);   
            }
        }
    }
}
