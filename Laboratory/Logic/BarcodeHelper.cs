using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Logic
{
    /// <summary>
    /// Класс для создания штрих-кода
    /// </summary>
    public class BarcodeHelper
    {
        public string barcodeText { set; get; }
        public BitmapImage barcodeImage { set; get; }

        private void BarcodeGeneration()
        {
            string result = "";
            int uniqId = Logic.DBQuery.GetUniqIdOrder();

            if (uniqId != -1)
                result += uniqId + 1;
            else
            {
                barcodeText = null;
                return;
            }

            result += DateTime.Now.ToLongDateString();

            barcodeText = result;
        }
    }
}
