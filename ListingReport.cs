namespace mis_221_pa_5_wcklecka
{
    public class ListingReport
    {
        Listing[] listing; //get listing

        public ListingReport(Listing[] listing){
            this.listing = listing;
        }

        //print method
        public void PrintAllListings(){
            for(int i = 0; i < Listing.GetCount(); i++){
                
                System.Console.WriteLine(listing[i].ToString()); //display listings
            }
        }
    }
}