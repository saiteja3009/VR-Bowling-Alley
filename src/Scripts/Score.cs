using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{   
    public Text[] turn;
    public GameObject ball;
    int score = 0;
    int k=0;
    int turnCounter = 0;
    bool strike=false;
    int tenthscore=0;
    int twscore=0;
    GameObject[] pins;
    string filepath;
    
    // public int Tscore=0;
    int Tscore=0;
    //public Text scoreUI;
    Vector3[] positions;
    public Text total_score;
    //public HighScore highScore;
    int check=0;
    public GameObject menu;
    bool flag=false;
    
    public void Save()
    {
        CreateFile();
        WriteFile();
    }
    
    // public void Highest()
    // {
    //     List<int> numbers = new List<int>();
    //     numbers = ReadFile();
    //     Debug.Log(numbers[0]);
    // }
    private void CreateFile()
    {
      if(!File.Exists(filepath))
        {
            File.Create(filepath).Close();
        }
    }
    // private List<int> ReadFile()
    // {
    //     using (StreamReader reader = new StreamReader(filepath))
    //     {

    //         List<int> numbers = new List<int>();

    //         while (true)
    //         {
    //             string FindMax = reader.ReadLine();
    //             if (FindMax == null)
    //             {
    //                 break;
    //             }
    //             int test;
    //             if (Int32.TryParse(FindMax, out test))
    //             {
    //                 numbers.Add(test);
    //             }
    //         }
    //         // Console.WriteLine("the highest number is {0}", numbers.Max());
    //         int len = numbers.Count;
    //          List<int> num = new List<int>();
    //         for (int i=len-10;i<len;i++)
    //         {
    //           num.Add(numbers[i]);
    //         } 
    //          num.Sort((a, b) => b.CompareTo(a));
    //         return num;
    //     }
    // }
    private void WriteFile()
    {
        using (StreamWriter writer = File.AppendText(filepath))
        {
            writer.WriteLine(Tscore.ToString());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ball.transform.position = new Vector3(5.72f, 0.978f, -2.148f);
        filepath= Application.persistentDataPath +"/Scores.txt";
    
        Debug.Log(Application.persistentDataPath);
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length];

        for (int i = 0; i < pins.Length; i++){
            Debug.Log("i= "+i);
            positions[i] = pins[i].transform.position;
            Debug.Log(pins[i].transform.localEulerAngles.z+"tt");
        }
        Debug.Log("Turn len = "+turn.Length);
    }

    // Update is called once per frame
    void Update()
    {   
        // Debug.Log(check+"check");
        // check++;
        if(ball.transform.position.x > 0 && ball.transform.position.x < 4){
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
        }
        if((ball.transform.position.x < -6.4f || ball.transform.position.y<0.4) && flag==false){
            Debug.Log(flag+"flag1");
            flag=true;
            Debug.Log(flag+"flag2");
            Debug.Log(ball.transform.position.x +"Posi");
            CountPinsDown();
            turnCounter++;
            if(strike==true)
                {
                    turnCounter++;
                    strike=false;
                }
            Debug.Log(turnCounter);
            if(turnCounter%2==0)
                {
                ResetPins();
                twscore=0;
                }
            ResetBall();
            if((turnCounter==20 && tenthscore<10)||(turnCounter>20)){
                if(k==20)
                    turn[k].text="-";
                //close game
                Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            Debug.Log(turnCounter+"sserhrh");
            // if(turnCounter%2 == 0)
            //     ResetPins();
            // ResetBall();
            Debug.Log(flag+"flag3");
            flag=false;
            Debug.Log(flag+"flag4");
            // if(turnCounter == 20 || turnCounter == 21){
            //     Save();
            //     menu.SetActive(true);
            // }
        }
    }

    // void OnTriggerEnter(Collider other){
    //     if(other.gameObject.name=="LeftGutter" || other.gameObject.name=="RightGutter" || other.gameObject.name== "pins"){
    //         CountPinsDown();
    //         turnCounter++;
    //         ResetPins();
    //         if(turnCounter == 10){
    //             menu.SetActive(true);
    //         }
    //     }
    // }

    void CountPinsDown(){
        // Debug.Log("I am Here");
        for (int i = 0; i < pins.Length; i++)
        {
            // Debug.Log("sss"+i.ToString());
            if(pins[i].activeSelf && (pins[i].transform.localEulerAngles.z>1 || pins[i].transform.localEulerAngles.z<-0.5f)){
                score++;
                pins[i].SetActive(false);
            }
        }
        Debug.Log("k = "+ k.ToString());
        // Debug.Log("Turn len check 2= "+turn.Length);
        // turn[k].text = score.ToString();
        // Tscore+=score;
        // total_score.text=Tscore.ToString();
        twscore+=score;
        if(k==18 || k==19){
            tenthscore+=score;
        }
        if(score==10){
            turn[k].text="X";
            Tscore+=score+10;
            strike=true;
            k++;
            turn[k].text="-";
        }
        else if(twscore==10){
            turn[k].text="/";
            Tscore+=score+5;
        }
        else
        {turn[k].text=score.ToString();    
        Tscore+=score;
        // scoreUI.text=Tscore.ToString();
        }
        total_score.text=Tscore.ToString();
        Debug.Log("Total score:"+Tscore);
        //scoreUI.text = Tscore.ToString();
        score=0;
        k++;
        Debug.Log(turnCounter.ToString() +","+ score.ToString());
        // if(score > highScore.highScore){
        //     highScore.highScore = score;
        // }

    }

    void ResetPins(){
        for (int i = 0; i < pins.Length; i++){
            pins[i].SetActive(true);
            pins[i].transform.position = positions[i];
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.rotation = Quaternion.identity;
        }
    }

    void ResetBall(){
        ball.transform.position = new Vector3(5.72f, 0.978f, -2.148f);
        //ball.transform.position = new Vector3(3.73f, 1.16f, 0.39f);
        Debug.Log("Ball rsest");
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;
    }
}   


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using System.Threading;
// using System;
// using System.Threading.Tasks;

// public class Score : MonoBehaviour
// {   
//     public Transform originalpin;
//     public GameObject ball;
//     int score=0;
//     GameObject[] pins;
//     public Text scoreUI;
//     int twscore=0;
//     public int Tscore=0;
//     public Text[] turn;
//     bool strike=false;
//     int tenthscore=0;
//     int turnCount=0;
//     int k=0;
//     Vector3[] positions;
//     float rotationResetSpeed = 1.0f;
//     List<int> num;

//     //public HighScore highscore;

//     // Start is called before the first frame update
//     void Start()
//     {
//      pins=GameObject.FindGameObjectsWithTag("Pin"); 
//      //sco=Text.FindGameObjectsWithTag("ScoreCard");
//      positions=new Vector3[pins.Length];
//      //turn=new Text[21];
//      for(int i=0;i<pins.Length;i++){
//          positions[i]=pins[i].transform.position;
//      } 
//      originalpin=pins[0].transform; 
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(ball.transform.position.z>1.2f){
//             //Task.Delay(new TimeSpan(0, 0, 30)).ContinueWith(o => { CountPinsDown(); });
//             // await Task.Delay(TimeSpan.FromSeconds(3));
//             CountPinsDown();
//             turnCount++;
//             if(strike==true)
//                 {
//                     turnCount++;
//                     strike=false;
//                 }
//             Debug.Log(turnCount);
//             if(turnCount%2==0)
//                 {
//                 ResetPins();
//                 twscore=0;
//                 }
//             ResetBall();
//             if((turnCount==21 && tenthscore<10)||(turnCount>21)){
//                 if(k==20)
//                     turn[k].text="-";
//                 //close game
//             }
//         }
//     }
//     void CountPinsDown(){
//         //Thread.Sleep(3000);
//         for(int i=0;i<pins.Length;i++){
//             Debug.Log(pins[i].transform.localEulerAngles.z);
//             if(pins[i].activeSelf && (pins[i].transform.localEulerAngles.z>271 || pins[i].transform.localEulerAngles.z<270)){
//                 //Debug.Log(pins[i].transform.localEulerAngles.z);
//                 score++;
//                 pins[i].SetActive(false);
//             }
//         }
//         twscore+=score;
//         if(k==18 || k==19){
//             tenthscore+=score;
//         }
//         if(score==10){
//             turn[k].text="X";
//             Tscore+=score+10;
//             strike=true;
//             k++;
//             turn[k].text="-";
//         }
//         else if(twscore==10){
//             turn[k].text="/";
//             Tscore+=score+5;
//         }
//         else
//         {turn[k].text=score.ToString();    
//         Tscore+=score;
//         scoreUI.text=Tscore.ToString();
//         }
//         score=0;
//         k++;
//         // if(score>highScore.highScore){
//         //     highScore.highScore=score;
//         // }
//         // Debug.Log(highScore.highScore);

//     }
//     void ResetPins(){
//         for(int i=0;i<pins.Length;i++){
//             pins[i].SetActive(true);
//             pins[i].transform.position=positions[i];
//             //to remove the physics after a throw
//             pins[i].GetComponent<Rigidbody>().velocity=Vector3.zero;
//             pins[i].GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
//             pins[i].transform.rotation = Quaternion.Slerp(pins[i].transform.rotation, originalpin.rotation, Time.time * rotationResetSpeed);
//             //pins[i].transform.rotation.z=-90;
//         }
//     }
//     void ResetBall(){
//         //initial ball position
//         ball.transform.position=new Vector3(1.51f,0.442f,-18.85f);
//         ball.GetComponent<Rigidbody>().velocity=Vector3.zero;
//         ball.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
//         ball.transform.rotation=Quaternion.identity;
//     }
//     //scriptable object for storing high score as persistant data

// }