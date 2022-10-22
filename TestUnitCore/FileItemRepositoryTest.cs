using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;
using ListWatchedMoviesAndSeries.Repository;
using Xunit;

namespace TestUnitCore
{
    public class FileItemRepositoryTest
    {
        //Test file path.
        const string PathFileJson = "FileDate.json";

        [Theory]
        [MemberData(nameof(TestData))]
        public void SaveTest(string expectedDateJson, List<WatchItem> items)
        {
            //Arrange
            var fileProvider = new MemoryFileProvider();
            var fileRepository = new FileWatchItemRepository(PathFileJson, fileProvider);
            //Act
            fileRepository.Save(items);
            var actualJson = fileProvider.ReadJson(PathFileJson);
            //Assert
            Assert.Equal(expectedDateJson, actualJson);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void GetAllTest(string dateJsonFile, List<WatchItem> expectItem)
        {
            //Arrange
            var fileProvider = new MemoryFileProvider().WriteJson(PathFileJson, dateJsonFile);
            var fileRepository = new FileWatchItemRepository(PathFileJson, fileProvider);
            //Act
            var actualDateJson = fileRepository.GetAll();
            //Assert
            Assert.Equal(expectItem, actualDateJson);
        }

        //Date
        public static IEnumerable<object[]> TestData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    @"[]",
                    new List<WatchItem>()
                },
                new object[]
                {
                    @"[
  {
    ""Id"": ""18d4a732-ca7a-4b24-a78a-65733ba419a7"",
    ""Name"": ""Тор"",
    ""Detail"": {
      ""DateWatch"": ""2022-08-10T00:00:00"",
      ""Grade"": ""8""
    },
    ""Type"": 1,
    ""NumberSequel"": 1
  }
]",
                    new List<WatchItem>
                    {
                        new("Тор", 1, new DateTime(2022,08,10, 00, 00, 00), 8, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7")),
                    },
                },
                new object[]
                {
                    @"[
  {
    ""Id"": ""18d4a732-ca7a-4b24-a78a-65733ba419a7"",
    ""Name"": ""Тор"",
    ""Detail"": {
      ""DateWatch"": ""2022-08-10T00:00:00"",
      ""Grade"": ""8""
    },
    ""Type"": 1,
    ""NumberSequel"": 1
  },
  {
    ""Id"": ""5bbb70a3-0be8-4970-a95e-a5fbad2d1c72"",
    ""Name"": ""Ход королевы"",
    ""Detail"": {
      ""DateWatch"": null,
      ""Grade"": """"
    },
    ""Type"": 2,
    ""NumberSequel"": 1
  },
  {
    ""Id"": ""7a7d2f55-03e9-450e-955e-4e132c956d7e"",
    ""Name"": ""Хоббит"",
    ""Detail"": {
      ""DateWatch"": ""2022-03-22T00:00:00"",
      ""Grade"": ""10""
    },
    ""Type"": 1,
    ""NumberSequel"": 1
  }
]",
                    new List<WatchItem>
                    {
                        new("Тор", 1, new DateTime(2022,08,10, 00, 00, 00), 8, TypeCinema.Movie, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7")),
                        new("Ход королевы", 1, null, null, TypeCinema.Series, Guid.Parse("5bbb70a3-0be8-4970-a95e-a5fbad2d1c72")),
                        new("Хоббит", 1, new DateTime(2022,03,22, 00, 00, 00), 10, TypeCinema.Movie, Guid.Parse("7a7d2f55-03e9-450e-955e-4e132c956d7e"))
                    }
                }
            };
        }
    }
}
