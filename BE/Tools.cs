using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Tools
    {
         public static T[] Flatten<T>(this T[,] arr)        
        {            
            int rows = arr.GetLength(0);   //12
            int columns = arr.GetLength(1);  //31
            T[] arrFlattened = new T[rows * columns]; 
            for (int j = 0; j < rows; j++)     
            {  
                for (int i = 0; i < columns; i++)
                {   
                    var test = arr[j, i]; 
                    arrFlattened[j*columns + i] = arr[j, i]; 
                }    
            }         
            return arrFlattened;   
        } 
 
        public static T[,] Expand<T>(this T[] arr, int rows)      
        {   
            int length = arr.GetLength(0);   //12*31
            int columns = length / rows;   //31
            T[,] arrExpanded = new T[rows, columns];  
            for (int j = 0; j < rows; j++)
            {     
                for (int i = 0; i < columns; i++)     
                {   
                    arrExpanded[j, i] = arr[j*columns + i];
                }         
            }        
            return arrExpanded; 
        }  
    }
     
}
