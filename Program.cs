using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static string Task1(string input)
        {
            string[] words = input.Split(' ');
            string output = words[1] + " " + words[0];
            return output;
        }

        static string Task2(int [] arr)
        {
            arr = arr.Distinct().ToArray();
            string output = "None";
            int diff = Math.Abs(arr[0]);
            int index = 0;
            int count = 0;
            for(int i=0; i<arr.Length;i++)
            {
                if(Math.Abs(arr[i])<=diff && index !=i)
                {
                    if(Math.Abs(arr[i]) == diff)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    diff = Math.Abs(arr[i]);
                    index = i;
                }
            }
            if(count>0)
            {
                output = "None";
            }
            else
            {
                output = arr[index].ToString();
            }
            
            return output;
        }

        static int[] Task3(string [] input)
        {
            int sum = 0;
            int[] output = new int[input.Length];
            for(int i=0;i<input.Length;i++)
            {
                for(int j=0;j<input[i].Length;j++)
                {
                    if ((int)input[i][j] > 96 && (int)input[i][j] < 122)
                    {
                        sum += ((int)input[i][j] - 96) * (i + 1);
                    }
                }
                output[i] = sum;
                sum = 0;
            }

            return output;
        }

        static bool Task4(string input)
        {
            bool result = true;
            for(int i=0;i<input.Length;i++)
            {
                for(int j=i;j<input.Length;j++)
                {
                    if(input[i]==input[j] && i!=j)
                    {
                        result = false;
                        break;
                    }
                }
                if (result == false)
                    break;

            }
            return result;
        } 

        static int Task5(int[]input)
        {
            int result = 0;
            int max = input.Max();
            int min = input.Min();
            foreach(int elem in input)
            {
                if(elem!=max && elem!=min)
                {
                    result = input.ToList().IndexOf(elem);
                }
            }
            return result;
        }

        static int[] Task6(int [] input)
        {
            int[] age = new int[2];
            age[0] = (input[0] + input[1]) / 2;
            age[1] = input[0] - age[0];
            return age;
        }

        static string Task7(string input)
        {
            string result = "";
            foreach(char letter in input)
            {
                result += letter.ToString()+ letter.ToString();
            }
            return result;
        }

        static int[] Task8(string input)
        {
            List<int> indexes = new List<int>();
            for(int i=0; i<input.Length;i++)
            {
                if(char.IsUpper(input[i]))
                {
                    indexes.Add(i-1);
                }
            }

            return indexes.ToArray();
        }

        static string task9(string input)
        {
            string result = "";
            string[] words = input.Split(' ');
            foreach(string word in words)
            {
                 for(int i=word.Length-1;i>=0;i--)
                {
                    result += word[i];
                }
                result += " ";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        static string task10(string input)
        {
            string result="";
            for (int i=0;i<input.Length;i++)
            {
                int buffer;  //for shifting letters and capitalization
                if(i%2==0)
                {
                    buffer = 1; //UpperCase
                }
                else
                {
                    buffer = 33; // LowerCase
                }
                if ((int)input[i] == 90) //if Z
                {
                    result += Convert.ToChar(64+buffer); //A
                }
                else if ((int)input[i] > 65 && (int)input[i] < 90)
                {
                    result += Convert.ToChar((int)input[i] + buffer); // rest letters
                }
                else if ((int)input[i] >= 48 && (int)input[i] <= 57) //case of numbers
                {
                    int number = input[i] - 48;    
                    int newNumber = 9 - number;       //turning numbers 
                    result += newNumber;
                }
                else    //other(spcases,signs)
                {
                    result += input[i];
                }
            }
            string passphrase = "";
            for(int i=result.Length-1;i>=0;i--) // reversing
            {
                passphrase += result[i];
            }
            return passphrase;
        }

        static void Main1(string[] args)
        {

            Console.WriteLine("Hello!");
            Console.ReadLine();

            //Task1
            //string person = task1("John Surname");
            //Console.WriteLine(person);
            //Console.ReadLine();

            //Task2
            int[] arr = new int[] { 2, 4, -2, -3 };
            //int[] arr = new int[] { 13, 0, -6 };
            string task2_arr = Task2(arr);
            Console.WriteLine(task2_arr);
            Console.ReadLine();

            //Task3
            //string[] arr3 = new string[] { "abc", "abc abc" };
            //int[] output = task3(arr3);
            //for (int i = 0; i < output.Length; i++)
            //{
            //    Console.WriteLine(output[i]);
            //}
            //Console.ReadLine();

            ////Task4
            //string isogram = "Dermatoglyphics";
            //Console.WriteLine(task4(isogram));
            //Console.ReadLine();


            //Task5
            // int[] arr = new int[] { 2, 3, 1 };
            //// int[] arr = new int[] { 5, 10, 14 };
            // int task5_arr = task5(arr);
            // Console.WriteLine(task5_arr);
            // Console.ReadLine();

            //Task6
            //int[] input = new int[] { 32, 2 };
            //Console.WriteLine(task6(input)[0]+","+task6(input)[1]);
            //Console.ReadLine();

            //Task7
            //string input = "Hello World";
            //Console.WriteLine(task7(input));
            //Console.ReadLine();

            //Task8
            //string input = "'CodEWaRs";
            //int[] indexes = task8(input);
            //for (int i=0;i< indexes.Length;i++)
            //{
            //    Console.Write(indexes[i]+", ");
            //}
            //Console.WriteLine();
            //Console.ReadLine();


            //Task9
            //string input = "An example!";
            //Console.WriteLine(task9(input));
            //Console.ReadLine();

            //Task10
            //string input = "BORN IN 2015!";
            //Console.WriteLine(task10(input));
            //Console.ReadLine();

        }

    }
}

public class DemoClass
{
    private int _privateField;
    public string PublicField = "None";
    public int LimitedProperty { get; private set; }
    
    public DemoClass(int value)
    {
        _privateField = value;
    }
 
}

public class PagnationHelper<T>
{
    // TODO: Complete this class

    private IList<T> _collection;
    private int _itemsPerPage;
    /// <summary>
    /// Constructor, takes in a list of items and the number of items that fit within a single page
    /// </summary>
    /// <param name="collection">A list of items</param>
    /// <param name="itemsPerPage">The number of items that fit within a single page</param>
    public PagnationHelper(IList<T> collection, int itemsPerPage)
    {
        _collection = collection;
        _itemsPerPage = itemsPerPage;
    }

    /// <summary>
    /// The number of items within the collection
    /// </summary>
    public int ItemCount
    {
        get
        {
            return _collection.Count;
        }
    }

    /// <summary>
    /// The number of pages
    /// </summary>
    public int PageCount
    {
        get
        {
            int pages = (int)Math.Ceiling((double)ItemCount / _itemsPerPage);
            return pages;
        }
    }

    /// <summary>
    /// Returns the number of items in the page at the given page index 
    /// </summary>
    /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
    /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
    public int PageItemCount(int pageIndex)
    {
        if (pageIndex < 0 || pageIndex >= PageCount - 1)
            return -1;
        else if (pageIndex < PageCount-1)
            return _itemsPerPage;
        else
        {
            return ItemCount - (PageCount) * _itemsPerPage;
        }


    }

    /// <summary>
    /// Returns the page index of the page containing the item at the given item index.
    /// </summary>
    /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
    /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
    public int PageIndex(int itemIndex)
    {
        int res = (int)Math.Floor((double)itemIndex / _itemsPerPage);
        if (res >= PageCount || itemIndex >= ItemCount  || itemIndex <0)
            return -1;
        else
            return res;
    }
}

public class Fighter
{
    public string Name;
    public int Health, DamagePerAttack;
    public Fighter(string name, int health, int damagePerAttack)
    {
        this.Name = name;
        this.Health = health;
        this.DamagePerAttack = damagePerAttack;
    }
}

public class Kata
{
    public string declareWinner(Fighter fighter1, Fighter fighter2, string firstAttacker)
    {
        // Your code goes here. Have fun!
        
        if(firstAttacker.Equals(fighter1.Name))
        {
            while (!gameOver(fighter1, fighter2))
            {
                hit(fighter1, fighter2);
                if (gameOver(fighter1, fighter2))
                    break;
                hit(fighter2, fighter1);
                if (gameOver(fighter1, fighter2))
                    break;
            }
        }
        else
        {
            while (!gameOver(fighter1, fighter2))
            {
                hit(fighter2, fighter1);
                if (gameOver(fighter1, fighter2))
                    break;
                hit(fighter1, fighter2);
                if (gameOver(fighter1, fighter2))
                    break;
            }
        }
        return winnerName(fighter1,fighter2);

    }

    private bool gameOver(Fighter fighter1, Fighter fighter2)
    {
        if (fighter1.Health <= 0 || fighter2.Health <= 0)
        {
            return true;
        }
        else
            return false;
    }

    private string winnerName(Fighter fighter1, Fighter fighter2)
    {
        if (fighter1.Health <= 0)
        {
            return fighter2.Name;
        }
        else
            return fighter1.Name;
    }

    private void hit(Fighter fighter1, Fighter fighter2)
    {
        fighter2.Health -= fighter1.DamagePerAttack;
    }
}


public interface ITree
{
    void GrowTrunk();
    void GrowBranches();
    void NewBranch();
    void Ouch(int n);
    string Description();
}

public class Branch
{
    public int level;
    public int length;
    public Branch(int birthLevel)
    {
        level = birthLevel;
        length = 1;
    }
    public void grow()
    {
        length++;
    }
}

public class Tree : ITree
{
    public int trunk;
    public List<Branch> branches;
    
    public Tree()
    {
        trunk = 1;
        branches = new List<Branch>();
    }

    public void GrowTrunk()
    {
        trunk += 1;
    }
    public void GrowBranches()
    {
        if (branches.Count>0)
        {
            foreach (Branch branch in branches)
            {
                branch.grow();
            }
        }
        
    }
    public void NewBranch()
    {
        branches.Add(new Branch(trunk));
    }
    public void Ouch(int n)
    {
        if (branches.Count > 0)
        {
            if (n > 0 && n < branches.Count)
            {
                branches.RemoveAt(n-1);
            }
        }
    }
    public string Description()
    {
        string descript = "";
        if (branches.Count > 0)
        {
            descript = "The tree trunk is " + trunk + " unit(s)tall! There are " + branches.Count + " branch(es) that have position(s): ";
            for (int i = 0; i < branches.Count; i++)
            {
                descript += branches[i].level;
                if (i != branches.Count-1)
                    descript += ",";
            }         
            descript+=" and length(s): ";
            for (int i = 0; i < branches.Count; i++)
            {
                descript += branches[i].length;
                if (i != branches.Count-1)
                    descript += ",";
                else
                    descript += "!";
            }
        }
        else
        {
            descript = "The tree trunk is " + trunk + " unit(s) tall! There are 0 branch(es)!";
        }
        return descript;
    }

}


