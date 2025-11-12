using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Aftab
{
    public class NumberGame : MonoBehaviour
    {
        [SerializeField]
        int input = 15;
        string outPutString = string.Empty;
        private void Start()
        {
            Debug.Log(ReverseWord("Hello, World True@ False!"));
        }

        string ReverseWord(string originalString)
        {
            //string outPutFirstWord = string.Empty;
            //string outPutSecondWord = string.Empty;
            //bool isSecondWordDone = false;
            //bool alreadySpaceOrPunctuationFound = false;
            string outputString = string.Empty;
            string[] newString = originalString.Split(new char[]{' '});

            for (int i = newString.Length-1; i >= 0; i--)
            {
                outputString += newString[i];
                outputString += " ";
            }

            return outputString;
            /*
            for (int i = 0; i < originalString.Length; i++)
            {
                if(originalString[i] == ' ' || originalString[i] == ',')
                {
                    if (alreadySpaceOrPunctuationFound) continue;
                    alreadySpaceOrPunctuationFound = true;
                    isSecondWordDone = true;
                    outPutFirstWord += " ";
                }
                else
                {
                    if (isSecondWordDone)
                    {
                        outPutFirstWord += originalString[i];
                    }
                    else
                    {
                        outPutSecondWord += originalString[i];
                    }
                }
                
            }

            return outPutFirstWord + outPutSecondWord;
            */
        }

        void FizzBuzz()
        {
            //string outPutString = string.Empty;
            for (int i = 1; i <= input; i++)
            {
                if (i % 3 == 0 && i % 5 == 0 && i != 0) outPutString += "FizzBuzz";// Debug.Log("FizzBuzz");
                else if (i % 3 == 0) outPutString += "Fizz";// Debug.Log("Fizz");
                else if (i % 5 == 0) outPutString += "Buzz";//  Debug.Log("Buzz");
                else outPutString += i; // Debug.Log(i);
                if (i < input) outPutString += ",";
            }
            Debug.Log(outPutString);
        }
    }
}
