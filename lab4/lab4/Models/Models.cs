using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace lab4.Models
{
    internal class Product
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public int TimeToBuy { get; set; }

        public Product(Product newProduct)
        {
            Name = newProduct.Name;
            Count = newProduct.Count;
            TimeToBuy = newProduct.TimeToBuy;
        }
        public Product()
        {

        }
    }

    internal class Customer
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; } // 60>= пенсионер
        public DateTime QueueEnterTime { get; set; }
        public int BuyTime { get; set; }
        public ICollection<Product> Products { get; set; }
        public int Prioritet => Age >= 60 && Gender == "Женщина" ? 3 : Age >= 60 && Gender == "Мужчина" ? 2 : Gender == "Женщина" ? 1 : 0;

        public Customer(string name, string gender, int age, DateTime queueEnterTime)
        {
            Name = name;
            Gender = gender;
            Age = age;
            QueueEnterTime = queueEnterTime;
        }

        public Customer()
        {

        }
    }

    internal class PriorityQueue
    {
       public ICollection<Customer> Queue { get; set; }

        public void Add_SortQueue(Customer newCustomer)
        {
            LinkedList<Customer> SortedQueue;
            if (Queue.Count > 0)
            {
                SortedQueue = new LinkedList<Customer>(Queue);
                var item = SortedQueue.Last;
                while (newCustomer.Prioritet > item.Value.Prioritet)
                {
                    if (item.Previous != null)
                    {
                        item = item.Previous;
                    }
                    else
                    {
                        break;
                    }
                }

                SortedQueue.AddAfter(item, newCustomer);
            }
            else
            {
                SortedQueue = new LinkedList<Customer>();
                SortedQueue.AddLast(newCustomer);
            }
            Queue.Clear();
           
            foreach(Customer el in SortedQueue)
            {
                Queue.Add(el);
            }
        }

        public PriorityQueue(ObservableCollection<Customer> customers)
        {
            Queue = new ObservableCollection<Customer>(customers);
        }

        public PriorityQueue()
        {
            Queue = new ObservableCollection<Customer>();
        }

    }
    
}
