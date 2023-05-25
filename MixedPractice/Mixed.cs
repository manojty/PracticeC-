
using System;
using System.Collections.Generic;
using System.Collections;

namespace PracticeC_
{

    public class CircularQ
    {
        public const int size = 8;
        public int[] q = new int[size];
        public int start = -1;
        public int end = -1;
        public int enqueue(int value)
        {
            if ((start == -1) && (end == -1))
            {
                start = 0;
                end = 0;
                q[end] =  value;
            }
            else if (((end + 1) % size) != start)
            {
                q[((end + 1) % size)] = value;
                end = ((end + 1) % size);
            }
            else
            {
                Console.WriteLine("Queue is full");
                return 0;
            }
            return 1;
        }

        public int dequeue()
        {
            if ((start == -1) && (end == -1))
            {
               Console.WriteLine("queue is empty");
               return 0;
            }

            if (start != end)
            {
                int val = q[start];
                q[start] = 0;
                start = (start + 1) % size;
                return val;
            }
            else
            {
                int val = q[start];
                q[start] = 0;
                start = -1;
                end = -1;
                return val;
            }
        }

    }
    
    public class ListNode
    {
        public int item;
        public ListNode next;
    }

    public class Mixed
    {

        public static int CountNoOfGames(int totalScore, int score1, int score2, int score3, Dictionary<int,int> dict)
        {

        }
        
        
        public static void TowerOfHanoi2(int rings, char from, char to, char use)
        {
            if (rings == 1)
            {
                Console.WriteLine("Move ring from " + from + " to " + to );
                return;
            }
            TowerOfHanoi2(rings - 1, from, use, to);
            Console.WriteLine("Move ring from " + from + " to " + to );
            TowerOfHanoi2(rings -1 , use, to, from);
        }
    
        public static int FindKth(List<int> list, int k)
        {
            int start = 0;
            int end = list.Count - 1;
            k = end - k + 1;
            int kth = list[k];
            while (true)
            {
                while (start < end)
                {
                    while (kth > list[start] && start < end)
                    {
                        start++;
                    }
                    while(kth < list[end] && start < end)
                    {
                        end--;
                    }
                    if (start < end)
                    {
                        (list[start], list[end]) = (list[end], list[start]);
                    }
                }
                //start = start;
                if (start == k)
                {
                    kth = list[k];
                    break;
                }
                else if (start > k)
                {
                    end = start -1;
                    start = 0;
                    kth = list[k];
                }
                else
                {
                    end = k;
                    kth = list[k];
                }
            }
            return kth;        
        }

        public static ListNode mergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode head = null;

            if (list1.item < list2.item)
            {
                head = list1;
                list1 = list1.next;
            }
            else
            {
                head = list2;
                list2 = list2.next;
            }
            
            
            ListNode currNode = head;

            while (list1 != null && list2 !=null)
            {
                if (list1.item < list2.item)
                {
                    currNode.next =  list1;
                    list1 = list1.next;
                }
                else
                {
                    currNode.next = list2;
                    list2 = list2.next;
                }
                currNode = currNode.next;
            }
            if (list1 == null)
            {
                currNode.next =  list2;
            }
            else
            {
                currNode.next = list1;
            }
            return head;
        }
        
        public static void transformArray(char[] arr, int size)
        {
            int noOfa = 0;
            int noOfb = 0;
            foreach(char c in arr)
            {
                if (c == 'a')
                {
                    noOfa++;
                }
                if (c == 'b')
                {
                    noOfb++;
                }
            }
            int expandedIndex = (size - 1) + noOfa -  noOfb; 
            for(int index =  size - 1; index >= 0; index--)
            {
                if (arr[index] == 'a')
                {
                    arr[expandedIndex--] = 'd';
                    arr[expandedIndex--] = 'd';
                }
                else if (arr[index] != 'b')
                {
                    arr[expandedIndex--] =  arr[index];
                }
            }
        }
       
        public static String convertBase(String str, int base1, int base2)
        {
            String result = "";
            int base1Num = 0;
            foreach(int digit in str)
            {
                base1Num = base1Num * base1 + digit - '0';
            }
            Console.WriteLine("Decimal representation of base1 number is " + base1Num);
            while (base1Num != 0)
            {
                result = base1Num % base2 + result;
                base1Num =  base1Num / base2;
            }
            return result;
        }


        public static int atoi(String str)
        {
            int res = 0;
            foreach(char digit in str)
            {
                int num = digit - '0';
                res = res*10 + num;
            }
            return res;
        }
        
        public static String itoa(int num)
        {
            String str = "";
            while (num != 0)
            {
                str = num % 10 + str;
                num = num / 10;
            }
            return str;
        }



        public static void printSpiral(List<List<int>> mat, int startRow, int startCol, int size)
        {

            if (size == 1)
            {
                Console.Write(mat[startRow][startCol] + " ");
                return;
            }
            
            if (size == 0)
            {
                return;
            }
            // Print top row
            for(int col = startCol; col < startCol + size - 1; col++)
            {
                Console.Write(mat[startRow][col] + " ");
            }
            // Print Right Column
            for(int row = startRow; row < startRow + size - 1; row++)
            {
                Console.Write(mat[row][startCol + size -1] + " ");
            }
            // Print Bottom Row
            for(int col = startCol + size - 1; col > startCol; col--)
            {
                Console.Write(mat[startRow + size - 1][col] + " ");
            }
            // Print Left Column
            for(int row = startRow + size - 1; row > startRow; row--)
            {
                Console.Write(mat[row][startCol] + " ");
            }

            startRow++;
            startCol++;
            size = size - 2;

            printSpiral(mat, startRow, startCol, size);

        }
        public static int buySell(List<int> lst)
        {
            int profit = 0;
            int diff = 0;
            int buyPrice =  lst[0];
            foreach(int price in lst)
            {
                diff = price - buyPrice;
                if (diff < 0)
                {
                    buyPrice = price;
                }
                else if (diff > profit)
                {
                    profit = diff;
                    Console.WriteLine("Running profit: " + profit);
                }
            }
            return profit;
        }
        
        public static void dutch(List<int> lst, int pivot)
        {
            int smaller = 0;
            int equal = 0;
            //int current = 0;
            int greater = lst.Count - 1;

            while (equal <= greater)
            {
                if (lst[equal] == pivot)
                {
                    equal++;
                }
                else if (lst[equal] < pivot)
                {
                    (lst[smaller],lst[equal]) = (lst[equal],lst[smaller]);
                    smaller++;
                    equal++;
                }
                else
                {
                    (lst[equal],lst[greater]) = (lst[greater],lst[equal]);
                    greater--;
                }
            }
        }
        
        public static int pow(int x, int y)
        {
            
            int multiple = x;
            int result = 1;;
            while (y != 0)
            {
                if ((y & 1) == 1)
                {
                    result *= multiple;
                }
                multiple *= multiple;
                y = y>>1;
            }
            return result;
        }


        public static bool getParity(ulong num )
        {
            bool isParity = false;
            ulong mask = 1;
            while (mask != 0)
            {
                if ((num & mask) != 0)
                {
                    isParity =  !isParity;
                }
                mask = mask<<1;
            }
            return isParity;
        }

        
        public static List<string> generate_all_expressions(string s, long target) 
        {
            // Write your code here.
            List<string> result = new List<string>();
            _generate_all_expressions(s, target, "", result);
            return result;
        }
    
        public static void _generate_all_expressions(string s, long target, string slate, List<string> result) 
        {
            // Write your code here.
            // Base condition
            if (s.Length == 0 )
            {
                if (target == getSlateValue(slate))
                {
                    result.Add(slate);
                }
            }
            else
            {
                string joinSlate = slate + s[0];
                _generate_all_expressions(s.Remove(0,1), target, joinSlate, result);
                if (slate.Length !=0)
                {
                    string productSlate = slate + "*" + s[0] ; 
                    _generate_all_expressions(s.Remove(0,1), target, productSlate, result);
                    string additionSlate = slate + "+" + s[0] ;
                    _generate_all_expressions(s.Remove(0,1), target, additionSlate, result);
                }
            }
        }
    
    public static long getSlateValue(string slate)
    {
        if (slate.Length == 0)
        {
            return 0;
        }

        List<string> operandList = new List<string>();
        List<string> operatorList = new List<string>();
        string operand = new string("");
        foreach(char c in slate)
        {
            if (c != '+' && c != '*')
            {
                operand += c;
            }
            else
            {
                operandList.Add(string.Copy(operand));
                operand = "";
                operatorList.Add(c.ToString());
            }
        } 
        if (operand.Length != 0)
        {
            operandList.Add(string.Copy(operand));
        }
        List<string> postfixExpression = new List<string>();
        postfixExpression.Add(operandList[0]);
        int operandListIndex = 1;
        foreach(string operatr in operatorList)
        {
            if (String.Equals(operatr,"*") && String.Equals(postfixExpression[postfixExpression.Count - 1],"+"))
            {
                postfixExpression[postfixExpression.Count - 1] = operandList[operandListIndex++];
                postfixExpression.Add(operatr);
                postfixExpression.Add("+");
            }
            else
            {
                postfixExpression.Add(operandList[operandListIndex++]);
                postfixExpression.Add(operatr);
            }
        }
        Stack<long> postfixEvaluator = new Stack<long>();
        foreach(string str in postfixExpression)
        {
            if (String.Equals(str,"+") || String.Equals(str,"*"))
            {
                long operand1 = postfixEvaluator.Pop();
                long operand2 = postfixEvaluator.Pop();
                if (String.Equals(str,"+"))
                {
                    postfixEvaluator.Push(operand1 + operand2);
                }
                else
                {
                    postfixEvaluator.Push(operand1 * operand2);
                }
            }
            else
            {
                postfixEvaluator.Push(long.Parse(str));
            }
        }
        return postfixEvaluator.Pop();
    }
    
    
    
    public static void PlaceQueens(int q)
    {
        List<List<int>> board = new List<List<int>>();
        for(int i = 0; i < q; i++)
        {
            board.Add(new List<int>());
            for(int j = 0; j < q; j++)
            {
                board[i].Add(0);
            }
        }

        PrintQBoard(board);
        
        List<List<List<int>>> result = new List<List<List<int>>>();
        
        _GetAllPlacementForQueens(q, board, result);
        
        foreach(List<List<int>> item in result)
        {
            PrintQBoard(item);
        }
        Console.WriteLine("Total Solutions: " + result.Count);
    } 
    
    public static List<List<int>> CloneBoard(List<List<int>> board)
    {
        List<List<int>> clone = new List<List<int>>();
        for(int i = 0; i < board[0].Count; i++)
        {
            clone.Add(new List<int>());
            for(int j = 0; j < board[0].Count; j++)
            {
                clone[i].Add(board[i][j]);
            }
        }
        return clone;
    }

    public static void _GetAllPlacementForQueens(int q, List<List<int>> board, List<List<List<int>>> result)
    {
        if (q == 0)
        {
            result.Add(CloneBoard(board));
        }
        else
        {
            int placementRow = board[0].Count - q;
            for(int col = 0; col < board[0].Count; col++)
            {
                if (IsValidPlacement(placementRow, col, board))
                {
                    board[placementRow][col] = placementRow + 1;
                    _GetAllPlacementForQueens(q-1, board, result);
                    board[placementRow][col] = 0;
                }
            }

        }
    }
    
    public static bool IsValidPlacement(int rowIndex, int colIndex, List<List<int>> board)
    {
        // Check for column
        foreach(List<int> row in board)
        {
            if (row[colIndex] != 0) 
            {
                return false;
            }
        }

/*        // Check for diagnal
        int size = board[0].Count;
        int topLeftRowIndex = rowIndex;
        int topLeftColIndex = colIndex;

        while (topLeftRowIndex >= 0 && topLeftColIndex >= 0)
        {
            if (board[topLeftRowIndex--][topLeftColIndex--] != 0)
            {
                return false;
            }
        }

        int topRightRowIndex = rowIndex;
        int topRightColIndex = colIndex;
        while (topRightRowIndex >= 0 && topRightColIndex < size )
        {
            if (board[topRightRowIndex--][topRightColIndex++] != 0)
            {
                return false;
            }
        }

        int bottomLeftRowIndex = rowIndex;
        int bottomLeftColIndex = colIndex;

        while (bottomLeftRowIndex < size && bottomLeftColIndex >= 0)
        {
            if (board[bottomLeftRowIndex++][bottomLeftColIndex--] != 0)
            {
                return false;
            }
        }

        int bottomRightRowIndex = rowIndex;
        int bottomRightColIndex = colIndex;
        while (bottomRightRowIndex < size && bottomRightColIndex < size )
        {
            if (board[bottomRightRowIndex++][bottomRightColIndex++] != 0)
            {
                return false;
            }
        }
*/
        // Optimized Diagonal check.
        for(int i = 0; i < rowIndex; i++)
        {
            for(int j = 0; j < board[0].Count; j++)
            {
                if ((board[i][j] != 0) && (Math.Abs(rowIndex -  i) == Math.Abs(colIndex - j)))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void PrintQBoard(List<List<int>> board)
    {
        foreach(List<int> row in board)
        {
            foreach(int item in row)
            {
                Console.Write(" " + item + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("============================================");
    }



    public static int[,] sudoku = 
    {
        {8, 4, 9, 0, 0, 3, 5, 7, 0},
        {0, 1, 0, 0, 0, 0, 0, 0, 0},
        {7, 0, 0, 0, 9, 0, 0, 8, 3},
        {0, 0, 0, 9, 4, 6, 7, 0, 0},
        {0, 8, 0, 0, 5, 0, 0, 4, 0},
        {0, 0, 6, 8, 7, 2, 0, 0, 0},
        {5, 7, 0, 0, 1, 0, 0, 0, 4},
        {0, 0, 0, 0, 0, 0, 0, 1, 0},
        {0, 2, 1, 7, 0, 0, 8, 6, 5}
    };
    
    public static bool SolveSudokuRecursive(int[,] sudoku)
    {
        // get next empty cell
        KeyValuePair<int, int> nextEmptyCell = new KeyValuePair<int,int>(-1,-1);
        for(int i=0; i < sudoku.GetLength(0); i++)
        {
            for(int j=0; j < sudoku.GetLength(1); j++)
            {
                if (sudoku[i,j] == 0)
                {
                    nextEmptyCell = new KeyValuePair<int,int>(i,j);
                    break;
                }
            }
            if (nextEmptyCell.Key != -1)
            {
                break;
            }
        }
        // if no empty cell then we have a solution.
        if (nextEmptyCell.Key == -1)
        {
            return true;
        }

        for(int num = 1; num<=9; num++)
        {
            if (CanIBePlacedAtThisCell(sudoku, num, nextEmptyCell))
            {
                sudoku[nextEmptyCell.Key, nextEmptyCell.Value] = num;
                if (SolveSudokuRecursive(sudoku))
                {
                    return true;
                }
                else
                {
                    sudoku[nextEmptyCell.Key, nextEmptyCell.Value] = 0;
                }
            }
        }
        return false;
    }
    public static void _SolveSudoku(int[,] sudoku)
    {
        bool IsSudokuFilled = false;
        while (!IsSudokuFilled)
        {
            // For each row get list of empty cells and possible values to be filled.
            // For each value, if it can only find one empty cell where it can be placed then place it.
            // Else move on to next row until there is no row with empty cells. Then exit the outer loop.
            IsSudokuFilled = true;
            for(int row = 0; row < sudoku.GetLength(0); row++)
            {
                List<KeyValuePair<int,int>> emptyCellsInRow = GetEmptyCellsOfRow(sudoku,row);
                if (emptyCellsInRow.Count != 0)
                {
                    IsSudokuFilled = false;
                }
                List<int> missingValueInRow = GetMissingValuesInRow(sudoku, row);
                foreach(int missingValue in missingValueInRow)
                {
                    int placingCounter = 0;
                    KeyValuePair<int,int> placingCell = new KeyValuePair<int,int>();
                    foreach(KeyValuePair<int,int> emptyCell in emptyCellsInRow)
                    {
                        if (CanIBePlacedAtThisCell(sudoku, missingValue, emptyCell))
                        {
                            placingCounter++;
                            placingCell = emptyCell;
                        }
                            
                    }
                    if (placingCounter == 1)
                    {
                        sudoku[placingCell.Key, placingCell.Value] = missingValue;
                    }
                }
            }

        }

    }
    
    public static void SolveSudoku(int[,] sudoku)
    {
        printCells(sudoku);
        //Non recursive
        //_SolveSudoku(sudoku);
        SolveSudokuRecursive(sudoku);
        printCells(sudoku);
    }
    
    public static List<int> GetMissingValuesInRow(int[,] sudoku, int rowIndex)
    {
        List<int> missingValue = new List<int>(){1,2,3,4,5,6,7,8,9};

        for(int col=0 ; col < sudoku.GetLength(1); col++)
        {
            missingValue.Remove(sudoku[rowIndex,col]);
        }
        return missingValue;
    }

    public static bool CanIBePlacedAtThisCell(int[,] sudoku, int num, KeyValuePair<int,int> cell)
    {
        // Check Row
        for(int col = 0; col < sudoku.GetLength(1); col++)
        {
            if (sudoku[cell.Key,col] == num)
            {
                return false;
            }
        }

        // Check Col
        for(int row = 0; row < sudoku.GetLength(0); row++)
        {
            if (sudoku[row,cell.Value] == num)
            {
                return false;
            }
        }

        // Check 3 X 3
        // Get Starting Row and Col of the 3 X 3
        int startingRow = 3*(cell.Key/3);
        int startingCol = 3*(cell.Value/3);
        for(int row = startingRow; row < startingRow + 3; row++)
        {
            for (int col = startingCol; col < startingCol + 3; col++)
            {
                if (sudoku[row,col] ==  num)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void printEmptyCells(int[,] sudoku)
    {
        for(int i = 0; i < sudoku.GetLength(0) ; i++)
        {
            
            List<KeyValuePair<int,int>> result = GetEmptyCellsOfRow(sudoku, i);
            foreach(KeyValuePair<int,int> item in result)
            {
                Console.Write(" " + item + " ");
            }
            Console.WriteLine();
        }
    }
    
    public static void printCells(int[,] sudoku)
    {
        int rowSum = 0;
        int[] colSum = new int[9];
        for(int i = 0; i < sudoku.GetLength(0) ; i++)
        {
            rowSum = 0;
            for(int j = 0; j < sudoku.GetLength(1); j++ )
            {
                rowSum += sudoku[i,j];
                colSum[j] += sudoku[i,j];
                Console.Write(" " + sudoku[i,j] + " ");
            }
            Console.Write("|| " + rowSum);
            Console.WriteLine();
        }
        Console.WriteLine("====================================");
        foreach(int item in colSum)
        {
            Console.Write(" " + item );
        }
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------");

    }
    
    public static List<KeyValuePair<int,int>> GetEmptyCellsOfRow(int[,] sudoku, int rowIndex)
    {
        List<KeyValuePair<int,int>> result = new List<KeyValuePair<int,int>>();
        for(int i = 0; i <  sudoku.GetLength(1); i++)
        {
            if (sudoku[rowIndex,i] ==  0)
            {
                result.Add(new KeyValuePair<int,int>(rowIndex,i));
            }
        }
        return result;
    }
    
    public static int HowManyBsts(int nodes)
    {
        int totalBst = 0;
        if (nodes == 0)
        {
            return 1;
        }
        if (nodes == 1 || nodes == 2)
        {
            return nodes;
        }
        
        for(int i = 1; i <= nodes; i++)
        {
            int leftBst = HowManyBsts(i-1);
            int rightBst = HowManyBsts(nodes - i);
            totalBst += leftBst * rightBst;
        }
        return totalBst;

    }
  
    
    
    public static List<string> PalindromicDecomposition(String s)
    {
        List<string> result = new List<string>();
        if (String.IsNullOrEmpty(s))
        {
            return result;
        }
        _PalindromicDecomposition(s.Remove(0,1), s.Substring(0,1), result);
        return result;
    }

    public static void _PalindromicDecomposition(String s, String slate, List<string> result)
    {
        if (s.Length == 0)
        {
            string lastStr = GetLastDecomposedString(slate);
            if (isPalindrome(lastStr))
            {
                result.Add(slate);
            }
            return;
        }
        string leftSlate = slate + s[0];
        _PalindromicDecomposition(s.Remove(0,1), leftSlate, result);
        string str = GetLastDecomposedString(slate);
        if (isPalindrome(str))
        {
            string rightSlate = slate + "|" + s[0];
            _PalindromicDecomposition(s.Remove(0,1), rightSlate, result);
        }
    } 

    public static string GetLastDecomposedString(string slate)
    {
        if (String.IsNullOrEmpty(slate))
        {
            return slate;
        }
        int lastIndexOfDelimiter = slate.LastIndexOf('|');
        return slate.Substring(lastIndexOfDelimiter + 1, slate.Length - (lastIndexOfDelimiter + 1));
    }

    public static List<string> easyPalindromSubstrings(String s)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < s.Length; i++)
        {
            for(int j = i; j < s.Length; j++)
            {
                string temp = s.Substring(i, j-i+1);
                if (isPalindrome(temp))
                {
                    result.Add(temp);
                }
            }
        }
        return result;
    }
    
    public static List<string> PalindromeSubstrings(String s)
    {
        List<string> allPalindromicSubStrings = new List<string>();
        Dictionary<string,bool> uniquePal = new Dictionary<string,bool>();
        int[][] deDup = new int[s.Length][];
        for(int i = 0; i < s.Length; i++)
        {
            deDup[i] = new int[s.Length];
        }
        //int[,] deDup = new int[size,size] {};
        _PalindromeSubstrings(s, 0, s.Length - 1, allPalindromicSubStrings, deDup);
        return allPalindromicSubStrings;
    }

    public static void _PalindromeSubstrings(string s, int startIndex, int endIndex, List<string> allPalindromicSubStrings, int[][] deDup)
    {
        if (s.Length == 0)
        {
            return;
        }
        
        if (deDup[startIndex][endIndex] == 1)
        {
            return;
        }
        
        if (isPalindrome(s))
        {
            deDup[startIndex][endIndex] = 1;
            allPalindromicSubStrings.Add(s);
        }
        else
        {
            _PalindromeSubstrings(s.Remove(0,1),startIndex + 1, endIndex, allPalindromicSubStrings, deDup );
            _PalindromeSubstrings(s.Remove(s.Length-1,1),startIndex, endIndex-1, allPalindromicSubStrings, deDup);
        }
    }

    public static bool isPalindrome(string s)
    {
        if (s.Length == 0)
        {
            return false;
        }

        int start = 0;
        int last = s.Length - 1;
        while ((start <= last) && (s[start] ==  s[last]))
        {
            start++;
            last--;
        }
        if (start > last)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public static void TowerOfHanoi(int disks, char source, char destination, char aux)
    {
        if (disks == 1)
        {
            Console.WriteLine("Move " + source + " to " + destination);
        }
        else
        {
            TowerOfHanoi(disks - 1, source, aux, destination);
            Console.WriteLine("Move " + source + " to " + destination);
            TowerOfHanoi(disks - 1, aux, destination, source);
        }
    }
    
    
    public static List<string> generatePermutation(string s)
    {
        List<string> permutation = new List<string>();
        _generatePermutation(s, "", permutation);
        return permutation;
    }
    
    public static void _generatePermutation(string s, string slate, List<string> permutation)
    {
        if (s.Length == 0)
        {
            permutation.Add(slate);
        }
        else
        {
            foreach(char item in s)
            {
                int index = s.IndexOf(item);
                _generatePermutation(s.Remove(index,1), slate + item, permutation);
            }
        }
    }
    
    public static List<string> generate_all_subsets(string s) 
    {
        // Write your code here.
        List<string> sets = new List<string>();
        _generate_all_subsets(s,"",sets);
        return sets;
    }

    public static void _generate_all_subsets(string s, string slate, List<string> sets)
    {
        // Base condition
        if (s.Length == 0)
        {
            sets.Add(slate);
        }
        else
        {
            _generate_all_subsets(s.Remove(0,1),slate, sets);
            _generate_all_subsets(s.Remove(0,1),slate + s[0], sets);
        }

    }    
        
        public static List<int> segregate_evens_and_odds(List<int> numbers) 
        {
            if (numbers == null)
            {
                return numbers;
            }
            int left = 0;
            int right = numbers.Count - 1;
            while (left < right)
            {
                while (numbers[left]%2 == 0 && left < right)
                {
                    left++;
                }
                while (numbers[right]%2 != 0 && left < right)
                {
                    right--;
                }
                
                if (left < right)
                {
                    int temp = numbers[left];
                    numbers[left] = numbers[right];
                    numbers[right] = temp;
                    left++;
                    right--;
                }
            }
            return numbers;
        }
        
        
        
        public static void TestDutchSort()
        {
            List<char> list = new List<char>{'B','G','R','G','R','B','G'};
            List<char> list1 = new List<char>{'B','B','B','R','R','G','G'};
            List<char> list2 = new List<char>{'B','G','R','B','G','R','B'};
            DutchSort(list);
            DutchSort(list1);
            DutchSort(list2);
        }        
        
        public static void DutchSort(List<char> list)
        {
            int redIndex = 0;
            int greenIndex = 0;
            int blueIndex = list.Count - 1;

            while(greenIndex <= blueIndex)
            {
                if (list[greenIndex] == 'B')
                {
                    (list[greenIndex], list[blueIndex]) = (list[blueIndex], list[greenIndex]);
                    blueIndex--;
                }
                else if (list[greenIndex] == 'R')
                {
                    (list[greenIndex], list[redIndex]) = (list[redIndex], list[greenIndex]);
                    greenIndex++;
                    redIndex++;
                }
                else
                {
                    greenIndex++;
                }
            }
        }
        
        
        public static void TestCoupleTogether()
        {
            List<int> partnerList = new List<int>{8,0,5,2,4,1,3,7,6,9};
            int swaps = CoupleTogether(partnerList);
        }
        
        public static int CoupleTogether(List<int> partners)
        {
            int noOfSwaps = 0;
            Dictionary<int,int> partnerLocation = new Dictionary<int,int>();
            int location = 0;
            foreach(int partner in partners)
            {
                partnerLocation.Add(partner, location++);
            }

            int noOfCouples = partners.Count/2;
            for(int coupleCount = 0; coupleCount < noOfCouples; coupleCount++)
            {
                int leftPartner =  partners[2 * coupleCount];
                int currentRightPartner = partners[2 * coupleCount + 1];
                int actualRightPartner;
                if (leftPartner % 2 == 0)
                {
                    actualRightPartner = leftPartner + 1;
                }
                else
                {
                    actualRightPartner = leftPartner - 1;
                }
                while (currentRightPartner != actualRightPartner)
                {
                    noOfSwaps++;
                    int PartnerOfCurrentRightPartner = 0;
                    if (currentRightPartner % 2 == 0)
                    {
                        PartnerOfCurrentRightPartner =  currentRightPartner + 1;
                    }
                    else
                    {
                        PartnerOfCurrentRightPartner =  currentRightPartner - 1;
                    }
                    int locationOfPartnerOfCurrentRightPartner = partnerLocation[PartnerOfCurrentRightPartner];
                    int finalLocationofCurrentRightPartner = 0;
                    if (locationOfPartnerOfCurrentRightPartner % 2 == 0)
                    {
                        finalLocationofCurrentRightPartner = locationOfPartnerOfCurrentRightPartner + 1;
                    }
                    else
                    {
                        finalLocationofCurrentRightPartner = locationOfPartnerOfCurrentRightPartner - 1;
                    }
                    // Take the current right partner to next to its actual partner.
                    (partners[2 * coupleCount + 1], partners[finalLocationofCurrentRightPartner]) = (partners[finalLocationofCurrentRightPartner], partners[2 * coupleCount + 1]);
                    // update the location of swapped partners
                    partnerLocation[partners[2 * coupleCount + 1]] = 2 * coupleCount + 1;
                    partnerLocation[currentRightPartner] = finalLocationofCurrentRightPartner;
                    currentRightPartner = partners[2 * coupleCount + 1];
                }
            }
            return noOfSwaps;
        }

    }
}