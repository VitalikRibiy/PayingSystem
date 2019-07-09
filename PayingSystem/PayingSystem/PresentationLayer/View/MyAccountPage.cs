// <copyright file="MyAccountPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.PresentationLayer.View
{
    using System;
    using System.Text;
    using PayingSystem.BusinessLayer;
    using PayingSystem.BusinessLayer.DTO_s;

    /// <summary>
    /// Class for displaying account information.
    /// </summary>
    public class MyAccountPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyAccountPage"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        /// <param name="account">Account.</param>
        public MyAccountPage(DataProvider dataProvider, AccountDTO account)
            : base(dataProvider, account)
        {
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Print();
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    _dataProvider.UpdateBalance(Account, _dataProvider.TryDoubleParse("sum"));
                    break;
                case '2':
                    _dataProvider.SendMoney(Account, _dataProvider.TryDoubleParse("sum"));
                    break;
                case '3':
                    break;
                case '4':
                    new AuthenticationPage(_dataProvider).Display();
                    break;
                default:
                    Console.WriteLine("Wrong Button :(");
                    Console.ReadKey();
                    Display();
                    break;
            }
        }

        /// <inheritdoc/>
        public override void Print()
        {
            Console.Clear();
            StringBuilder hidenCard = new StringBuilder(Account.CardNumber.ToString());
            hidenCard.Remove(2, 5).Insert(2, "*****");
            Console.WriteLine($"Hello {Account.Client.FullName}\nYour card number:{hidenCard}\n" +
                $"Your Balance:{Account.Balance}грн\n" +
                $"Don't forget to renew your card ,it will expire in {(Account.Expire - DateTime.Now).Days} days\n" +
                $"\n1)Refill your balance \n2)Send money\n3)Back\n4)LogOut");
        }
    }
}
