// using UnityEngine;
// using System.IO
// using System.Runtime.Serialization.Formatters.Binary;

// public static class Save_Scores
// {   public string filepath="Scores.txt"
//     public void Save(Player P)
//     {
//         CreateFile();
//         WriteFile(P);
//     }
//     public void Highest()
//     {
//         int val = ReadFile();
//         return val;

//     }
//     private void CreateFile()
//     {
//       if(!File.Exists(filepath))
//         {
//             File.Create(filepath).Close();
//         }
//     }
//     private int ReadFile()
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
//             Console.WriteLine("the highest number is {0}", numbers.Max());
//             return numbers.Max();
//         }
//     }
//     private void WriteFile(Player P)
//     {
//         using (StreamWriter writer = new StreamWriter(filepath))
//         {
//             writer.WriteLine(P.score.ToString());
//         }
//     }

// }
