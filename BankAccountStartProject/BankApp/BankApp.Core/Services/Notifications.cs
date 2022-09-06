﻿using BankApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Services
{
    public class Notifications :INotificationService
    {
         string rootPath = @"C:\Users\WINDOWS 10 PRO\source\repos\BankAccountStartProject\BankApp\Notifications.txt";

        public void NotifyFraudlentActivity(Account account)
        {
            //using FileStream file = File.OpenWrite(rootPath);
            using (TextWriter rootPath = new StreamWriter(@"C:\Users\WINDOWS10PRO\source\repos\BankAccountStartProject\BankApp\Notifications.txt", true))
            {
                var notify = new Notification()
                {
                    Message = $"{account.Email}: An unusual transaction have been dictated in your account",
                    AccountId = account.Id,
                    Email =account.Email,
                };
                rootPath.WriteLine(notify.Message, notify.AccountId, notify.Email);
                rootPath.Close();
            }
        }

        public void NotifyFundsLow(Account account)
        {
            using (TextWriter rootPath = new StreamWriter(@"C:\Users\WINDOWS 10 PRO\source\repos\BankAccountStartProject\BankApp\Notifications.txt", true))
            {
                var notify = new Notification()
                {
                    Message = $"{account.Email}: Account Balance is Low",
                    AccountId = account.Id,
                    Email = account.Email,
                };
                rootPath.WriteLine(notify.Message, notify.AccountId, notify.Email);
                rootPath.Close();
            }
        }

        public IEnumerable<Notification> GetNotificationsForEmail(string emailAddress)
        {


            var Path = @"C:\Users\WINDOWS 10 PRO\source\repos\BankAccountStartProject\BankApp\Notifications.txt";

            throw new NotImplementedException();

        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            using (TextWriter rootPath = new StreamWriter(@"C:\Users\WINDOWS 10 PRO\source\repos\BankAccountStartProject\BankApp\Notifications.txt", true))
            {
                var path = @"C:\Users\WINDOWS 10 PRO\source\repos\BankAccountStartProject\BankApp\Notifications.txt";
            }

            return GetAllNotifications();
        }
    }
}
