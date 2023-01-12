
using System;
using System.Collections.Generic;
using System.Collections;

namespace PracticeC_
{

    public class Mixed
    {
        public Mixed()
        {

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

    }
}