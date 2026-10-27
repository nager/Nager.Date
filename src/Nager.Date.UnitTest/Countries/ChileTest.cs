using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class ChileTest() : BaseTest(CountryCode.CL)
    {
        [TestMethod]
        [DataRow(2006, 2006, 1, 1)] //Sunday, before Ley 20.983
        [DataRow(2012, 2012, 1, 1)] //Sunday, before Ley 20.983
        [DataRow(2017, 2017, 1, 2)] //Sunday, Ley 20.983
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2023, 2023, 1, 2)] //Sunday, Ley 20.983
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(1999, 1999, 6, 3)] //Thursday, before Ley 19.668
        [DataRow(2000, 2000, 6, 19)] //Thursday 22 June, moved to Monday
        [DataRow(2005, 2005, 5, 23)] //Thursday 26 May, moved to Monday
        [DataRow(2006, 2006, 6, 12)] //Thursday 15 June, moved to Monday
        public void TestCorpusChristi(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CORPUSCHRISTI-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2007)]
        [DataRow(2026)]
        public void TestNoCorpusChristi(int year)
        {
            this.AssertNoHoliday(year, "CORPUSCHRISTI-01");
        }

        [TestMethod]
        [DataRow(2007, 2007, 7, 16)]
        [DataRow(2026, 2026, 7, 16)]
        public void TestOurLadyOfMountCarmel(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "OURLADYMOUNTCARMEL-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2006)]
        public void TestNoOurLadyOfMountCarmel(int year)
        {
            this.AssertNoHoliday(year, "OURLADYMOUNTCARMEL-01");
        }

        [TestMethod]
        [DataRow(1999, 1999, 6, 29)] //Tuesday, before Ley 19.668
        [DataRow(2017, 2017, 6, 26)] //Thursday, moved to Monday
        [DataRow(2018, 2018, 7, 2)] //Friday, moved to next Monday
        [DataRow(2019, 2019, 6, 29)] //Saturday
        [DataRow(2023, 2023, 6, 26)] //Thursday, moved to Monday
        [DataRow(2024, 2024, 6, 29)] //Saturday
        [DataRow(2025, 2025, 6, 29)] //Sunday
        [DataRow(2026, 2026, 6, 29)] //Monday
        [DataRow(2027, 2027, 6, 28)] //Tuesday, moved to Monday
        [DataRow(2028, 2028, 6, 26)] //Thursday, moved to Monday
        [DataRow(2029, 2029, 7, 2)] //Friday, moved to next Monday
        public void TestSaintPeterAndSaintPaul(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SAINTSPETERPAUL-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(1999, 1999, 10, 12)] //Tuesday, before Ley 19.668
        [DataRow(2015, 2015, 10, 12)] //Monday
        [DataRow(2016, 2016, 10, 10)] //Wednesday, moved to Monday
        [DataRow(2017, 2017, 10, 9)] //Thursday, moved to Monday
        [DataRow(2018, 2018, 10, 15)] //Friday, moved to next Monday
        [DataRow(2019, 2019, 10, 12)] //Saturday
        [DataRow(2020, 2020, 10, 12)] //Monday
        [DataRow(2021, 2021, 10, 11)] //Tuesday, moved to Monday
        [DataRow(2022, 2022, 10, 10)] //Wednesday, moved to Monday
        [DataRow(2023, 2023, 10, 9)] //Thursday, moved to Monday
        [DataRow(2024, 2024, 10, 12)] //Saturday
        [DataRow(2025, 2025, 10, 12)] //Sunday
        [DataRow(2026, 2026, 10, 12)] //Monday
        [DataRow(2027, 2027, 10, 11)] //Tuesday, moved to Monday
        [DataRow(2029, 2029, 10, 15)] //Friday, moved to next Monday
        public void TestColumbusDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "COLUMBUSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 10, 31)] //Friday, first year (Ley 20.299)
        [DataRow(2015, 2015, 10, 31)]
        [DataRow(2016, 2016, 10, 31)]
        [DataRow(2017, 2017, 10, 27)] //Tuesday, moved to previous Friday
        [DataRow(2018, 2018, 11, 2)] //Wednesday, moved to next Friday
        [DataRow(2019, 2019, 10, 31)]
        [DataRow(2020, 2020, 10, 31)]
        [DataRow(2021, 2021, 10, 31)]
        [DataRow(2022, 2022, 10, 31)]
        [DataRow(2023, 2023, 10, 27)] //Tuesday, moved to previous Friday
        [DataRow(2024, 2024, 10, 31)]
        [DataRow(2025, 2025, 10, 31)]
        [DataRow(2026, 2026, 10, 31)]
        [DataRow(2027, 2027, 10, 31)]
        [DataRow(2028, 2028, 10, 27)] //Tuesday, moved to previous Friday
        [DataRow(2029, 2029, 11, 2)] //Wednesday, moved to next Friday
        public void TestReformationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "REFORMATIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2007)]
        public void TestNoReformationDay(int year)
        {
            this.AssertNoHoliday(year, "REFORMATIONDAY-01");
        }

        [TestMethod]
        [DataRow(2007, 2007, 9, 17)] //18 September is a Tuesday, first year (Ley 20.215)
        [DataRow(2018, 2018, 9, 17)] //18 September is a Tuesday
        [DataRow(2019, 2019, 9, 20)] //18 September is a Wednesday
        [DataRow(2021, 2021, 9, 17)] //18 September is a Saturday (Ley 20.983)
        [DataRow(2022, 2022, 9, 16)] //One-off (Ley 21.482)
        [DataRow(2024, 2024, 9, 20)] //18 September is a Wednesday
        [DataRow(2027, 2027, 9, 17)] //18 September is a Saturday (Ley 20.983)
        [DataRow(2029, 2029, 9, 17)] //18 September is a Tuesday
        [DataRow(2030, 2030, 9, 20)] //18 September is a Wednesday
        public void TestAdditionalNationalHoliday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALHOLIDAY-02", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2001)] //18 September is a Tuesday, before Ley 20.215
        [DataRow(2010)] //18 September is a Saturday, before Ley 20.983
        [DataRow(2016)] //18 September is a Sunday
        [DataRow(2020)] //18 September is a Friday
        [DataRow(2023)] //18 September is a Monday
        [DataRow(2025)] //18 September is a Thursday
        [DataRow(2026)] //18 September is a Friday
        [DataRow(2028)] //18 September is a Monday
        public void TestNoAdditionalNationalHoliday(int year)
        {
            this.AssertNoHoliday(year, "NATIONALHOLIDAY-02");
        }

        [TestMethod]
        [DataRow(2026, 2026, 9, 18)]
        [DataRow(2027, 2027, 9, 18)]
        public void TestNationalHoliday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALHOLIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2026, 2026, 9, 19)]
        [DataRow(2027, 2027, 9, 19)]
        public void TestArmyDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ARMYDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 6, 21)]
        [DataRow(2024, 2024, 6, 20)]
        [DataRow(2026, 2026, 6, 21)]
        [DataRow(2027, 2027, 6, 21)]
        public void TestNationalDayOfIndigenousPeoples(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALDAYINDIGENOUSPEOPLES-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020)]
        public void TestNoNationalDayOfIndigenousPeoples(int year)
        {
            this.AssertNoHoliday(year, "NATIONALDAYINDIGENOUSPEOPLES-01");
        }

        [TestMethod]
        [DataRow(2020, 2020, 10, 25)]
        [DataRow(2022, 2022, 9, 4)]
        [DataRow(2023, 2023, 12, 17)]
        public void TestNationalPlebiscite(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALPLEBISCITE-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021)]
        [DataRow(2026)]
        public void TestNoNationalPlebiscite(int year)
        {
            this.AssertNoHoliday(year, "NATIONALPLEBISCITE-01");
        }

        [TestMethod]
        [DataRow(2000, "ELECTIONDAY-01", 2000, 1, 16)]
        [DataRow(2013, "ELECTIONDAY-01", 2013, 6, 30)] //Primaries (Ley 20.640)
        [DataRow(2021, "ELECTIONDAY-01", 2021, 5, 15)] //First day of a two-day election, a Saturday
        [DataRow(2021, "ELECTIONDAY-02", 2021, 5, 16)]
        [DataRow(2024, "ELECTIONDAY-01", 2024, 10, 27)] //Only the Sunday of the two-day election (Ley 21.693)
        [DataRow(2025, "ELECTIONDAY-03", 2025, 12, 14)]
        public void TestElectionDay(int year, string holidayId, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, holidayId, observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2002, "ELECTIONDAY-01")]
        [DataRow(2024, "ELECTIONDAY-02")] //Saturday 26 October 2024 was a working day
        [DataRow(2026, "ELECTIONDAY-01")]
        public void TestNoElectionDay(int year, string holidayId)
        {
            this.AssertNoHoliday(year, holidayId);
        }

        [TestMethod]
        [DataRow(2002, 2002, 4, 24)]
        [DataRow(2017, 2017, 4, 19)]
        public void TestNationalCensus(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALCENSUS-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2012)]
        [DataRow(2024)]
        public void TestNoNationalCensus(int year)
        {
            this.AssertNoHoliday(year, "NATIONALCENSUS-01");
        }

        [TestMethod]
        [DataRow(2013, 2013, 6, 7)] //First year (Ley 20.663)
        [DataRow(2026, 2026, 6, 7)]
        public void TestBattleOfArica(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "BATTLEOFARICA-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "BATTLEOFARICA-01", "CL-AP");
        }

        [TestMethod]
        [DataRow(2012)]
        public void TestNoBattleOfArica(int year)
        {
            this.AssertNoHoliday(year, "BATTLEOFARICA-01");
        }

        [TestMethod]
        [DataRow(2014, 2014, 8, 20, "CL-BI")] //First year (Ley 20.768)
        [DataRow(2018, 2018, 8, 20, "CL-BI")] //Before Región de Ñuble (Ley 21.033)
        [DataRow(2019, 2019, 8, 20, "CL-NB")]
        [DataRow(2026, 2026, 8, 20, "CL-NB")]
        public void TestBirthOfBernardoOHiggins(int year, int observedYear, int month, int day, string subdivisionCode)
        {
            this.AssertObservedDate(year, "BIRTHOFBERNARDOOHIGGINS-01", observedYear, month, day);
            this.AssertSubdivisionCodes(year, "BIRTHOFBERNARDOOHIGGINS-01", subdivisionCode);
        }

        [TestMethod]
        [DataRow(2013)]
        public void TestNoBirthOfBernardoOHiggins(int year)
        {
            this.AssertNoHoliday(year, "BIRTHOFBERNARDOOHIGGINS-01");
        }

        [TestMethod]
        public void TestBicentennial2010()
        {
            var year = 2010;

            this.AssertObservedDate(year, "BICENTENNIAL-01", year, 9, 17);
            this.AssertObservedDate(year, "BICENTENNIAL-02", year, 9, 20);
        }

        [TestMethod]
        [DataRow(2009)]
        [DataRow(2011)]
        public void TestNoBicentennial(int year)
        {
            this.AssertNoHoliday(year, "BICENTENNIAL-01");
            this.AssertNoHoliday(year, "BICENTENNIAL-02");
        }

        [TestMethod]
        public void TestPapalVisit2018()
        {
            var year = 2018;

            this.AssertObservedDate(year, "PAPALVISIT-01", year, 1, 16);
            this.AssertSubdivisionCodes(year, "PAPALVISIT-01", "CL-RM");

            this.AssertObservedDate(year, "PAPALVISIT-02", year, 1, 17);
            this.AssertSubdivisionCodes(year, "PAPALVISIT-02", "CL-AR");

            this.AssertObservedDate(year, "PAPALVISIT-03", year, 1, 18);
            this.AssertSubdivisionCodes(year, "PAPALVISIT-03", "CL-TA");
        }

        [TestMethod]
        [DataRow(2017)]
        [DataRow(2019)]
        public void TestNoPapalVisit(int year)
        {
            this.AssertNoHoliday(year, "PAPALVISIT-01");
            this.AssertNoHoliday(year, "PAPALVISIT-02");
            this.AssertNoHoliday(year, "PAPALVISIT-03");
        }
    }
}
