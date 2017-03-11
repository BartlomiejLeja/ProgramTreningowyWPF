using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Controls.DataVisualization.Charting;
using System.Data;
using System.Data.Entity;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;

namespace ProgramTreningowyWPF
{
    class Zarzadca
    {
      

        public void InsertPicture(byte[] zdjecie)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Jpg|*.jpg|Bitmaps | *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                zdjecie = System.IO.File.ReadAllBytes(openFileDialog.FileName);

            }
        }

        public Models.p SerchForView(DateTime dataToSerch)
        {

            using (Models.WorkOutEntities contex = new Models.WorkOutEntities())
            {

                var pToView = (from c in contex.p where c.Dzień == dataToSerch select c).FirstOrDefault(); //LING to Enitities FirstOrDefault() ponieważ to kolekcja enitis i to 

                return pToView;
                //FirstOrDefault() ponieważ to kolekcja enitis ta metoda zamienia mi ti na moją klase
            }

        }
    } 

    }
