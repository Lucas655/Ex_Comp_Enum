﻿using ExercicioFixacaoEnumComp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExercicioFixacaoEnumComp.Entities
{
    class Order
    {

        /*Declaração dos atributos*/
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();        

        /*Construtores*/
        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        /*Métodos para inserir/Remover e calcular o total de um pedido*/
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;

            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        /*Método string builder para imprimir*/
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Summary: ");
            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items: ");

            foreach (OrderItem item in Items)
            {
                sb.Append(item.Product.Name);
                sb.Append(", $");
                sb.Append(item.Product.Price);
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);
                sb.Append(", ");
                sb.Append("Subtotal: ");
                sb.AppendLine(item.SubTotal().ToString("F2",CultureInfo.InvariantCulture));
            }

            sb.Append("Total price: ");
            sb.Append("$");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }

    }
}
