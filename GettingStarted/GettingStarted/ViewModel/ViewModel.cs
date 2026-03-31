using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.StockPriceDetails = new ObservableCollection<Model>();
            DateTime date = new DateTime(2015, 1, 1);
            Random rd = new Random();
            for (int i = 0; i < 70; i++)
            {
                this.StockPriceDetails.Add(new Model()
                {
                    Date = date.AddDays(i),
                    Open = rd.Next(870, 875),
                    High = rd.Next(876, 890),
                    Low = rd.Next(850, 855),
                    Close = rd.Next(856, 860)
                });
            }
        }
        public ObservableCollection<Model> StockPriceDetails { get; set; }
    }
}
