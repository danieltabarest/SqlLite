using System;

namespace NsuGo.Definition.Models
{
    public class Transaction
    {
        public string Description
        {
            get;
            private set;
        }

        public string DetailCode
        {
            get;
            private set;
        }

        public DateTime Date
        {
            get;
            private set;
        }

        public decimal Charge
        {
            get;
            private set;
        }

        public decimal Payment
        {
            get;
            private set;
        }

        public Transaction()
        {
        }

        public Transaction(string description, 
                           string detailCode, 
                           DateTime date, 
                           decimal charge, 
                           decimal payment)
        {
            Description = description;
            DetailCode = detailCode;
            Date = date;
            Charge = charge;
            Payment = payment;
        }

        public string Note
        {
            get 
            {
                var label = "Charge";
                var detail = Charge.ToCurrency();

                if (Payment > 0)
                {
                    label = "Payment";
                    detail = Payment.ToCurrency();
                }

                return $"{label}: {detail}";
            }
        }
    }
}
