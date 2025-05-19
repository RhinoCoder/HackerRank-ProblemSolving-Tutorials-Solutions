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
        //stdDev( );
        //
        Console.ReadKey();

    }




//APPENDIX A: 10 Days of Statistics Solutions
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
#region Day1-Quartiles
    ///
    //  Complete the 'quartiles' function below.
    //  The function is expected to return an INTEGER_ARRAY.
    //  The function accepts INTEGER_ARRAY arr as parameter.
    // 

    public static List<int> quartiles()
    {
        List<int> arr = new List<int>();
        arr.Add(3);
        arr.Add(7);
        arr.Add(8);
        arr.Add(5);
        arr.Add(12);
        arr.Add(14);
        arr.Add(21);
        arr.Add(15);
        arr.Add(18);
        arr.Add(14);
     

        arr.Sort();
        int q1 = 0;
        int q2 = 0;
        int q3 = 0;
        int median = 0;
        int midIndex = 0;

        List<int> lowerHalf = new List<int>();
        List<int> upperHalf = new List<int>();
        List<int> quartileList = new List<int>();
        midIndex = arr.Count / 2;

        if ((arr.Count) % 2 == 0)
        {

            median = ((arr[midIndex] + arr[midIndex - 1]) / 2);
            Console.WriteLine("Median appeared at even, Value: " + median);
        }
        else
        {
            median = arr[midIndex];
            Console.WriteLine("Median appeared at odd, Value: " + median);
        }

        q2 = median;



        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] < median)
            {
                lowerHalf.Add(arr[i]);
            }
            else if (arr[i] > median)
            {
                upperHalf.Add(arr[i]);
            }

        }



        //Debug purposes.    
        for (int i = 0; i < lowerHalf.Count; i++)
        {
            Console.WriteLine("Lower Half: " + lowerHalf[i]);
        }


        if (lowerHalf.Count % 2 == 0)
        {
            int _middleIndex = lowerHalf.Count / 2;
            q1 = ((lowerHalf[_middleIndex] + lowerHalf[_middleIndex - 1]) / 2);

        }
        else
        {
            int _middleIndex = (lowerHalf.Count / 2);
            q1 = (lowerHalf[_middleIndex]);
        }

        for (int j = 0; j < upperHalf.Count; j++)
        {
            Console.WriteLine("Higher Half: " + upperHalf[j]);
        }
        if (upperHalf.Count % 2 == 0)
        {
            int _middleIndex = upperHalf.Count / 2;
            q3 = ((upperHalf[_middleIndex] + upperHalf[_middleIndex - 1]) / 2);

        }
        else
        {
            int _middleIndex = upperHalf.Count / 2;
            q3 = (upperHalf[_middleIndex]);
        }


        Console.WriteLine("Lower Half Count :" + lowerHalf.Count);
        Console.WriteLine("Upper Half Count :" + upperHalf.Count);
        Console.WriteLine("Q1: " + q1);
        Console.WriteLine("Q2: " + q2);
        Console.WriteLine("Q3: " + q3);

        quartileList.Add(q1);
        quartileList.Add(q2);
        quartileList.Add(q3);


        return quartileList;
    }


    #endregion
#region Day1-Inter-Quartile-Range
    
     //* Complete the 'interQuartile' function below.
     //*
     //* The function accepts following parameters:
     //*  1. INTEGER_ARRAY values
     //*  2. INTEGER_ARRAY freqs
     

    public static void interQuartile()
    {
        //Input of this function to work locally. I omit parameters.
        //I include a one test case of the problem to verify the method.
        //values:10 40 30 50 20 10 40 30 50 20
        // 2 3 4 5 6 7 8 9 10
        List<int> values = new List<int>();
        values.Add(10);
        values.Add(40);
        values.Add(30);
        values.Add(50);
        values.Add(20);
        values.Add(10);
        values.Add(40);
        values.Add(30);
        values.Add(50);
        values.Add(20);

        List<int> freqs = new List<int>();
        freqs.Add(1);
        freqs.Add(2);
        freqs.Add(3);
        freqs.Add(4);
        freqs.Add(5);
        freqs.Add(6);
        freqs.Add(7);
        freqs.Add(8);
        freqs.Add(9);
        freqs.Add(10);


        // Print your answer to 1 decimal place within this function
        List<float> freqAddedList = new List<float>();
        List<float> lowerHalf = new List<float>();
        List<float> upperHalf = new List<float>();
        float q1 = 0f;
        float median = 0f;
        float q3 = 0f;
        float difference = 0.0f;



        int counter = 0;

        for (int i = 0; i < values.Count; i++)
        {

            for (int j = 0; j < freqs[i]; j++)
            {
                freqAddedList.Add(values[i]);
                counter++;              
               
            }
        }

        Console.WriteLine("Work Count: " + counter);
        freqAddedList.Sort();

   


        int _midIndex = (freqAddedList.Count) / 2;

        if (freqAddedList.Count % 2 == 0)
        {
            median = (freqAddedList[_midIndex] + freqAddedList[_midIndex - 1]) / 2;
        }
        else
        {
            median = (freqAddedList[_midIndex]);

        }

        for (int i = 0; i < freqAddedList.Count; i++)
        {
            if (i < _midIndex)
            {
                lowerHalf.Add(freqAddedList[i]);
            }
            else if (i > _midIndex)
            {
                upperHalf.Add(freqAddedList[i]);
            }

        }


        //Calculate Q1

        int mid1 = lowerHalf.Count / 2;

        if (lowerHalf.Count % 2 == 0)
        {
            q1 = ((lowerHalf[mid1] + lowerHalf[mid1 - 1]) / 2f);
        }
        else
        {
            q1 = lowerHalf[mid1];
        }

        //Calcualte Q3 

        int mid2 = upperHalf.Count / 2;

        if (upperHalf.Count % 2 == 0)
        {
            q3 = ((upperHalf[mid2] + upperHalf[mid2 - 1]) / 2f);
        }
        else
        {
            q3 = upperHalf[mid2];
        }

        difference = (q3 - q1);
        Console.WriteLine(difference.ToString("0.0"));

        //Debug Purposes.

        foreach (var it in freqAddedList)
        {
            //Console.WriteLine("val: " + it);
        }

        Console.WriteLine("Lower Count: " + lowerHalf.Count);
        Console.WriteLine("Upper Count: " + upperHalf.Count);
        Console.WriteLine("Median: " + median);
        Console.WriteLine("Q1: " + q1);
        Console.WriteLine("Q3: " + q3);


    }




    #endregion



    #region Day1-Standard-Deviation
    /*
     * Complete the 'stdDev' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void stdDev()
    {
        List<int> arr = new List<int>();
        int[] testInput = new int[] { 6392, 51608, 71247, 14271, 48327, 50618, 67435, 47029, 61857, 22987, 64858, 99745, 75504, 85464, 60482, 30320, 11342, 48808, 66882, 40522 };

        for(int i=0; i < testInput.Length; i++){arr.Add(testInput[i]);}
 
        double mean = 0.0f;
        double totalDifference = 0.0f; 
       
        for(int i=0; i < arr.Count; i++){mean += arr[i];}
        mean /= arr.Count;
 
        for (int i = 0; i < arr.Count; i++)
        {
            totalDifference += (Math.Pow((arr[i] - mean), 2)); 
        }
 
        totalDifference /= arr.Count;
        double result = Math.Sqrt(totalDifference); 
        Console.WriteLine("Mean: " + mean);
        Console.WriteLine(result.ToString("0.0"));
    }


    #endregion









    //Problem Solving Solutions.
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

//*Complete the 'birthday' function below.
//*
//* The function is expected to return an INTEGER.
//* The function accepts following parameters:
//*1.INTEGER_ARRAY s
//* 2.INTEGER d
//* 3.INTEGER m

/*
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