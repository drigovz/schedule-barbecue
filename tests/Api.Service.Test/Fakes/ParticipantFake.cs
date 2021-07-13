using Api.Domain.DTOs.Barbecues;
using Api.Domain.DTOs.Participants;

namespace Api.Service.Test.Fakes
{
   public class ParticipantFake
   {
      public int Id { get; set; }

      public string Name { get; private set; }

      public decimal ContribuitionValue { get; private set; }

      public BarbecueDTO Barbecue { get; set; }

      public int BarbecueId { get; set; }

      private decimal _sugestedValue;

      public decimal SugestedValue
      {
         get { return _sugestedValue; }
         set
         {
            _sugestedValue = value > 0 ? value : 0;
         }
      }

      private decimal _sugestedValueWithDink;

      public decimal SugestedValueWithDink
      {
         get { return _sugestedValueWithDink; }
         set
         {
            _sugestedValueWithDink = value > 0 ? value : 0;
         }
      }

      public ParticipantDTO participantDTO { get; set; }

      public ParticipantFake()
      {
         InitFakeDataObjects();
      }

      protected void InitFakeDataObjects()
      {
         Id = Faker.RandomNumber.Next(100);
         Name = Faker.Name.FullName();
         ContribuitionValue = Faker.RandomNumber.Next(10, 40);
         SugestedValue = Faker.RandomNumber.Next(0, 50);
         SugestedValueWithDink = Faker.RandomNumber.Next(0, 50);
         BarbecueId = Faker.RandomNumber.Next(10, 40);

         participantDTO = new ParticipantDTO
         {
            Name = Faker.Name.FullName(),
            ContribuitionValue = Faker.RandomNumber.Next(10, 40),
            SugestedValue = Faker.RandomNumber.Next(0, 50),
            SugestedValueWithDink = Faker.RandomNumber.Next(0, 50),
            BarbecueId = Faker.RandomNumber.Next(10, 40)
         };
      }
   }
}