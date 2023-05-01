namespace mis_221_pa_5_wcklecka
{
    public class Trainer
    {
        private int trainerID;
        private string trainerName;
        private string mailingAddress;
        private string emailAddress;
        private bool isDeleted;

        static private int count; //count trainers


        public Trainer(){

        }
    
        public Trainer(int trainerID, string trainerName, string mailingAddress, string emailAddress){
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.mailingAddress = mailingAddress;
            this.emailAddress = emailAddress;
        }
        //getters and setters
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
        
        public void SetMailingAddress(string mailingAddress){
            this.mailingAddress = mailingAddress;
        }

        public string GetMailingAddress(){
            return mailingAddress;
        }
        
        public void SetEmailAddress(string emailAddress){
            this.emailAddress = emailAddress;
        }

        public string GetEmailAddress(){
            return emailAddress;
        }

        static public void SetCount(int count) {
            Trainer.count = count;
        }
        
        static public int GetCount() {
            return Trainer.count;
        }

        static public void IncCount() {
            Trainer.count++;
        }

        public override string ToString() {
            return $"\t\t\tTrainer ID: {this.trainerID}\t Trainer Name: {this.trainerName}\t Mailing Address: {this.mailingAddress}\t Email Address: {this.emailAddress}\t Deleted: {this.isDeleted}\n";
        }

        public string ToFile() {
            return $"{trainerID}#{trainerName}#{mailingAddress}#{emailAddress}#{isDeleted}";
        }

        //delete method
        public void Delete(){
            isDeleted = !isDeleted;
        }
    }
}