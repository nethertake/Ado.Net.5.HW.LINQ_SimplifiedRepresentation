using System;
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

namespace Module06HW1
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model1 db = new Model1();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetData_Click(object sender, RoutedEventArgs e)
        {
            List<Area> data = db.Area.Where(w => w.WorkingPeople > 2).ToList();
            GridView1.Columns.Clear();
            GridView1.Columns.Add(new GridViewColumn() { Header = "AreaID", DisplayMemberBinding = new Binding() {Path = new PropertyPath("AreaId") } });
            GridView1.Columns.Add(new GridViewColumn() { Header = "Name", DisplayMemberBinding = new Binding() { Path = new PropertyPath("Name") } });
            ListViewData.ItemsSource = data;
        }

        private void GetData2_Click(object sender, RoutedEventArgs e)
        {
            var data = db.Area.Where(w => w.AssemblyArea == true);
        }

        private void GetData3_Click(object sender, RoutedEventArgs e)
        {
            var data = db.Area.Take(10);
        }
        private void GetData4_Click(object sender, RoutedEventArgs e)
        {
            var data = db.Area.ToList();
            var data2 = data.TakeWhile(tw => tw.OrderExecution != null);
         
        }

        private void GetData5_Click(object sender, RoutedEventArgs e)
        {
            var data = db.Area.ToList();
            var data2 = data.TakeWhile(tw => tw.OrderExecution == null);

        }

        private void GetData6_Click(object sender, RoutedEventArgs e)
        {
            var data = db.Area.GroupBy(gb => gb.IP);

        }
        private void GetData7_Click(object sender, RoutedEventArgs e)
        {

            int[] arr = new[] { 22, 23, 24, 25, 26, 27, 28 };
            var data = db.Timer.Where(w => arr.Contains(w.AreaId.Value));
        }

        private void GetData8_Click(object sender, RoutedEventArgs e)
        {

            int[] arr = new[] { 38, 39, 102 };
            var data = db.Timer.Where(w => arr.Contains(w.AreaId.Value) && w.DateFinish != null).Where(w => w.DateStart >= DateTime.Parse("01.06.2017") && w.DateFinish <= DateTime.Parse("30.08.2017"));
        }

        private void GetData9_Click(object sender, RoutedEventArgs e)
        {
            var data = db.Timer.Where(w => w.DateFinish != null).Count();
        }

        private void GetData10_Click(object sender, RoutedEventArgs e)
        {
            var data = db.Timer.Join(db.Area, tm => tm.AreaId, ar => ar.AreaId, (tm, ar) => new
            {
                tm, ar

            });
        }

        private void GetData11_Click(object sender, RoutedEventArgs e)
        {
            var data = db.Timer.GroupBy(gr => gr.DateStart).OrderByDescending(o => o.Key.Value);
           
        }

     
    }
}
