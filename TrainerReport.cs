namespace mis_221_pa_5_wcklecka
{
    public class TrainerReport
    {
        Trainer[] trainers; //getting trainers

        public TrainerReport(Trainer[] trainers){
            this.trainers = trainers;
        }

        //diplay trainers
        public void PrintAllTrainers(){
            for(int i = 0; i < Trainer.GetCount(); i++){
                System.Console.WriteLine(trainers[i].ToString());
            }
        }
    }
}