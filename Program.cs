using mis_221_pa_5_wcklecka;
// start main
//displaying menu
Menu();

// end main

static void Menu(){
    Console.Clear();
    //making custom title
     string title = @" 
      ▀█▀ █▀▄ ▄▀▄ █ █▄ █   █   █ █▄▀ ██▀   ▄▀▄   ▄▀▀ █▄█ ▄▀▄ █▄ ▄█ █▀▄ █ ▄▀▄ █▄ █
       █  █▀▄ █▀█ █ █ ▀█   █▄▄ █ █ █ █▄▄   █▀█   ▀▄▄ █ █ █▀█ █ ▀ █ █▀  █ ▀▄▀ █ ▀█

            █▀▄ ██▀ █▀▄ ▄▀▀ ▄▀▄ █▄ █ ▄▀▄ █     █▀ █ ▀█▀ █▄ █ ██▀ ▄▀▀ ▄▀▀
            █▀  █▄▄ █▀▄ ▄██ ▀▄▀ █ ▀█ █▀█ █▄▄   █▀ █  █  █ ▀█ █▄▄ ▄██ ▄██
    ";
    System.Console.WriteLine(title);
    System.Console.WriteLine("\t\t\t  1. Manage Trainer Data");
    System.Console.WriteLine("\t\t\t  2. Manage Listing Date");
    System.Console.WriteLine("\t\t\t  3. Manage Customer Booking Data");
    System.Console.WriteLine("\t\t\t  4. Run Reports");
    System.Console.WriteLine("\t\t\t  5. Exit the Application");
    string userInput = Console.ReadLine(); // get user answer
    switch(userInput){
        case "1":
            TrainerData();
            break;
        case "2":
            ListingData();
            break;
        case "3":
            BookingData();
            break;
        case "4":
            RunReports();
            break;
        case "5":
            return;
        default:
            System.Console.WriteLine("Invalid Menu Choice");
            PauseAction();
            break;
    }
}

static void TrainerData(){
    Console.Clear();
    Trainer[] trainer = new Trainer[50]; //making array
    TrainerUtility trainerUtility = new TrainerUtility(trainer); //gettingtrainer utility
    TrainerReport trainerReport = new TrainerReport(trainer); //getting trainer report
    trainerUtility.GetAllTrainersFromFile(); 
    string title = @"
     __ __                             ___            _                        
    |  \  \ ___  _ _  ___  ___  ___   |_ _| _ _  ___ [_] _ _  ___  _ _  ___    
    |     |[_] || ' |[_] |/ . |/ ._]   | | | '_][_] || || ' |/ ._]| '_][_-[    
    |_|_|_|[___||_|_|[___|\_. |\___.   |_| |_|  [___||_||_|_|\___.|_|  /__/    
                          [___|                                                ";
    System.Console.WriteLine(title);
    System.Console.WriteLine("\n\t\t\t\t1. Add Trainer");
    System.Console.WriteLine("\t\t\t\t2. Edit Trainer");
    System.Console.WriteLine("\t\t\t\t3. Delete Trainer");
    System.Console.WriteLine("\t\t\t\t4. Exit");
    string userInput = Console.ReadLine();
    Console.Clear();
    //diplay trainers
    trainerReport.PrintAllTrainers();
    switch(userInput){
        case "1":
        //add
            trainerUtility.AddTrainer();
            Console.Clear();
            trainerReport.PrintAllTrainers();
            System.Console.WriteLine("\nSuccess!\n");
            PauseAction();
            break;
        case "2":
        //edit
            trainerUtility.EditTrainers();
            Console.Clear();
            trainerReport.PrintAllTrainers();
            System.Console.WriteLine("\nSuccess!\n");
            PauseAction();
            break;
        case "3":
        //delete
            trainerUtility.Delete();
            Console.Clear();
            trainerReport.PrintAllTrainers();
            System.Console.WriteLine("\nSuccess!\n");
            PauseAction();
            break;
        case "4":
            Menu();
            break;
        default:
            Console.Clear();
            System.Console.WriteLine("Invalid Menu Choice");
            PauseAction();
            break;
    }    
}

static void ListingData(){
    Console.Clear();
    Listing[] listing = new Listing[50]; //making array
    ListingUtility listingUtility = new ListingUtility(listing); //getting listing utility
    ListingReport listingReport = new ListingReport(listing); //getting listing report
    listingUtility.GetAllListingsFromFile();
    //making new title
    string title = @"
     __ __                             _    _        _    _                 
    |  \  \ ___  _ _  ___  ___  ___   | |  [_] ___ _| |_ [_] _ _  ___  ___  
    |     |[_] || ' |[_] |/ . |/ ._]  | |_ | |[_-[  | |  | || ' |/ . |[_-[  
    |_|_|_|[___||_|_|[___|\_. |\___.  |___||_|/__/  |_|  |_||_|_|\_. |/__/  
                          [___|                                  [___|      
    ";
    System.Console.WriteLine(title);
    System.Console.WriteLine("\n\t\t\t\t1. Add Listing");
    System.Console.WriteLine("\t\t\t\t2. Edit Listing");
    System.Console.WriteLine("\t\t\t\t3. Delete Listing");
    System.Console.WriteLine("\t\t\t\t4. Exit");
    string userInput = Console.ReadLine();
    Console.Clear();
    //display all listings
    listingReport.PrintAllListings();
    switch(userInput){
        case "1":
        //add
            listingUtility.AddListing();
            Console.Clear();
            listingReport.PrintAllListings();
            System.Console.WriteLine("\nSuccess!\n");
            PauseAction();
            break;
        case "2":
        //edit
            listingUtility.EditListing();
            Console.Clear();
            listingReport.PrintAllListings();
            System.Console.WriteLine("\nSuccess!\n");
            PauseAction();
            break;
        case "3":
        //delete
            listingUtility.Delete();
            Console.Clear();
            listingReport.PrintAllListings();
            System.Console.WriteLine("\nSuccess!\n");
            PauseAction();
            break;
        case "4":
            Menu();
            break;
        default:
            Console.Clear();
            System.Console.WriteLine("Invalid Menu Choice");
            PauseAction();
            break;
    }
}

static void BookingData(){
    Console.Clear();
    Transaction[] transactions = new Transaction[50]; //transaction
    Listing[] listing = new Listing[50]; //listing
    ListingUtility listingUtility = new ListingUtility(listing); //get listing utility
    ListingReport listingReport = new ListingReport(listing); // get listing report
    Trainer[] trainer = new Trainer[50];//trainer
    TrainerUtility trainerUtility = new TrainerUtility(trainer); //trainer utility
    TrainerReport trainerReport = new TrainerReport(trainer); //trrainer report
    TransactionUtility transactionUtility = new TransactionUtility(transactions, listingUtility, listingReport, trainerUtility, trainerReport); //transaction utility
    TransactionReport transactionReport = new TransactionReport(transactions); //transaction report
    //making new title
    string title = @"   
     __ __                             ___            _    _
    |  \  \ ___  _ _  ___  ___  ___   | . ] ___  ___ | |__[_] _ _  ___  ___
    |     |[_] || ' |[_] |/ . |/ ._]  | . \/ . \/ . \| / /| || ' |/ . |[_-[
    |_|_|_|[___||_|_|[___|\_. |\___.  |___/\___/\___/|_\_\|_||_|_|\_. |/__/
                          [___|                                   [___| ";
    System.Console.WriteLine(title);
    System.Console.WriteLine("\n\t\t\t1. View Available Training Session");
    System.Console.WriteLine("\t\t\t2. Book A Session");
    System.Console.WriteLine("\t\t\t3. Confirm/Cancel A Session");
    System.Console.WriteLine("\t\t\t4. Exit");
    string userInput = Console.ReadLine();
    Console.Clear();
    switch(userInput){
        case "1":
        //view open listing
            listingUtility.GetAllListingsFromFile();
            listingUtility.Sort();
            listingReport.PrintAllListings();
            PauseAction();
            break;
        case "2":
        //booking session
            listingUtility.GetAllListingsFromFile();
            trainerUtility.GetAllTrainersFromFile();
            transactionUtility.GetAllTransactionsFromFile();
            listingUtility.Sort();
            listingReport.PrintAllListings();
            transactionUtility.BookSession(); 
            Console.Clear();
            transactionUtility.GetAllTransactionsFromFile();
            transactionReport.PrintAllTransactions();
            PauseAction();
            break;
        case "3":
        //confirm/cancel session
            transactionUtility.GetAllTransactionsFromFile();
            transactionReport.PrintAllTransactions();
            transactionUtility.ConfirmCancelBooking();
            Console.Clear();
            transactionUtility.GetAllTransactionsFromFile();
            transactionReport.PrintAllTransactions();
            PauseAction();
            break;
        case "4":
            Menu();
            break;
        default:
            Console.Clear();        
            System.Console.WriteLine("Invalid Menu Choice");
            PauseAction();
            break;
    }
}   


static void RunReports(){
    Console.Clear();
    //getting all needed arrays and classes
    Transaction[] transactions = new Transaction[50];
    Listing[] listing = new Listing[50];
    ListingUtility listingUtility = new ListingUtility(listing);
    ListingReport listingReport = new ListingReport(listing);
    Trainer[] trainer = new Trainer[50];
    TrainerUtility trainerUtility = new TrainerUtility(trainer);
    TrainerReport trainerReport = new TrainerReport(trainer);
    TransactionUtility transactionUtility = new TransactionUtility(transactions, listingUtility, listingReport, trainerUtility, trainerReport);
    TransactionReport transactionReport = new TransactionReport(transactions);
    ReportUtility reportUtility = new ReportUtility(transactions);
    //new custom title
    string title = @" 
         ___                        _       
        | . \ ___  ___  ___  _ _  _| |_  ___
        |   // ._]| . \/ . \| '_]  | |  [_-[
        |_\_\\___.|  _/\___/|_|    |_|  /__/
                  |_|                       
    ";
    System.Console.WriteLine(title);
    System.Console.WriteLine("\n\t   1. Indvidual Customer Sessions");
    System.Console.WriteLine("\t   2. Historical Customer Sessions");
    System.Console.WriteLine("\t   3. Historical Revenue Report");
    System.Console.WriteLine("\t   4. Exit");
    string userInput = Console.ReadLine();
    Console.Clear();
    switch(userInput){
        case "1":
            PauseAction();
            break;
        case "2":
        //historical customer sessions
            transactionUtility.GetAllTransactionsFromFile();
            reportUtility.CustomerByDate();
            PauseAction();
            break;
        case "3":
            PauseAction();
            break;
        case "4":
            Menu();
            break;
        default:
            Console.Clear();        
            System.Console.WriteLine("Invalid Menu Choice");
            PauseAction();
            break;
    }
}

static void PauseAction(){
    System.Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Menu();
}
