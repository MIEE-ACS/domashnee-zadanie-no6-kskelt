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

namespace DZ6KSK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    public enum hierarchy
    {
        Менеджмент,
        Разработка,
        Персонал
    }
    abstract public class Firm
    {
        private string name;
        private int money;
        private double experience;
        private hierarchy division;
        private string position;


        public Firm(string Name, int Money, double Experience, hierarchy Division, string Position)
        {
            name= Name;
            money= Money;
            experience= Experience;
            division= Division;
            position= Position;
        }

        public string Name
        {
            get
            {
                return name;
            }
 
        }
        public int Money
        {
            get
            {
                return money;
            }
        }

        public double Experience
        {
            get
            {
                return experience;
            }
        }
        public hierarchy Division
        {
            get
            {
                return division;
            }
        }
        public string Position
        {
            get
            {
                return position;
            }
        }

    };
    public class Director : Firm
    {
        public Director(string name, int salary, double experience, string position) :
            base(name, salary, experience, hierarchy.Менеджмент, position)
        {

        }
    }

    public class Manager : Firm
    {
        public Manager(string name, int salary, double experience, string position) :
            base(name, salary, experience, hierarchy.Менеджмент, position)
        {

        }
    }

    public class Programmer : Firm
    {
        public Programmer(string name, int salary, double experience, string position) :
            base(name, salary, experience, hierarchy.Разработка, position)
        {

        }
    }

    public class Cleaner : Firm
    {
        public Cleaner(string name, int salary, double experience, string position) :
            base(name, salary, experience, hierarchy.Персонал, position)
        {

        }
    }
    public partial class MainWindow : Window
    {
        List<Firm> ALL = new List<Firm>();
        public void Choice_division(List<Firm> N, hierarchy division)
        {
            allinfo.Text = $"Люди, работающие в отделе {division}: \n";
            for (int i = 0; i < N.Count; i++)
            {
                if (N[i].Division == division)
                {
                    allinfo.Text += "Имя:" + N[i].Name+ "Зарплата:"+N[i].Money +", опыт работы:"+ N[i].Experience +", Должность:"+ N[i].Position+" \n";
                }
            }
        }

        public void Money_Sum(List<Firm> N, hierarchy division)
        {
            int sum = 0;
            int k = 0;

            for (int i = 0; i < N.Count; i++)
            {
                if (N[i].Division == division)
                {
                    sum += N[i].Money;
                    k++;
                }
            }
            if (k == 0)
            {
                allinfo.Text = "в отделе нет работника по таким параметрам \n";
            }
            else
            {
                allinfo.Text += "Средняя зарплата в отделe"+ division+":"+ sum/k+"\n";
            }
        }

        public void All_Experience(List<Firm> N)
        {
            double sum = 0;
            int k = 0;
            for (int i = 0; i < N.Count; i++)
            {
                sum += N[i].Experience;
                k++;
            }
            if (k == 0)
            {
                allinfo.Text = "в отделе нет работника по таким параметрам\n";
            }
            else
            {

                allinfo.Text = "Средний опыт работы в компании:"+ sum /k+" \n";
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            ALL.Add(new Director("Кондратьев Илья Николаевич", 250000, 15.2, "Директор"));
            ALL.Add(new Manager("Соколов Михаил Олегович", 110000, 6.2, "Менджер"));
            ALL.Add(new Programmer("Жукалина Диана Вадимовна", 86000, 2.2, "Программист"));
            ALL.Add(new Programmer("Терещенко Иван Владимирович", 70100, 5.2, "Программист"));
            ALL.Add(new Cleaner("Чулюкин Дмитрий Сергеевич", 30500, 7, "Уборщик"));
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            switch (tch2.SelectedIndex)
            {
                case -1:
                    {
                        allinfo.Text = "выберите что искать";
                     break;
                    }
                case 0:
                    switch (tch1.SelectedIndex)
                    {
                        case -1:

                            allinfo.Text = "выберите что искать";
                            break;


                        case 0:

                            Choice_division(ALL, hierarchy.Менеджмент);

                            break;
                        case 1:

                            Choice_division(ALL, hierarchy.Разработка);

                            break;
                        case 2:

                            Choice_division(ALL, hierarchy.Персонал);

                            break;
                    }
                    break;
                case 1:
                    {
                        switch (tch1.SelectedIndex)
                        {
                            case -1:

                                allinfo.Text = "выберите что искать";
                                break;
                            case 0:

                                Money_Sum(ALL, hierarchy.Менеджмент);

                                break;
                            case 1:

                                Money_Sum(ALL, hierarchy.Разработка);

                                break;
                            case 2:

                                Money_Sum(ALL, hierarchy.Персонал);
                                break;
                        }
                        break;
                    }
                case 2:
                    {
                        All_Experience(ALL);
                        break;
                    }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = false;
                string name = tb_in1.Text;
                int money = int.Parse(tb_in2.Text);
                double experience = double.Parse(tb_in3.Text);
                string department = tb_in4.Text;

                if (department == "Директор")
                {
                    ALL.Add(new Director(name, money, experience, department));
                    flag = true;

                }
                if (department == "Программист")
                {
                    ALL.Add(new Programmer(name, money, experience, department));
                    flag = true;
                }
                if (department == "Менеджер")
                {
                    ALL.Add(new Manager(name, money, experience, department));
                    flag = true;
                }
                if (department == "Уборщик")
                {
                    ALL.Add(new Cleaner(name, money, experience, department));
                    flag = true;
                }

                if (flag == true)
                {
                    allinfo.Text = "Работник добавлен!";
                }
                else
                {
                    allinfo.Text = "Ошибка";
                }

            }
            catch
            {
                allinfo.Text = "Ошибка во ведённых данных";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = false;
                string name = tb_in1.Text;
                int money = int.Parse(tb_in2.Text);
                double experience = double.Parse(tb_in3.Text);
                string department = tb_in4.Text;

                for (int i = 0; i < ALL.Count; i++)
                {
                    if (name == ALL[i].Name && money == ALL[i].Money && experience == ALL[i].Experience)
                    {
                        ALL.Remove(ALL[i]);
                        flag = true;
                    }

                    if (flag == true)
                    {
                        allinfo.Text = "Работник удалён!";
                    }
                    else
                    {
                        allinfo.Text = "Ошибка";
                    }
                }

            }
            catch
            {
                allinfo.Text = "Ошибка во ведённых данных";
            }

        }
    }
}
