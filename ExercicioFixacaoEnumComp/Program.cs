using ExercicioFixacaoEnumComp.Entities;
using ExercicioFixacaoEnumComp.Entities.Enums;
using System;
using System.Globalization;

namespace ExercicioFixacaoEnumComp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Solicita os dados do cliente*/
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());


            /*Instancia um objeto cliente para adicionar as informações*/
            Client c = new Client(name, email, date);

            /*Solicita o status do pedido*/
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            /*Instancia um pedido e adiciona data do pedido e status*/
            Order o = new Order(DateTime.Now, status, c);

            /*Verifica quantos itens serão adicionados no pedido*/
            Console.Write("How many items to this order? ");
            int qtOrder = int.Parse(Console.ReadLine());

            /*De acordo com a quantidade é solicitado as informações dos itens*/
            for (int i = 0; i < qtOrder; i++)
            {
                /*Solicita os dados do produto*/
                Console.WriteLine("Enter #"+(i+1)+" item data: ");
                Console.Write("Product name: ");
                string product = Console.ReadLine();
                Console.Write("Product price: ");
                double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                /*Instancia um produto para adicionar as informações*/
                Product p = new Product(product, prodPrice);

                /*Instancia um item do pedido*/
                OrderItem orderItem = new OrderItem(quantity, prodPrice, p);

                /*Adiciona o item do pedido no pedido*/
                o.AddItem(orderItem);
            }

            Console.WriteLine();            
            Console.WriteLine(o);
        }
    }
}
