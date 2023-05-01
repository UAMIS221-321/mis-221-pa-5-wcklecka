namespace mis_221_pa_5_wcklecka
{
    public class Transaction
    {
        private int sessionID;

        private string customerName;

        private string customerEmail;

        private string trainingDate;

        private int trainerID;

        private string trainerName;

        private string status;

        private bool isDeleted;

        static private int count; //transaction count

        public Transaction(){

        }

        public Transaction(int sessionID, string customerName, string customerEmail, string trainingDate, int trainerID, string trainerName, string status){
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
        }

        //getters and setters
        public void SetSessionID(int sessionID){
            this.sessionID = sessionID;
        }

        public int GetSessionID(){
            return sessionID;
        }
        
        public void SetCustomerName(string customerName){
            this.customerName = customerName;
        }

        public string GetCustomerName(){
            return customerName;
        }
        
        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }

        public string GetCustomerEmail(){
            return customerEmail;
        }
        
        public void SetTrainingDate(string trainingDate){
            this.trainingDate = trainingDate;
        }

        public string GetTrainingDate(){
            return trainingDate;
        }

        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }

        public int GetTrainerID(){
            return trainerID;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetTrainerName(){
            return trainerName;
        }

        public void SetStatus(string status){
            this.status = status;
        }

        public string GetStatus(){
            return status;
        }

        public void SetDelete(bool isDeleted){
            this.isDeleted = isDeleted;
        }

        public bool GetDelete(){
            return isDeleted;
        }
        static public void SetCount(int count) {
            Transaction.count = count;
        }

        static public int GetCount() {
            return Transaction.count;
        }
        
        static public void IncCount() {
            Transaction.count++;
        }

        public override string ToString() {
            return $"Session ID: {this.sessionID}\tCustomer Name: {this.customerName}\tCustomer Email: {this.customerEmail}\tDate: {this.trainingDate}\tTrainer ID:{this.trainerID}\tTrainer Name: {this.trainerName}\tStatus: {this.status}\tDeleted: {this.isDeleted}\n";
        }

        public string ToFile() {
            return $"{sessionID}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerName}#{status}#{isDeleted}";
        } 

        //delete method
        public void Delete(){
            isDeleted = !isDeleted;
        }
    }
}