using FluentAssertions;
using Moq;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.Load.ItemActions;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Test.Components;

namespace WatchList.Test.CoreTest.WatchItemServiceTest.DataLoadingTest
{
    public class DownloadDataByDeleteGradeRuleTest
    {
        public static IEnumerable<object[]> ListsWithTwoSameElementsWithReplaceItem() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733b2319a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2010, 04, 12, 00, 00, 00), 6),
                },
                DialogReplaceItemQuestion.AllYes,
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2010, 04, 12, 00, 00, 00), 6),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> ListsWithTwoSameElementsWithNotReplaceItem() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733b2319a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733bff19a7")),
                },
                DialogReplaceItemQuestion.AllNo,
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        public static IEnumerable<object[]> ListsWithTwoSameElements() => new List<object[]>
        {
            new object[]
            {
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 8),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733b2319a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733bff19a7")),
                },
                new Dictionary<string, DialogReplaceItemQuestion>()
                {
                    ["Тор"] = DialogReplaceItemQuestion.Yes,
                    ["Хэнкок"] = DialogReplaceItemQuestion.No,
                },
                new List<WatchItem>()
                {
                    new WatchItem("Тор", 1, StatusCinema.Viewed, TypeCinema.Cartoon, Guid.Parse("18d4a732-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2013, 05, 11, 00, 00, 00), 7),
                    new WatchItem("Хэнкок", 2, StatusCinema.Look, TypeCinema.Movie, Guid.Parse("28d4a999-ca7a-4b24-a78a-65733ba419a7"), new DateTime(2015, 04, 12, 00, 00, 00), 9),
                    new WatchItem("Человек-паук", 2, StatusCinema.Planned, TypeCinema.Series, Guid.Parse("38d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Драйв", 2, StatusCinema.Planned, TypeCinema.Movie, Guid.Parse("48d4a999-ca7a-4b24-a78a-65733ba419a7")),
                    new WatchItem("Твое имя", 2, StatusCinema.Thrown, TypeCinema.Anime, Guid.Parse("58d4a999-ca7a-4b24-a78a-65733ba419a7")),
                },
            },
        };

        [Theory]
        [MemberData(nameof(ListsWithTwoSameElementsWithReplaceItem))]
        [MemberData(nameof(ListsWithTwoSameElementsWithNotReplaceItem))]
        public async Task Add_Data_File_And_Replace_Duplicate_Element(List<WatchItem> items, List<WatchItem> addDownloadItem, DialogReplaceItemQuestion dialogReplaceItem, List<WatchItem> expectItems)
        {
            // Arrange
            var logger = new TestLogger();
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext, logger);
            var dbContextDownloadItem = new TestAppDbContextFactory().Create();
            var watchItemRepository = new WatchItemRepository(dbContext, logger);

            var messageBox = new Mock<IMessageBox>();
            messageBox.Setup(foo => foo.ShowDataReplaceQuestion(It.IsAny<string>())).ReturnsAsync(dialogReplaceItem);

            var service = new DownloadDataService(watchItemRepository, messageBox.Object, logger);
            var loadRuleConfig = new TestLoadRuleConfig()
            {
                DeleteGrade = false,
                ActionsWithDuplicates = new ActionDuplicateItems(true, new List<DuplicateLoadingRules>
                        {
                            new DuplicateLoadingRules(DuplicateLoadingRules.UpdateDuplicate, true),
                            new DuplicateLoadingRules(DuplicateLoadingRules.CaseSensitive, true),
                        }),
            };
            var loadRule = new TestAggregateLoadRule(itemRepository, loadRuleConfig);
            var repositoryDataDownload = new WatchItemRepository(dbContextDownloadItem, logger);

            dbContext.AddRange(items);
            dbContextDownloadItem.AddRange(addDownloadItem);
            dbContext.SaveChanges();
            dbContextDownloadItem.SaveChanges();

            // Act
            service.Download(repositoryDataDownload, loadRule);
            var actualItems = dbContext.WatchItem.ToList();

            // Assert
            actualItems.Should().Equal(expectItems);
        }

        [Theory]
        [MemberData(nameof(ListsWithTwoSameElementsWithReplaceItem))]
        [MemberData(nameof(ListsWithTwoSameElementsWithNotReplaceItem))]
        public async Task Add_Data_File_And_Replace_Duplicate_ElementAsync(List<WatchItem> items, List<WatchItem> addDownloadItem, DialogReplaceItemQuestion dialogReplaceItem, List<WatchItem> expectItems)
        {
            // Arrange
            var logger = new TestLogger();
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext, logger);
            var watchItemRepository = new WatchItemRepository(dbContext, logger);
            var dbContextDownloadItem = new TestAppDbContextFactory().Create();

            var messageBox = new Mock<IMessageBox>();
            messageBox.Setup(foo => foo.ShowDataReplaceQuestion(It.IsAny<string>())).ReturnsAsync(dialogReplaceItem);

            var service = new DownloadDataService(watchItemRepository, messageBox.Object, logger);
            var loadRuleConfig = new TestLoadRuleConfig()
            {
                DeleteGrade = false,
                ActionsWithDuplicates = new ActionDuplicateItems(true, new List<DuplicateLoadingRules>
                        {
                            new DuplicateLoadingRules(DuplicateLoadingRules.UpdateDuplicate, true),
                            new DuplicateLoadingRules(DuplicateLoadingRules.CaseSensitive, true),
                        }),
            };
            var loadRule = new TestAggregateLoadRule(itemRepository, loadRuleConfig);
            var repositoryDataDownload = new WatchItemRepository(dbContextDownloadItem, logger);

            dbContext.AddRange(items);
            dbContextDownloadItem.AddRange(addDownloadItem);
            await dbContext.SaveChangesAsync();
            await dbContextDownloadItem.SaveChangesAsync();

            // Act
            service.Download(repositoryDataDownload, loadRule);
            var actualItems = dbContext.WatchItem.ToList();

            // Assert
            actualItems.Should().Equal(expectItems);
        }

        [Theory]
        [MemberData(nameof(ListsWithTwoSameElements))]
        public async Task Add_Data_File_And_One_Replace_And_Not_Replace_Duplicate_Element(List<WatchItem> items, List<WatchItem> addDownloadItem, Dictionary<string, DialogReplaceItemQuestion> dictionaryAddItem, List<WatchItem> expectItems)
        {
            // Arrange
            var logger = new TestLogger();
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext, logger);
            var dbContextDownloadItem = new TestAppDbContextFactory().Create();
            var watchItemRepository = new WatchItemRepository(dbContext, logger);

            var messageBox = new Mock<IMessageBox>();
            foreach (var item in dictionaryAddItem)
            {
                messageBox.Setup(foo => foo.ShowDataReplaceQuestion(item.Key)).ReturnsAsync(item.Value);
            }

            var service = new DownloadDataService(watchItemRepository, messageBox.Object, logger);
            var loadRuleConfig = new TestLoadRuleConfig()
            {
                DeleteGrade = false,
                ActionsWithDuplicates = new ActionDuplicateItems(true, new List<DuplicateLoadingRules>
                        {
                            new DuplicateLoadingRules(DuplicateLoadingRules.UpdateDuplicate, true),
                            new DuplicateLoadingRules(DuplicateLoadingRules.CaseSensitive, true),
                        }),
            };
            var loadRule = new TestAggregateLoadRule(itemRepository, loadRuleConfig);
            var repositoryDataDownload = new WatchItemRepository(dbContextDownloadItem, logger);

            dbContext.AddRange(items);
            dbContextDownloadItem.AddRange(addDownloadItem);
            dbContext.SaveChanges();
            dbContextDownloadItem.SaveChanges();

            // Act
            service.Download(repositoryDataDownload, loadRule);
            var actualItems = dbContext.WatchItem.ToList();

            // Assert
            actualItems.Should().Equal(expectItems);
        }

        [Theory]
        [MemberData(nameof(ListsWithTwoSameElements))]
        public async Task Add_Data_File_And_One_Replace_And_Not_Replace_Duplicate_ElementAsync(List<WatchItem> items, List<WatchItem> addDownloadItem, Dictionary<string, DialogReplaceItemQuestion> dictionaryAddItem, List<WatchItem> expectItems)
        {
            // Arrange
            var logger = new TestLogger();
            var dbContext = new TestAppDbContextFactory().Create();
            var itemRepository = new WatchItemRepository(dbContext, logger);
            var dbContextDownloadItem = new TestAppDbContextFactory().Create();
            var watchItemRepository = new WatchItemRepository(dbContext, logger);

            var messageBox = new Mock<IMessageBox>();
            foreach (var item in dictionaryAddItem)
            {
                messageBox.Setup(foo => foo.ShowDataReplaceQuestion(item.Key)).ReturnsAsync(item.Value);
            }

            var service = new DownloadDataService(watchItemRepository, messageBox.Object, logger);
            var loadRuleConfig = new TestLoadRuleConfig()
            {
                DeleteGrade = false,
                ActionsWithDuplicates = new ActionDuplicateItems(true, new List<DuplicateLoadingRules>
                        {
                            new DuplicateLoadingRules(DuplicateLoadingRules.UpdateDuplicate, true),
                            new DuplicateLoadingRules(DuplicateLoadingRules.CaseSensitive, true),
                        }),
            };
            var loadRule = new TestAggregateLoadRule(itemRepository, loadRuleConfig);
            var repositoryDataDownload = new WatchItemRepository(dbContextDownloadItem, logger);

            dbContext.AddRange(items);
            dbContextDownloadItem.AddRange(addDownloadItem);
            await dbContext.SaveChangesAsync();
            await dbContextDownloadItem.SaveChangesAsync();

            // Act
            service.Download(repositoryDataDownload, loadRule);
            var actualItems = dbContext.WatchItem.ToList();

            // Assert
            actualItems.Should().Equal(expectItems);
        }
    }
}
