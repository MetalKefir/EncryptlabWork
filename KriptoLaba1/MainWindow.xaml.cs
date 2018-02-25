﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KriptoLaba1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (skital.IsChecked==true) {
                string[] mass = origtext.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string result = "";
                int stolbci = 0, count = 0;
                foreach (string r in mass)
                    result += r;
                char[] rezArray = new char[result.Length];
                for (int i = 1; i < result.Length; i++)
                {
                    if (result.Length / i == 4)
                    {
                        stolbci = i;
                        break;
                    }
                }
                for (int i = 0; i < stolbci; i++)
                {
                    int plus = i;

                    {
                        for (int j = 0; j < 4; j++)
                        {
                            rezArray[count] += result[plus];
                            plus += stolbci;
                            count++;
                        }
                    }
                }

                kripttext.Text = new string(rezArray);
            }

            if (tablekript.IsChecked==true & key1.Text!="") {

                Dictionary<char, short> alfavit = new Dictionary<char, short>();
                alfavit.Add('А', 1);
                alfavit.Add('Б', 2);
                alfavit.Add('В', 3);
                alfavit.Add('Г', 4);
                alfavit.Add('Д', 5);
                alfavit.Add('Е', 6);
                alfavit.Add('Ё', 7);
                alfavit.Add('Ж', 8);
                alfavit.Add('З', 9);
                alfavit.Add('И', 10);
                alfavit.Add('Й', 11);
                alfavit.Add('К', 12);
                alfavit.Add('Л', 13);
                alfavit.Add('М', 14);
                alfavit.Add('Н', 15);
                alfavit.Add('О', 16);
                alfavit.Add('П', 17);
                alfavit.Add('Р', 18);
                alfavit.Add('С', 19);
                alfavit.Add('Т', 20);
                alfavit.Add('У', 21);
                alfavit.Add('Ф', 22);
                alfavit.Add('Х', 23);
                alfavit.Add('Ц', 24);
                alfavit.Add('Ч', 25);
                alfavit.Add('Ш', 26);
                alfavit.Add('Щ', 27);
                alfavit.Add('Ъ', 28);
                alfavit.Add('Ы', 29);
                alfavit.Add('Ь', 30);
                alfavit.Add('Э', 31);
                alfavit.Add('Ю', 32);
                alfavit.Add('Я', 33);


                string original = key1.Text;
                string orginaltext = origtext.Text;
                char[] chekleter = original.ToCharArray();

                int count = 0;
                foreach (char later in chekleter)
                {
                    count = original.Where(x => x == later).Count();
                    if (count > 1) { kripttext.Text = "Ты що ебанутый???"; return; }
                }

                int[] array1 = new int[original.Length];
                int[] array2 = new int[original.Length];

                count = 0;
                foreach(char later in original.ToUpper())
                {
                    array1[count++] = alfavit[later];
                }

                array2 = array1.OrderBy(x=>x).ToArray();
               

                

                char[,] array3 = new char[(int)Math.Ceiling((double)orginaltext.Length/array2.Length), array2.Length];
                count = 0;
                for (int i=0; i< (int)Math.Ceiling((double)orginaltext.Length / array2.Length); i++)
                    for(int j=0; j< array2.Length; j++)
                    {
                        array3[i, j] = orginaltext.Length<=count ? ' ' : orginaltext[count];
                        count++;
                    }

                char[,] array4 = new char[(int)Math.Ceiling((double)orginaltext.Length / array2.Length), array2.Length];

                for(int i=0; i< array2.Length; i++)
                {
                    if (array1[i] == array2[i])
                    {
                        for(int j=0; j< ((int)Math.Ceiling((double)orginaltext.Length / array2.Length)); j++)
                        {
                            array4[j, i] = array3[j, i];
                        }
                    }else{

                        for (int j = 0; j < (int)Math.Ceiling((double)orginaltext.Length / array2.Length); j++)
                        {
                            array4[j, i] = array3[j, Array.IndexOf(array1, array2[i])];
                        }

                    }

                }
                string rez="";
                foreach(char lit in array4)
                {
                    rez += lit;
                }
                kripttext.Text = rez;
            }

            if (doubleswitch.IsChecked==true && key1.Text!="" && key2.Text!="") {

                Dictionary<char, short> alfavit = new Dictionary<char, short>
                {
                    { 'А', 1 },
                    { 'Б', 2 },
                    { 'В', 3 },
                    { 'Г', 4 },
                    { 'Д', 5 },
                    { 'Е', 6 },
                    { 'Ё', 7 },
                    { 'Ж', 8 },
                    { 'З', 9 },
                    { 'И', 10 },
                    { 'Й', 11 },
                    { 'К', 12 },
                    { 'Л', 13 },
                    { 'М', 14 },
                    { 'Н', 15 },
                    { 'О', 16 },
                    { 'П', 17 },
                    { 'Р', 18 },
                    { 'С', 19 },
                    { 'Т', 20 },
                    { 'У', 21 },
                    { 'Ф', 22 },
                    { 'Х', 23 },
                    { 'Ц', 24 },
                    { 'Ч', 25 },
                    { 'Ш', 26 },
                    { 'Щ', 27 },
                    { 'Ъ', 28 },
                    { 'Ы', 29 },
                    { 'Ь', 30 },
                    { 'Э', 31 },
                    { 'Ю', 32 },
                    { 'Я', 33 }
                };

                string original1 = key1.Text;
                string original2 = key2.Text;

                
                int count = 0;
                foreach (char later in original1)
                {
                    count = original1.Where(x => x == later).Count();
                    if (count > 1) { kripttext.Text = "Ты що ебанутый???"; return; }
                }

                
                count = 0;
                foreach (char later in original2)
                {
                    count = original2.Where(x => x == later).Count();
                    if (count > 1) { kripttext.Text = "Ты що ебанутый???"; return; }
                }

                int[] array1 = new int[original1.Length];
                int[] array2 = new int[original2.Length];
                int[] array3 = new int[original1.Length];
                int[] array4 = new int[original2.Length];

                count = 0;
                foreach (char later in original1.ToUpper())
                {
                    array1[count++] = alfavit[later];
                }

                count = 0;
                foreach (char later in original2.ToUpper())
                {
                    array2[count++] = alfavit[later];
                }

                array3 = array1.OrderBy(x => x).ToArray();
                array4 = array2.OrderBy(x => x).ToArray();

                char[,] kryptingstr = new char[array3.Length,array4.Length];

                string orginaltext = origtext.Text;
                count = 0;
                for (int i=0; i<array3.Length ;i++)
                {
                    for (int j = 0; i < array4.Length; j++)
                    {
                        kryptingstr[i, j] = orginaltext.ToString().Length <= count ? ' ' : orginaltext[count];
                        count++;
                    }
                }

                char[,] kryptstr = new char[array3.Length, array4.Length];

                for (int i=0; i<array3.Length; i++)
                {
                    for (int j=0; j<array4.Length; j++)
                    {
                        kryptstr[i, j] = kryptingstr[array1[array3[i]], array2[array4[j]]];
                    }
                }

                kripttext.Text = "Fuck you~!";
            }
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
