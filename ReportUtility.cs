namespace mis_221_pa_5_wcklecka
{
    public class ReportUtility
    {

        public Transaction[] transactions; //getting transactions

        public ReportUtility(Transaction[] transactions){
            this.transactions = transactions;

        }

        public void CustomerByDate() {
            //getting customer name
            string curr = transactions[0].GetCustomerName();
            //getting training date
            string count = transactions[0].GetTrainingDate();
            for(int i = 1; i < Transaction.GetCount(); i++) {
                if(transactions[i].GetCustomerName() == curr) {
                    count += transactions[i].GetTrainingDate();
                } else {
                    ProcessBreak(ref curr, ref count, transactions[i]);
                }
            }
            ProcessBreak(curr, count);
        }

        public void ProcessBreak(ref string curr, ref string count, Transaction transaction) {
            //displaying customer and date
            System.Console.WriteLine($"{curr}\t{count}");
            curr = transaction.GetCustomerName();
            count = transaction.GetTrainingDate();
        }

        public void ProcessBreak(string curr, string count) {
            System.Console.WriteLine($"{curr}\t{count}");
        }


    }
}