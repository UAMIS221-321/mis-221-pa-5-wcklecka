namespace mis_221_pa_5_wcklecka
{
    public class Listing
    {
        private int listingID;

        private string trainerName;

        private string sessionDate;

        private string sessionTime;

        private int sessionCost;

        private string listingAvailable;

        private bool isDeleted;

        static private int count; //count listings

        public Listing(){

        }

        public Listing(int listingID, string trainerName, string sessionDate, string sessionTime, int sessionCost, string listingAvailable){
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.sessionCost = sessionCost;
            this.listingAvailable = listingAvailable;
        }
        
        //Getters and setters

        public void SetListingID(int listingID){
            this.listingID = listingID;
        }

        public int GetListingID(){
            return listingID;
        }
        
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetTrainerName(){
            return trainerName;
        }
        
        public void SetSessionDate(string sessionDate){
            this.sessionDate = sessionDate;
        }

        public string GetSessionDate(){
            return sessionDate;
        }
        
        public void SetSessionTime(string sessionTime){
            this.sessionTime = sessionTime;
        }

        public string GetSessionTime(){
            return sessionTime;
        }

        public void SetSessionCost(int sessionCost){
            this.sessionCost = sessionCost;
        }

        public int GetSessionCost(){
            return sessionCost;
        }

        public void SetListingAvailability(string listingAvailable){
            this.listingAvailable = listingAvailable;
        }

        public string GetListingAvailability(){
            return listingAvailable;
        }
        static public void SetCount(int count) {
            Listing.count = count;
        }
        static public int GetCount() {
            return Listing.count;
        }

        static public void IncCount() {
            Listing.count++;
        }

        //Display format
        public override string ToString() {
            return $"\t\t\tListingID: {this.listingID}\t Trainer Name: {this.trainerName}\t Date: {this.sessionDate}\t Time: {this.sessionTime}\t Cost: ${this.sessionCost}\t Availablility: {this.listingAvailable}\t Deleted: {this.isDeleted}\n";
        }

        //txt file format
        public string ToFile() {
            return $"{listingID}#{trainerName}#{sessionDate}#{sessionTime}#{sessionCost}#{listingAvailable}#{isDeleted}";
        }

        // delete method
        public void Delete(){
            isDeleted = !isDeleted;
        }
    }
}