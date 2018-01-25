using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField]
    Text[] texts;
    [SerializeField]
    Text digit1, digit2;
    [SerializeField]
    AudioClip win, fail;
    int res;
    AudioSource audio;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        audio = gameObject.GetComponent<AudioSource>();
        int[] digits = new int[texts.Length];
        for(int i=0;i<texts.Length;i++)
        {
            int digit = UnityEngine.Random.Range(0, 9);
            texts[i].text = digit.ToString();
            digits[i] = digit;
        }
        res = CalcCode(digits);
    }

    int CalcCode(int[] arr)
    {
        if (isPrime(SumArr(arr)))
            return arr[0] + arr[arr.Length - 1];
        else if (CountEven(arr) == 3)
            return 22;
        else if (ContainSquare(arr))
            return SumValues(arr);
        else
            return MaxArr(arr);
    }

    public void Check()
    {
        int n = int.Parse(digit1.text) * 10 + int.Parse(digit2.text);
        if(n==res)
        {
            audio.clip = win;
            audio.Play();
        }
        else
        {
            audio.clip = fail;
            audio.Play();
        }
    }

#region helperFunctions
    bool isPrime(int n)
    {
        for (int i = 2; i < n; i++)
            if (n % i == 0)
                return false;
        return true;
    }

    int SumArr(int[] arr)
    {
        int res = 0;
        foreach (int i in arr)
            res += i;
        return res;
    }

    int MaxArr(int[] arr)
    {
        int res = arr[0];
        foreach (int i in arr)
            if (i > res)
                res = i;
        return res;
    }

    int CountEven(int[] arr)
    {
        int res = 0;
        foreach (int i in arr)
            if (i % 2 == 0)
                res++;
        return res;
    }

    bool ContainSquare(int[] arr)
    {
        foreach (int i in arr)
            if (Mathf.Floor(Mathf.Sqrt(i)) == Mathf.Ceil(Mathf.Sqrt(i)))
                return true;
        return false;
    }

    int DigitValue(int n)
    {
        if (n == 1)
            return 2;
        if (n == 4 || n == 7)
            return 4;
        if (n == 2 || n == 3 || n == 5)
            return 5;
        if (n == 0 || n == 6 || n == 9)
            return 6;
        if (n == 8)
            return 7;
        return 0;
    }

    int SumValues(int[] arr)
    {
        int res = 0;
        foreach (int i in arr)
            res += DigitValue(i);
        return res;
    }
#endregion


}
