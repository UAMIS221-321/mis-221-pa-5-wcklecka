namespace mis_221_pa_5_wcklecka
{
    public class TransactionUtility
    {
        public Transaction[] transactions;

        public ListingUtility listingUtility;

        public ListingReport listingReport;

        public TrainerUtility trainerUtility;

        public TrainerReport trainerReport;
        

        public TransactionUtility(Transaction[] transactions, ListingUtility listingUtility, ListingReport listingReport, TrainerUtility trainerUtility, TrainerReport trainerReport){
            this.transactions = transactions;
            this.listingUtility = listingUtility;
            this.listingReport = listingReport;
            this.trainerUtility = trainerUtility;
            this.trainerReport = trainerReport;
        }

        public void GetAllTransactionsFromFile(){
            //open file
            StreamReader transactionsFile = new StreamReader("transactions.txt");
            //process file
            Transaction.SetCount(0);
            string line = transactionsFile.ReadLine();
            while(line != null && line != ""){
                string[] temp = line.Split('#');
                bool isDeleted = bool.Parse(temp[7]);
                transactions[Transaction.GetCount()] = new Transaction(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
                Transaction.IncCount();
                line = transactionsFile.ReadLine();
            }
            //close file
            transactionsFile.Close();
        }

        public void BookSession(){
            Transaction newTransaction = new Transaction(); //new transaction
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the session ID");
            int userInput = int.Parse(Console.ReadLine());
            newTransaction.SetSessionID(userInput);
            System.Console.WriteLine("Please enter name");
            newTransaction.SetCustomerName(Console.ReadLine()); //set name
            System.Console.WriteLine("Please enter email"); //set email
            newTransaction.SetCustomerEmail(Console.ReadLine());

            Listing listingBooking = listingUtility.listing[listingUtility.Find(userInput)]; //find listing
            newTransaction.SetTrainingDate(listingBooking.GetSessionDate()); //get date
            newTransaction.SetTrainerName(listingBooking.GetTrainerName()); // get trainer name

            
            string trainerName = listingBooking.GetTrainerName(); //set new varable to trainer name

            Trainer trainerBooking = trainerUtility.trainer[trainerUtility.Find(trainerName)]; //find trainer
            newTransaction.SetTrainerID(trainerBooking.GetTrainerID()); //get trainer ID
            newTransaction.SetStatus("Booked"); //making status booked            
            
            transactions[Transaction.GetCount()] = newTransaction;
            Transaction.IncCount(); 
             //saving transaction
            Save();
        }

        
        private void Save() {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Transaction.GetCount(); i++) {
                outFile.WriteLine(transactions[i].ToFile());
            }

            outFile.Close();
        }

        public void ConfirmCancelBooking(){
            Transaction statusSession = new Transaction();
            System.Console.WriteLine();
            System.Console.WriteLine("Do you want to confirm or cancel your session?");
            System.Console.WriteLine("1. Confirm\n2. Cancel");
            string userChoice = Console.ReadLine();
            switch(userChoice){
                case "1":
                //confirm booking
                    System.Console.WriteLine("Enter ID of your session");
                    int searchVal = int.Parse(Console.ReadLine());
                    int foundIndex = Find1(searchVal);
                    if(foundIndex != -1){
                        transactions[foundIndex].SetStatus("Confirmed");
                    }
                    else {
                        System.Console.WriteLine("Trainer ID not found");
                    }
                    //saving status
                    Save();
                    break;
                case "2":
                //cancel booking
                    System.Console.WriteLine("Enter ID of your session");
                    int searchVal2 = int.Parse(Console.ReadLine());
                    //finding ID
                    int foundIndex2 = Find1(searchVal2);
                    if(foundIndex2 != -1){
                        transactions[foundIndex2].SetStatus("Cancelled");
                    }
                    else {
                        System.Console.WriteLine("Trainer ID not found");
                    }
                    //saving status
                    Save();
                    break;
                default:
                    System.Console.WriteLine("Invalid Menu Choice");
                    PauseAction();
                    break;
            }

            static void PauseAction(){
                System.Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            
        }

        public int Find1(int searchVal){
            for(int i = 0; i < Transaction.GetCount(); i++){
                if(transactions[i].GetSessionID() == searchVal){
                    return i;
                }

            }
            return -1;
        }

        public int Find2(string searchVal3){
            for(int i = 0; i < Transaction.GetCount(); i++){
                if(transactions[i].GetCustomerEmail() == searchVal3){
                    return i;
                }

            }
            return -1;
        }
    }
}