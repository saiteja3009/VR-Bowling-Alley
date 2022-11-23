// using System.Collections;
// using System.Collections.Generic;
// // using UnityEngine;
// using System;
// using System.Globalization;
// using System.IO;
// // using UnityEngine.UI;
// public class Test
// {
//     //public Text[] scores;
//     public static string filepath=Application.persistantDataPath+ "/Scores.txt";
//     public void Save()
//     {
//         CreateFile();
//         WriteFile();
//     }
//     private void WriteFile()
//     {
//         using (StreamWriter writer = new StreamWriter(filepath))
//         {
//             writer.WriteLine(Tscore.ToString());
//         }
//     }
//      private void CreateFile()
//     {
//       if(!File.Exists(filepath))
//         {
//             File.Create(filepath).Close();
//         }
//     }
    
    
//     public static List<int> ReadFile()
//     {
//         using (StreamReader reader = new StreamReader(filepath))
//         {

//             List<int> numbers = new List<int>();

//             while (true)
//             {
//                 string FindMax = reader.ReadLine();
//                 if (FindMax == null)
//                 {
//                     break;
//                 }
//                 int test;
//                 if (Int32.TryParse(FindMax, out test))
//                 {
//                     numbers.Add(test);
//                 }
//             }
//             // Console.WriteLine("the highest number is {0}", numbers.Max());
//             int len = numbers.Count;
//              List<int> num = new List<int>();
//             for (int i=len-10;i<len;i++)
//             {
//               num.Add(numbers[i]);
//             } 
//              num.Sort((a, b) => b.CompareTo(a));
//             return num;
//         }
//     }
//     public static void Main(string[] ars){
//         Console.WriteLine("uusuusususus");
//         List<int> numbers = new List<int>();
//         numbers = ReadFile();
//         for(int i=0;i<numbers.Count;i++)
//         {
//             Console.WriteLine(i+" "+numbers[i].ToString());
//            // scores[i].text=numbers[i].ToString();
//         }
//     }
//     // void Start()
//     // {
//     //     List<int> numbers = new List<int>();
//     //     numbers = ReadFile();
//     //     for(int i=0;i<numbers.Count;i++)
//     //     {
//     //         Debug.Log(i);
//     //         scores[i].text=numbers[i].ToString();
//     //     }

//     // }

//     // // Update is called once per frame
//     // void Update()
//     // {
        
//     // }
// }
