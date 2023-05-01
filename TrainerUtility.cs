namespace mis_221_pa_5_wcklecka
{
    public class TrainerUtility
    {
        public Trainer[] trainer;

        public TrainerUtility(Trainer[] trainer){
            this.trainer = trainer;
        }

        public void GetAllTrainersFromFile(){
            //open file
            StreamReader trainerFile = new StreamReader("trainers.txt");
            //process file
            Trainer.SetCount(0);
            string line = trainerFile.ReadLine();
            while(line != null){
                string[] temp =  line.Split('#');
                trainer[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                line = trainerFile.ReadLine();
            }
            //close file
            trainerFile.Close();
        }

        public void AddTrainer(){
            System.Console.WriteLine("Please enter the trainer ID");
            Trainer addTrainer = new Trainer();//making new trainer
            addTrainer.SetTrainerID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the trainer name");
            addTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainers mailing address");
            addTrainer.SetMailingAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainers email address");
            addTrainer.SetEmailAddress(Console.ReadLine());

            //adding trainer to count
            trainer[Trainer.GetCount()] = addTrainer;
            Trainer.IncCount(); 
            
            //saving to file
            Save();
        }

        private void Save() {
            //open file
            StreamWriter outFile = new StreamWriter("trainers.txt");
            //process file
            for(int i = 0; i < Trainer.GetCount(); i++) {
                outFile.WriteLine(trainer[i].ToFile());
            }
            //close file
            outFile.Close();
        }

        public int Find(int searchVal){
            for(int i = 0; i < Trainer.GetCount(); i++){
                if(trainer[i].GetTrainerID() == searchVal){
                    return i;
                }

            }
            return -1;
        }
        public int Find(string searchVal){
            for(int i = 0; i < Trainer.GetCount(); i++){
                if(trainer[i].GetTrainerName() == searchVal){
                    return i;
                }

            }
            return -1;
        }

        public void EditTrainers(){
            System.Console.WriteLine("What is the trainer ID you are trying to edit?");
            int searchVal = int.Parse(Console.ReadLine());
            //finding user input
            int foundIndex = Find(searchVal);
            if(foundIndex != -1){
                //setting trainer
                System.Console.WriteLine("Please enter the trainer name");
                trainer[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the mailing address");
                trainer[foundIndex].SetMailingAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the email address");
                trainer[foundIndex].SetEmailAddress(Console.ReadLine());
                
                //saving trainer
                Save();
            }
            else {
                System.Console.WriteLine("Trainer ID not found");
            }
        }

        public void Delete(){
            System.Console.WriteLine("What is the ID of the Trainer you would like to delete");
            int searchVal = int.Parse(Console.ReadLine());
            //finding input
            int foundIndex = Find(searchVal);
            if(foundIndex != -1){
                trainer[foundIndex].Delete(); //delete method
                //saving delete
                Save();
            }
            else{
                System.Console.WriteLine("The Trainer ID is invalid");
            }
        }   

    }
}