namespace mis_221_pa_5_wcklecka
{
    public class ListingUtility
    {
        public Listing[] listing; //get listing

        public ListingUtility(Listing[] listing){
            this.listing = listing;
        }


        public void GetAllListingsFromFile(){
            //open file
            StreamReader listingFile = new StreamReader("listings.txt"); //reading file
            //process file
            Listing.SetCount(0); //setting count
            string line = listingFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#'); //split
                listing[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5]);
                Listing.IncCount();
                line = listingFile.ReadLine();
            }
            listingFile.Close(); //close file
        }

        public void AddListing(){
            System.Console.WriteLine("Please enter the listing ID");
            Listing addListing = new Listing(); //creating new listing
            addListing.SetListingID(int.Parse(Console.ReadLine())); // set ID
            System.Console.WriteLine("Please enter the trainer name");
            addListing.SetTrainerName(Console.ReadLine()); //set name
            System.Console.WriteLine("Please enter the session date");
            addListing.SetSessionDate(Console.ReadLine()); // set date
            System.Console.WriteLine("Please enter the session time");
            addListing.SetSessionTime(Console.ReadLine()); //set time
            System.Console.WriteLine("Please enter the session cost");
            addListing.SetSessionCost(int.Parse(Console.ReadLine())); //set codt
            System.Console.WriteLine("Has the listing been taken");
            addListing.SetListingAvailability(Console.ReadLine()); //set available

            listing[Listing.GetCount()] = addListing;
            Listing.IncCount(); 

            Save(); //save to file
        }

        private void Save() {
            //open file
            StreamWriter outFile = new StreamWriter("listings.txt");
            //process file
            for(int i = 0; i < Listing.GetCount(); i++) {
                outFile.WriteLine(listing[i].ToFile());
            }
            //close file
            outFile.Close();
        }

        public int Find(int searchVal){
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listing[i].GetListingID() == searchVal){ //getting listing ID
                    return i;
                }
            }
            return -1;
        }

        public void EditListing(){
            System.Console.WriteLine("What is the listing ID you are trying to edit");
            int searchVal = int.Parse(Console.ReadLine()); //getting user answer for ID
            //finding where user answer is
            int foundIndex = Find(searchVal);
            if(foundIndex != -1){
                System.Console.WriteLine("Please enter the trainer name");
                listing[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the session date");
                listing[foundIndex].SetSessionDate(Console.ReadLine());
                System.Console.WriteLine("Please enter the session time");
                listing[foundIndex].SetSessionTime(Console.ReadLine());
                System.Console.WriteLine("Please enter the session cost");
                listing[foundIndex].SetSessionCost(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter if the session is available");
                listing[foundIndex].SetListingAvailability(Console.ReadLine());

                Save(); //save to file
            }
            else{
                System.Console.WriteLine("No listing found");
            }
        }

        public void Sort() {
            for(int i = 0; i < Listing.GetCount() - 1; i++) {
                int min = i;
                for(int j = i + 1; j < Listing.GetCount(); j++) {
                    //processing the sort
                    if(listing[j].GetListingAvailability().CompareTo(listing[min].GetListingAvailability()) > 0 || 
                    (listing[j].GetListingAvailability() == listing[min].GetListingAvailability())    
                    ){
                        min = j;
                    }
                }
                if(min != i) {
                    Swap(min, i); 
                }
            }
        }

        private void Swap(int x, int y) {
            //making a temp so swap can work
            Listing temp = listing[x];
            listing[x] = listing[y];
            listing[y] = temp;
        }

        public void Delete(){
            System.Console.WriteLine("What is the ID of the Trainer you would like to delete");
            int searchVal = int.Parse(Console.ReadLine());
            //finding user answer
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                listing[foundIndex].Delete(); //calling delete method
                Save();
            }
            else{
                System.Console.WriteLine("The Trainer ID is invalid");
            }
        }  
    }
}