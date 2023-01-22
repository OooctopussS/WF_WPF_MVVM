using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab4.ViewModels.Base;
using System.Collections.ObjectModel;
using lab4.Models;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Input;
using lab4.Commands;
using System.Windows.Data;

namespace lab4.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public DispatcherTimer AddCustomerTimer { get; }
        public DispatcherTimer QueueServiceTimer { get; }
        public PriorityQueue MainQueue { get; }
        public List<Product> AddMenuProducts { get; }
        public ObservableCollection<Customer> ServedCustomersList { get; }
        public ObservableCollection<Product> ProductsSalesStatisic { get; }


        #region Панель добавления - видимость
        private Visibility _VisibleAddPanel = Visibility.Collapsed;

        public Visibility VisibleAddPanel
        {
            get => _VisibleAddPanel;
            set => Set(ref _VisibleAddPanel, value);
        }
        #endregion

        #region Панель добавления - пол покупателя
        private int _AddMenuGender;
        public int AddMenuGender
        {
            get => _AddMenuGender;
            set => Set(ref _AddMenuGender, value);
        }
        #endregion

        #region Панель добавления - возраст покупателя
        private string _AddMenuAge;
        public string AddMenuAge
        {
            get => _AddMenuAge;
            set => Set(ref _AddMenuAge, value);
        }
        #endregion

        #region Панель добавления - имя покупателя
        private string _AddMenuName;
        public string AddMenuName
        {
            get => _AddMenuName;
            set => Set(ref _AddMenuName, value);
        }
        #endregion

        #region Панель добавления - список продуктов, количество
        private Product _AddMenuSelectedProduct;

        public Product AddMenuSelectedProduct
        {
            get => _AddMenuSelectedProduct;
            set => Set(ref _AddMenuSelectedProduct, value);
        }
        #endregion

        #region Команды

        #region CreateCustomerCommand
        public ICommand CreateCustomerCommand { get; }

        private bool CanCreateCustomerCommandExecute(object p) => true;

        private void OnCreateCustomerCommandExecuted(object p)
        {

            if (!int.TryParse(AddMenuAge, out int age))
            {
                age = 0;
            }

            var newProductsList = new List<Product>();

            foreach(Product item in AddMenuProducts)
            {
                if (item.Count > 0)
                {
                    newProductsList.Add(new Product(item));
                }
            }

            int sumTimeToBuy = 0;

            foreach(Product element in newProductsList)
            {
                sumTimeToBuy += element.TimeToBuy * element.Count;
            }

            var newCustomer = new Customer
            {
                Name = AddMenuName ?? "Имя",
                Gender = AddMenuGender == 0 ? "Мужчина" : "Женщина",
                Age = age,
                QueueEnterTime = DateTime.Now,
                BuyTime = sumTimeToBuy,
                Products = newProductsList
            };

            MainQueue.Add_SortQueue(newCustomer);
            Clear_AddPanelInfo();
            AddCustomerTimer.Start();
            VisibleAddPanel = Visibility.Collapsed;
        }
        #endregion

        #endregion

        private void Clear_AddPanelInfo()
        {
            AddMenuName = "";
            AddMenuAge = "";
            AddMenuGender = 0;

            foreach (Product item in AddMenuProducts)
            {
                item.Count = 0;
            }

            AddMenuSelectedProduct = null;

        }

        public MainWindowViewModel()
        {
            #region Команды

            CreateCustomerCommand = new ActionCommand(OnCreateCustomerCommandExecuted, CanCreateCustomerCommandExecute);

            #endregion

            Product[] AddMenuproductsList = new Product[]
            {
                new Product {Name = "Продкут1", Count = 0, TimeToBuy = 1},
                new Product {Name = "Продкут2", Count = 0, TimeToBuy = 1},
                new Product {Name = "Продкут3", Count = 0, TimeToBuy = 1},
                new Product {Name = "Продкут4", Count = 0, TimeToBuy = 1},
                new Product {Name = "Продкут5", Count = 0, TimeToBuy = 1},
                new Product {Name = "Продкут6", Count = 0, TimeToBuy = 1},
                new Product {Name = "Продкут7", Count = 0, TimeToBuy = 1},
                new Product {Name = "Продкут8", Count = 0, TimeToBuy = 1},
                new Product {Name = "Продкут9", Count = 0, TimeToBuy = 1},
                new Product {Name = "Продкут10", Count = 0, TimeToBuy = 1}
            };
            Product[] ProductsSalesStatisicList = new Product[]
            {
                new Product {Name = "Продкут1", Count = 0, TimeToBuy = 0},
                new Product {Name = "Продкут2", Count = 0, TimeToBuy = 0},
                new Product {Name = "Продкут3", Count = 0, TimeToBuy = 0},
                new Product {Name = "Продкут4", Count = 0, TimeToBuy = 0},
                new Product {Name = "Продкут5", Count = 0, TimeToBuy = 0},
                new Product {Name = "Продкут6", Count = 0, TimeToBuy = 0},
                new Product {Name = "Продкут7", Count = 0, TimeToBuy = 0},
                new Product {Name = "Продкут8", Count = 0, TimeToBuy = 0},
                new Product {Name = "Продкут9", Count = 0, TimeToBuy = 0},
                new Product {Name = "Продкут10", Count = 0, TimeToBuy = 0}
            };

            ServedCustomersList = new ObservableCollection<Customer>();
            AddMenuProducts = new List<Product>(AddMenuproductsList);
            MainQueue = new PriorityQueue();
            ProductsSalesStatisic = new ObservableCollection<Product>(ProductsSalesStatisicList);

            #region Таймер добавления покупателя
            AddCustomerTimer = new DispatcherTimer(DispatcherPriority.Render)
            {
                Interval = TimeSpan.FromSeconds(5)
            };

            AddCustomerTimer.Tick += (sender, args) =>
            {
                Random rnd = new();
                int r = rnd.Next(0, 9);
                if (r < 6)
                {
                    VisibleAddPanel = Visibility.Visible;
                    AddCustomerTimer.Stop();
                }
                
            };

            AddCustomerTimer.Start();
            #endregion

            #region Таймер обслуживания покупателя
            QueueServiceTimer = new DispatcherTimer(DispatcherPriority.Render)
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            int buyTimeTemp = 0;
            bool firstCustomerBuys = false;
            Customer firstCustomer = null;
            QueueServiceTimer.Tick += (sender, args) =>
            {
                if (MainQueue.Queue.Count > 0 && !firstCustomerBuys)
                {
                    firstCustomer = MainQueue.Queue.First();
                    buyTimeTemp = firstCustomer.BuyTime;
                    firstCustomerBuys = true;
                }
                else if (MainQueue.Queue.Count > 0 && firstCustomerBuys)
                {
                    if (buyTimeTemp != 0) buyTimeTemp--;
                    if (buyTimeTemp == 0)
                    {
                        ServedCustomersList.Add(firstCustomer);
                        MainQueue.Queue.Remove(firstCustomer);
                        firstCustomerBuys = false;

                        foreach (Product item in firstCustomer.Products)
                        {
                            for (int i = 0; i < ProductsSalesStatisic.Count; i++)
                            {
                                if (item.Name == ProductsSalesStatisic[i].Name)
                                {
                                    ProductsSalesStatisic[i].Count += item.Count;
                                    ProductsSalesStatisic[i].TimeToBuy += item.TimeToBuy * item.Count;
                                    CollectionViewSource.GetDefaultView(ProductsSalesStatisic).Refresh();
                                }
                            }
                        }
                    }
                }
            };

            QueueServiceTimer.Start();
            #endregion
        }
    }
}
