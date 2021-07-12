using Api.Domain.DTOs.Barbecues;
using System;
using System.Collections.Generic;

namespace Api.Service.Test.Fakes
{
   public class BarbecueFake
   {
      public int Id { get; set; }
      public DateTime Date { get; set; }
      public string Description { get; set; }
      public string AdditionalNotes { get; set; }
      public int TotalParticipants { get; set; }
      public int TotalValue { get; set; }

      public List<BarbecueDTO> barbecues { get; set; } = new List<BarbecueDTO>();
      public BarbecueDTO barbecueDto { get; set; } = new BarbecueDTO();
      public BarbecueDetailsDTO barbecueDetailsDto { get; set; } = new BarbecueDetailsDTO();

      public BarbecueFake()
      {
         InitFakeDataObjects();
      }

      protected void InitFakeDataObjects()
      {
         Id = Faker.RandomNumber.Next(100);
         Date = Faker.Identification.DateOfBirth();
         Description = Faker.Lorem.Words(30).ToString();
         AdditionalNotes = Faker.Lorem.Words(50).ToString();
         TotalParticipants = Faker.RandomNumber.Next(5);
         TotalValue = Faker.RandomNumber.Next(20);

         for (int i = 0; i < 10; i++)
         {
            var dto = new BarbecueDTO()
            {
               Id = Faker.RandomNumber.Next(100),
               Date = Faker.Identification.DateOfBirth(),
               Description = Faker.Lorem.Words(30).ToString(),
               AdditionalNotes = Faker.Lorem.Words(50).ToString()
            };

            barbecues.Add(dto);
         }

         barbecueDto = new BarbecueDTO()
         {
            Id = Id,
            Date = Date,
            Description = Description,
            AdditionalNotes = AdditionalNotes
         };

         barbecueDetailsDto = new BarbecueDetailsDTO()
         {
            Id = Id,
            Date = Date,
            Description = Description,
            AdditionalNotes = AdditionalNotes,
            TotalParticipants = Faker.RandomNumber.Next(5),
            TotalValue = Faker.RandomNumber.Next(20)
         };
      }
   }
}