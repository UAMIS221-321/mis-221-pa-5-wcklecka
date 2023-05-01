namespace mis_221_pa_5_wcklecka
{
    public class TransactionReport
    {
        public Transaction[] transactions; //transactions

        public TransactionReport(Transaction[] transactions){
            this.transactions = transactions;
        }

        //display transactions
        public void PrintAllTransactions(){
            for(int i = 0; i < Transaction.GetCount(); i++){
                if(transactions[i].GetDelete() == false){
                    System.Console.WriteLine(transactions[i].ToString());
                }
                       
            }
        }
    }
}