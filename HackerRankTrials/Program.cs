using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//author@RhinoCoder & teatone.
static class HackerRankTrials
{


    static void Main()
    {
        //Call Your Method Between WriteLine and ReadKey.
        Console.WriteLine("Working.......");



        Console.ReadKey();

    }




    #region Day 0-Mean-Median-and-Mode
    public static void MeanMedianMode()
    {

        //Uncomment these to make it work in HackerRank.
        //***********************************************
        //int inputLength = int.Parse(Console.ReadLine());
        //string inputtedNumbers = Console.ReadLine();
        //int[] enteredNumbers = inputtedNumbers.Split(' ').Select(int.Parse).ToArray();
        //***********************************************


        float median = 0f;
        float mean = 0f;
        float sum = 0f;
        int mode = 0;


        //This place is for local input work. Can be deleted.
        int inputLength = 2500;
        string inputtedNumbers = "19325 74348 68955 98497 26622 32516 97390 64601 64410 10205 5173 25044 23966 60492 71098 13852 27371 40577 74997 42548 95799 26783 51505 25284 49987 99134 33865 25198 24497 19837 53534 44961 93979 76075 57999 93564 71865 90141 5736 54600 58914 72031 78758 30015 21729 57992 35083 33079 6932 96145 73623 55226 18447 15526 41033 46267 52486 64081 3705 51675 97470 64777 31060 90341 55108 77695 16588 64492 21642 56200 48312 5279 15252 20428";

        int[] enteredNumbers = inputtedNumbers.Split(' ').Select(int.Parse).ToArray();

        for (int i = 0; i < enteredNumbers.Length; i++)
        {
            sum += enteredNumbers[i];
        }

        enteredNumbers = enteredNumbers.OrderByDescending(c => c).ToArray();
        int middleOfArray = (enteredNumbers.Length / 2);


        if (enteredNumbers.Length % 2 == 0)
        {
            median = (enteredNumbers[middleOfArray] + enteredNumbers[middleOfArray - 1]) / 2f;
        }
        else
        {
            median = enteredNumbers[middleOfArray];
        }

        mean = (sum / enteredNumbers.Length);

        var grouped = enteredNumbers.GroupBy(n => n)
        .Select(g => new { Value = g.Key, Count = g.Count() })
        .OrderByDescending(g => g.Count)
        .ToList();
        int maxCount = 0;

        maxCount = grouped.Max(g => g.Count);
        Console.WriteLine("max count: " + maxCount);

        if (maxCount == 1)
        {
            mode = enteredNumbers.Min();
            Console.WriteLine("Its one");
        }
        else
        {
            var modes = grouped.Where(g => g.Count == maxCount).Select(g => g.Value).ToList();
            mode = modes.Min();
        }

        Console.WriteLine(mean);
        Console.WriteLine(median);
        Console.WriteLine(mode);


    }

    #endregion
    #region Day0-Weighted-Mean

    /*
    * Complete the 'weightedMean' function below.
    *
    * The function accepts following parameters:
    *  1. INTEGER_ARRAY X
    *  2. INTEGER_ARRAY W
    */

    public static void weightedMean(List<int> X, List<int> W)
    {
        float weightedSum = 0;
        float numbersInWeightVector = 0;

        for (int i = 0; i < X.Count; i++)
        {
            weightedSum += (X[i] * W[i]);
            numbersInWeightVector += W[i];
        }


        weightedSum = (weightedSum / numbersInWeightVector);
        Console.WriteLine(weightedSum.ToString("0.0"));

    }

    #endregion



    #region Valley-Counts
    public static int countingValleys()
    {
        //Just call the method to test.
        //You can change input for every case.
        //I tested the code for 100k and it works.
        int steps = 1000000;
        string path = "DUDUUUDUUUDDUDDUDUUDUDDUDDDUUUUUUDUDUDUDDUDDDUUUUUUDDUDUUUUUDUDUDDDUUDUDUDUDUUUUUUUUUUDUDDDDDDUDDDUDDDUDUUUUDDUUUD";
        path.Cast<char[]>();
        int currentHeight = 0;
        int lastSeenHeight = 1;
        int numOfValleys = 0;

        for (int i = 0; i < path.Length; i++)
        {


            switch (path[i])
            {

                case 'U':
                    currentHeight++;
                    break;

                case 'D':
                    currentHeight--;
                    break;


            }


            if (currentHeight == 0 && lastSeenHeight < 0)
            {
                numOfValleys++;
            }

            lastSeenHeight = currentHeight;

        }


        Console.WriteLine("Valleys: " + numOfValleys);


        return numOfValleys;
    }

}

#endregion
#region SubArray-Division
/*
     * Complete the 'birthday' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY s
     *  2. INTEGER d
     *  3. INTEGER m
     

public static int birthday(List<int> s, int d, int m)
{
    int count = 0;
    for (int i = 0; i < s.Count; i++)
    {
        int sum = 0;
        for (int j = i; j < m + i; j++)
        {
            if (j == s.Count) break;
            sum = sum + s[j];
        }

        if (sum == d)
        {
            count++;
        }
    }

    return count;

}

*/
#endregion
#region HackerRank-GradingStudents
/*
public static List<int> gradingStudents(List<int> grades)
{

    List<int> returningList = new List<int>();
    int addingAmount = 0;

    for (int i = 0; i < grades.Count; i++)
    {
        if (grades[i] < 38)
        {   
            Console.WriteLine("Failed");
        }

        else if ( (grades[i] + (5 - (grades[i] & 5)) - grades[i]) < 3 &&
            grades[i] >= 38)
        {
            addingAmount = 5 - (grades[i] % 5);
            returningList.Add(grades[i] + addingAmount);

        }


    }


    return returningList;


}
*/

#endregion
#region HackerRank-TimeConversion    
/*
    public static string timeConversion(string s)
    {

    string lastTwoPlaces = s.Substring(8);
    string answerTime = "empty";


    switch (lastTwoPlaces)
    {
        //12.00.00AM
        case "AM":

            long currentTimeHour = int.Parse(s.Substring(0, 2));

            if (currentTimeHour >= 12)
            {
                currentTimeHour -= 12;
                answerTime = "0" + currentTimeHour + s.Substring(2);
                Console.WriteLine(answerTime);
            }

            else
            {
                answerTime = "0" + currentTimeHour + s.Substring(2);
                Console.WriteLine("0" + currentTimeHour + s.Substring(2));

            }

            break;

        //"12:45:54PM"
        case "PM":
            long currentHour = int.Parse(s.Substring(0, 2));
            currentHour += 12;
            if (currentHour >= 24)
            {
                currentHour = 0;
                currentHour += 12;
                answerTime = currentHour + s.Substring(2);

            }
            else
            {
                answerTime = currentHour + s.Substring(2);
            }


            break;


    }



    string returningTime = answerTime.Substring(0, answerTime.Length - 2);
    Console.WriteLine(returningTime);
    return returningTime;
    }
    */
#endregion
#region Bill Division

///*
//     * Complete the 'bonAppetit' function below.
//     *
//     * The function accepts following parameters:
//     *  1. INTEGER_ARRAY bill
//     *  2. INTEGER k
//     *  3. INTEGER b
//     */

//public static void bonAppetit(List<int> bill, int k, int b)
//{
//    // K is index that anna did not eat.
//    // b is the amount of money that Anna contributed to the bill

//    int annaShouldPay = 0;

//    for (int i = 0; i < bill.Count; i++)
//    {
//        if (k != i)
//        {
//            annaShouldPay += bill[i];
//        }
//    }
//    annaShouldPay /= 2;

//    if (annaShouldPay == b)
//    {
//        Console.WriteLine("Bon Appetit");
//    }
//    else
//    {

//        Console.WriteLine((b - annaShouldPay));
//    }
//    //Console.WriteLine("Anna Total Cost: " + annaShouldPay);        
//}

//}

#endregion
#region Migratory-Birds

/*
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     

public static int migratoryBirds(List<int> arr)
{
    int[] birdTypeCounts = new int[5];

    for (int i = 0; i < arr.Count; i++)
    {
        birdTypeCounts[arr[i] - 1]++;
    }

    var maxBirdTypeCount = birdTypeCounts[0];
    var maxBirdType = 1;

    for (int i = 1; i < 5; i++)
    {
        if (birdTypeCounts[i] > maxBirdTypeCount)
        {
            maxBirdTypeCount = birdTypeCounts[i];
            maxBirdType = i + 1;
        }

        if (birdTypeCounts[i] == maxBirdTypeCount && i + 1 < maxBirdType)
        {
            maxBirdType = i + 1;
        }

    }

    Console.WriteLine(maxBirdType);
    return maxBirdType;

}
*/

#endregion
#region Breaking-The-Records
/*
     * Complete the 'breakingRecords' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY scores as parameter.
     

public static List<int> breakingRecords(List<int> scores)
{

    int maxExceedCount = 0;
    int minExceedCount = 0;
    int currentRecord = scores[0];
    int currentMinRecord = scores[0];
    List<int> returningList = new List<int>();

    for (int i = 0; i < scores.Count; i++)
    {
        if (scores[i] > currentRecord)
        {
            currentRecord = scores[i];
            maxExceedCount++;
        }

        if (scores[i] < currentMinRecord)
        {
            currentMinRecord = scores[i];
            minExceedCount++;
        }

    }

    Console.WriteLine("Max: " + maxExceedCount);
    Console.WriteLine("Min: " + minExceedCount);
    returningList.Add(maxExceedCount);
    returningList.Add(minExceedCount);
    return returningList;


}

*/
#endregion


//Some of methods may become obsolete, I will be updating them through my program solving journey.
//Thanks for your understanding.