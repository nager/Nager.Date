using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    /// <summary>
    /// Tests for the Greenland holiday provider (2008-2034).
    /// Every expected value refers to one of the official sources [A]-[H] listed in the remarks.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Greenland has no statutory list of days off. Church holidays (folkekirkens helligdage) are holidays by older
    /// Danish law and days off through the collective agreements, other days off are set by agreements and circulars
    /// (Naalakkersuisut, svarnotat FM2024/57 1. and 2. behandling).
    /// Easter dates are calculated independently with the Gregorian computus.
    /// </para>
    /// <para>Sources used for the expected values:</para>
    /// <list type="bullet">
    /// <item><description>[A] Hjemmestyrets bekendtgørelse nr. 26 af 11. november 2008 om flagdage
    /// https://nalunaarutit.gl/arkiv/gh.gl-love/dk/2008/bkg/bkg_nr_26-2008_dk.htm</description></item>
    /// <item><description>[B] Selvstyrets bekendtgørelse nr. 55 af 11. juli 2025 om flagdage, Annex 1 (since 2025-08-01)
    /// https://nalunaarutit.gl/Groenlandsk-lovgivning/2025/Selvstyrets-bekendtgoerelse-nr-55-af-11_07_2025</description></item>
    /// <item><description>[C] Naalakkersuisut, svarnotat FM2024/57, 1. behandling (16.04.2024): "befolkningen fri på folkekirkens helligdage,
    /// fordi det reguleres gennem overenskomsterne"
    /// https://ina.gl/media/fbqmf3c5/pkt57_fm2024_bf33_solhvervsdagen_sn_1beh_da.pdf</description></item>
    /// <item><description>[D] Naalakkersuisut, svarnotat FM2024/57, 2. behandling (06.05.2024): "Store Bededag fortsat vil være en helligdag"
    /// https://inatsisartut.gl/media/wdzbt3hn/pkt57_fm2024_bf33_solhvervsdagen_sn_2beh_da.pdf</description></item>
    /// <item><description>[E] Lov nr. 214 af 6. marts 2023, § 8: "Loven gælder ikke for Færøerne og Grønland."
    /// https://www.retsinformation.dk/eli/lta/2023/214</description></item>
    /// <item><description>[F] Naalakkersuisut, § 37-svar 202/2020: National Day is a full day off (søgnehelligdag) under Cirkulære nr. 3/92
    /// https://ina.gl/media/uj4ht2t2/202_2020_officiel_maerkedag_ppol_svar.pdf</description></item>
    /// <item><description>[G] Medarbejder- og Kompetencestyrelsen, Medst.nr. 004-26 (03.02.2026): "helligtrekongersdag som en halv
    /// søgnehelligdag" for state employees in Greenland
    /// https://cirkulaere.medst.dk/media/d4qjfqnj/004-26.pdf</description></item>
    /// <item><description>[H] GrønlandsBANKEN closing days: Friday after Ascension Day, Store Bededag, 21 June, 24 December, 31 December
    /// https://www.banken.gl/da/kontakt/</description></item>
    /// </list>
    /// </remarks>
    [TestClass]
    public class GreenlandTest() : BaseTest(CountryCode.GL)
    {
        #region Fixed holidays

        [TestMethod]
        [DataRow(2008, 2008, 1, 1)]
        [DataRow(2009, 2009, 1, 1)]
        [DataRow(2010, 2010, 1, 1)]
        [DataRow(2011, 2011, 1, 1)]
        [DataRow(2012, 2012, 1, 1)]
        [DataRow(2013, 2013, 1, 1)]
        [DataRow(2014, 2014, 1, 1)]
        [DataRow(2015, 2015, 1, 1)]
        [DataRow(2016, 2016, 1, 1)]
        [DataRow(2017, 2017, 1, 1)]
        [DataRow(2018, 2018, 1, 1)]
        [DataRow(2019, 2019, 1, 1)]
        [DataRow(2020, 2020, 1, 1)]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2023, 2023, 1, 1)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        [DataRow(2028, 2028, 1, 1)]
        [DataRow(2029, 2029, 1, 1)]
        [DataRow(2030, 2030, 1, 1)]
        [DataRow(2031, 2031, 1, 1)]
        [DataRow(2032, 2032, 1, 1)]
        [DataRow(2033, 2033, 1, 1)]
        [DataRow(2034, 2034, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], church holiday [C]
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 1, 6)]
        [DataRow(2009, 2009, 1, 6)]
        [DataRow(2010, 2010, 1, 6)]
        [DataRow(2011, 2011, 1, 6)]
        [DataRow(2012, 2012, 1, 6)]
        [DataRow(2013, 2013, 1, 6)]
        [DataRow(2014, 2014, 1, 6)]
        [DataRow(2015, 2015, 1, 6)]
        [DataRow(2016, 2016, 1, 6)]
        [DataRow(2017, 2017, 1, 6)]
        [DataRow(2018, 2018, 1, 6)]
        [DataRow(2019, 2019, 1, 6)]
        [DataRow(2020, 2020, 1, 6)]
        [DataRow(2021, 2021, 1, 6)]
        [DataRow(2022, 2022, 1, 6)]
        [DataRow(2023, 2023, 1, 6)]
        [DataRow(2024, 2024, 1, 6)]
        [DataRow(2025, 2025, 1, 6)]
        [DataRow(2026, 2026, 1, 6)]
        [DataRow(2027, 2027, 1, 6)]
        [DataRow(2028, 2028, 1, 6)]
        [DataRow(2029, 2029, 1, 6)]
        [DataRow(2030, 2030, 1, 6)]
        [DataRow(2031, 2031, 1, 6)]
        [DataRow(2032, 2032, 1, 6)]
        [DataRow(2033, 2033, 1, 6)]
        [DataRow(2034, 2034, 1, 6)]
        public void TestEpiphany(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], half day off for state employees [G]
            this.AssertObservedDate(year, "EPIPHANY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 6, 21)]
        [DataRow(2009, 2009, 6, 21)]
        [DataRow(2010, 2010, 6, 21)]
        [DataRow(2011, 2011, 6, 21)]
        [DataRow(2012, 2012, 6, 21)]
        [DataRow(2013, 2013, 6, 21)]
        [DataRow(2014, 2014, 6, 21)]
        [DataRow(2015, 2015, 6, 21)]
        [DataRow(2016, 2016, 6, 21)]
        [DataRow(2017, 2017, 6, 21)]
        [DataRow(2018, 2018, 6, 21)]
        [DataRow(2019, 2019, 6, 21)]
        [DataRow(2020, 2020, 6, 21)]
        [DataRow(2021, 2021, 6, 21)]
        [DataRow(2022, 2022, 6, 21)]
        [DataRow(2023, 2023, 6, 21)]
        [DataRow(2024, 2024, 6, 21)]
        [DataRow(2025, 2025, 6, 21)]
        [DataRow(2026, 2026, 6, 21)]
        [DataRow(2027, 2027, 6, 21)]
        [DataRow(2028, 2028, 6, 21)]
        [DataRow(2029, 2029, 6, 21)]
        [DataRow(2030, 2030, 6, 21)]
        [DataRow(2031, 2031, 6, 21)]
        [DataRow(2032, 2032, 6, 21)]
        [DataRow(2033, 2033, 6, 21)]
        [DataRow(2034, 2034, 6, 21)]
        public void TestNationalDay(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], full day off [F], bank closing day [H]
            this.AssertObservedDate(year, "ULLORTUNEQ-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 12, 24)]
        [DataRow(2009, 2009, 12, 24)]
        [DataRow(2010, 2010, 12, 24)]
        [DataRow(2011, 2011, 12, 24)]
        [DataRow(2012, 2012, 12, 24)]
        [DataRow(2013, 2013, 12, 24)]
        [DataRow(2014, 2014, 12, 24)]
        [DataRow(2015, 2015, 12, 24)]
        [DataRow(2016, 2016, 12, 24)]
        [DataRow(2017, 2017, 12, 24)]
        [DataRow(2018, 2018, 12, 24)]
        [DataRow(2019, 2019, 12, 24)]
        [DataRow(2020, 2020, 12, 24)]
        [DataRow(2021, 2021, 12, 24)]
        [DataRow(2022, 2022, 12, 24)]
        [DataRow(2023, 2023, 12, 24)]
        [DataRow(2024, 2024, 12, 24)]
        [DataRow(2025, 2025, 12, 24)]
        [DataRow(2026, 2026, 12, 24)]
        [DataRow(2027, 2027, 12, 24)]
        [DataRow(2028, 2028, 12, 24)]
        [DataRow(2029, 2029, 12, 24)]
        [DataRow(2030, 2030, 12, 24)]
        [DataRow(2031, 2031, 12, 24)]
        [DataRow(2032, 2032, 12, 24)]
        [DataRow(2033, 2033, 12, 24)]
        [DataRow(2034, 2034, 12, 24)]
        public void TestChristmasEve(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], bank closing day [H]
            this.AssertObservedDate(year, "CHRISTMASEVE-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 12, 25)]
        [DataRow(2009, 2009, 12, 25)]
        [DataRow(2010, 2010, 12, 25)]
        [DataRow(2011, 2011, 12, 25)]
        [DataRow(2012, 2012, 12, 25)]
        [DataRow(2013, 2013, 12, 25)]
        [DataRow(2014, 2014, 12, 25)]
        [DataRow(2015, 2015, 12, 25)]
        [DataRow(2016, 2016, 12, 25)]
        [DataRow(2017, 2017, 12, 25)]
        [DataRow(2018, 2018, 12, 25)]
        [DataRow(2019, 2019, 12, 25)]
        [DataRow(2020, 2020, 12, 25)]
        [DataRow(2021, 2021, 12, 25)]
        [DataRow(2022, 2022, 12, 25)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 25)]
        [DataRow(2028, 2028, 12, 25)]
        [DataRow(2029, 2029, 12, 25)]
        [DataRow(2030, 2030, 12, 25)]
        [DataRow(2031, 2031, 12, 25)]
        [DataRow(2032, 2032, 12, 25)]
        [DataRow(2033, 2033, 12, 25)]
        [DataRow(2034, 2034, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], church holiday [C]
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 12, 26)]
        [DataRow(2009, 2009, 12, 26)]
        [DataRow(2010, 2010, 12, 26)]
        [DataRow(2011, 2011, 12, 26)]
        [DataRow(2012, 2012, 12, 26)]
        [DataRow(2013, 2013, 12, 26)]
        [DataRow(2014, 2014, 12, 26)]
        [DataRow(2015, 2015, 12, 26)]
        [DataRow(2016, 2016, 12, 26)]
        [DataRow(2017, 2017, 12, 26)]
        [DataRow(2018, 2018, 12, 26)]
        [DataRow(2019, 2019, 12, 26)]
        [DataRow(2020, 2020, 12, 26)]
        [DataRow(2021, 2021, 12, 26)]
        [DataRow(2022, 2022, 12, 26)]
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2024, 2024, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 26)]
        [DataRow(2027, 2027, 12, 26)]
        [DataRow(2028, 2028, 12, 26)]
        [DataRow(2029, 2029, 12, 26)]
        [DataRow(2030, 2030, 12, 26)]
        [DataRow(2031, 2031, 12, 26)]
        [DataRow(2032, 2032, 12, 26)]
        [DataRow(2033, 2033, 12, 26)]
        [DataRow(2034, 2034, 12, 26)]
        public void TestStStephensDay(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], church holiday [C]
            this.AssertObservedDate(year, "STSTEPHENSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 12, 31)]
        [DataRow(2009, 2009, 12, 31)]
        [DataRow(2010, 2010, 12, 31)]
        [DataRow(2011, 2011, 12, 31)]
        [DataRow(2012, 2012, 12, 31)]
        [DataRow(2013, 2013, 12, 31)]
        [DataRow(2014, 2014, 12, 31)]
        [DataRow(2015, 2015, 12, 31)]
        [DataRow(2016, 2016, 12, 31)]
        [DataRow(2017, 2017, 12, 31)]
        [DataRow(2018, 2018, 12, 31)]
        [DataRow(2019, 2019, 12, 31)]
        [DataRow(2020, 2020, 12, 31)]
        [DataRow(2021, 2021, 12, 31)]
        [DataRow(2022, 2022, 12, 31)]
        [DataRow(2023, 2023, 12, 31)]
        [DataRow(2024, 2024, 12, 31)]
        [DataRow(2025, 2025, 12, 31)]
        [DataRow(2026, 2026, 12, 31)]
        [DataRow(2027, 2027, 12, 31)]
        [DataRow(2028, 2028, 12, 31)]
        [DataRow(2029, 2029, 12, 31)]
        [DataRow(2030, 2030, 12, 31)]
        [DataRow(2031, 2031, 12, 31)]
        [DataRow(2032, 2032, 12, 31)]
        [DataRow(2033, 2033, 12, 31)]
        [DataRow(2034, 2034, 12, 31)]
        public void TestNewYearsEve(int year, int observedYear, int month, int day)
        {
            //Flag day [B], bank closing day [H]
            this.AssertObservedDate(year, "NEWYEARSEVE-01", observedYear, month, day);
        }

        #endregion

        #region Easter based holidays

        [TestMethod]
        [DataRow(2008, 2008, 3, 20)]
        [DataRow(2009, 2009, 4, 9)]
        [DataRow(2010, 2010, 4, 1)]
        [DataRow(2011, 2011, 4, 21)]
        [DataRow(2012, 2012, 4, 5)]
        [DataRow(2013, 2013, 3, 28)]
        [DataRow(2014, 2014, 4, 17)]
        [DataRow(2015, 2015, 4, 2)]
        [DataRow(2016, 2016, 3, 24)]
        [DataRow(2017, 2017, 4, 13)]
        [DataRow(2018, 2018, 3, 29)]
        [DataRow(2019, 2019, 4, 18)]
        [DataRow(2020, 2020, 4, 9)]
        [DataRow(2021, 2021, 4, 1)]
        [DataRow(2022, 2022, 4, 14)]
        [DataRow(2023, 2023, 4, 6)]
        [DataRow(2024, 2024, 3, 28)]
        [DataRow(2025, 2025, 4, 17)]
        [DataRow(2026, 2026, 4, 2)]
        [DataRow(2027, 2027, 3, 25)]
        [DataRow(2028, 2028, 4, 13)]
        [DataRow(2029, 2029, 3, 29)]
        [DataRow(2030, 2030, 4, 18)]
        [DataRow(2031, 2031, 4, 10)]
        [DataRow(2032, 2032, 3, 25)]
        [DataRow(2033, 2033, 4, 14)]
        [DataRow(2034, 2034, 4, 6)]
        public void TestMaundyThursday(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], church holiday [C]
            this.AssertObservedDate(year, "CMAUNDYTHURSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 3, 21)]
        [DataRow(2009, 2009, 4, 10)]
        [DataRow(2010, 2010, 4, 2)]
        [DataRow(2011, 2011, 4, 22)]
        [DataRow(2012, 2012, 4, 6)]
        [DataRow(2013, 2013, 3, 29)]
        [DataRow(2014, 2014, 4, 18)]
        [DataRow(2015, 2015, 4, 3)]
        [DataRow(2016, 2016, 3, 25)]
        [DataRow(2017, 2017, 4, 14)]
        [DataRow(2018, 2018, 3, 30)]
        [DataRow(2019, 2019, 4, 19)]
        [DataRow(2020, 2020, 4, 10)]
        [DataRow(2021, 2021, 4, 2)]
        [DataRow(2022, 2022, 4, 15)]
        [DataRow(2023, 2023, 4, 7)]
        [DataRow(2024, 2024, 3, 29)]
        [DataRow(2025, 2025, 4, 18)]
        [DataRow(2026, 2026, 4, 3)]
        [DataRow(2027, 2027, 3, 26)]
        [DataRow(2028, 2028, 4, 14)]
        [DataRow(2029, 2029, 3, 30)]
        [DataRow(2030, 2030, 4, 19)]
        [DataRow(2031, 2031, 4, 11)]
        [DataRow(2032, 2032, 3, 26)]
        [DataRow(2033, 2033, 4, 15)]
        [DataRow(2034, 2034, 4, 7)]
        public void TestGoodFriday(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], church holiday [C]
            this.AssertObservedDate(year, "CGOODFRIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 3, 23)]
        [DataRow(2009, 2009, 4, 12)]
        [DataRow(2010, 2010, 4, 4)]
        [DataRow(2011, 2011, 4, 24)]
        [DataRow(2012, 2012, 4, 8)]
        [DataRow(2013, 2013, 3, 31)]
        [DataRow(2014, 2014, 4, 20)]
        [DataRow(2015, 2015, 4, 5)]
        [DataRow(2016, 2016, 3, 27)]
        [DataRow(2017, 2017, 4, 16)]
        [DataRow(2018, 2018, 4, 1)]
        [DataRow(2019, 2019, 4, 21)]
        [DataRow(2020, 2020, 4, 12)]
        [DataRow(2021, 2021, 4, 4)]
        [DataRow(2022, 2022, 4, 17)]
        [DataRow(2023, 2023, 4, 9)]
        [DataRow(2024, 2024, 3, 31)]
        [DataRow(2025, 2025, 4, 20)]
        [DataRow(2026, 2026, 4, 5)]
        [DataRow(2027, 2027, 3, 28)]
        [DataRow(2028, 2028, 4, 16)]
        [DataRow(2029, 2029, 4, 1)]
        [DataRow(2030, 2030, 4, 21)]
        [DataRow(2031, 2031, 4, 13)]
        [DataRow(2032, 2032, 3, 28)]
        [DataRow(2033, 2033, 4, 17)]
        [DataRow(2034, 2034, 4, 9)]
        public void TestEasterSunday(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], church holiday [C]
            this.AssertObservedDate(year, "CEASTERSUNDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 3, 24)]
        [DataRow(2009, 2009, 4, 13)]
        [DataRow(2010, 2010, 4, 5)]
        [DataRow(2011, 2011, 4, 25)]
        [DataRow(2012, 2012, 4, 9)]
        [DataRow(2013, 2013, 4, 1)]
        [DataRow(2014, 2014, 4, 21)]
        [DataRow(2015, 2015, 4, 6)]
        [DataRow(2016, 2016, 3, 28)]
        [DataRow(2017, 2017, 4, 17)]
        [DataRow(2018, 2018, 4, 2)]
        [DataRow(2019, 2019, 4, 22)]
        [DataRow(2020, 2020, 4, 13)]
        [DataRow(2021, 2021, 4, 5)]
        [DataRow(2022, 2022, 4, 18)]
        [DataRow(2023, 2023, 4, 10)]
        [DataRow(2024, 2024, 4, 1)]
        [DataRow(2025, 2025, 4, 21)]
        [DataRow(2026, 2026, 4, 6)]
        [DataRow(2027, 2027, 3, 29)]
        [DataRow(2028, 2028, 4, 17)]
        [DataRow(2029, 2029, 4, 2)]
        [DataRow(2030, 2030, 4, 22)]
        [DataRow(2031, 2031, 4, 14)]
        [DataRow(2032, 2032, 3, 29)]
        [DataRow(2033, 2033, 4, 18)]
        [DataRow(2034, 2034, 4, 10)]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], church holiday [C]
            this.AssertObservedDate(year, "CEASTERMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 4, 18)]
        [DataRow(2009, 2009, 5, 8)]
        [DataRow(2010, 2010, 4, 30)]
        [DataRow(2011, 2011, 5, 20)]
        [DataRow(2012, 2012, 5, 4)]
        [DataRow(2013, 2013, 4, 26)]
        [DataRow(2014, 2014, 5, 16)]
        [DataRow(2015, 2015, 5, 1)]
        [DataRow(2016, 2016, 4, 22)]
        [DataRow(2017, 2017, 5, 12)]
        [DataRow(2018, 2018, 4, 27)]
        [DataRow(2019, 2019, 5, 17)]
        [DataRow(2020, 2020, 5, 8)]
        [DataRow(2021, 2021, 4, 30)]
        [DataRow(2022, 2022, 5, 13)]
        [DataRow(2023, 2023, 5, 5)]
        [DataRow(2024, 2024, 4, 26)]
        [DataRow(2025, 2025, 5, 16)]
        [DataRow(2026, 2026, 5, 1)]
        [DataRow(2027, 2027, 4, 23)]
        [DataRow(2028, 2028, 5, 12)]
        [DataRow(2029, 2029, 4, 27)]
        [DataRow(2030, 2030, 5, 17)]
        [DataRow(2031, 2031, 5, 9)]
        [DataRow(2032, 2032, 4, 23)]
        [DataRow(2033, 2033, 5, 13)]
        [DataRow(2034, 2034, 5, 5)]
        public void TestGeneralPrayerDay(int year, int observedYear, int month, int day)
        {
            //Fourth Friday after Easter (Store Bededag / Tussiarfissuaq)
            //Church holiday [C][D], not abolished in Greenland [E], flag day since 2025 [B], bank closing day [H]
            this.AssertObservedDate(year, "GENERALPRAYERDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 5, 1)]
        [DataRow(2009, 2009, 5, 21)]
        [DataRow(2010, 2010, 5, 13)]
        [DataRow(2011, 2011, 6, 2)]
        [DataRow(2012, 2012, 5, 17)]
        [DataRow(2013, 2013, 5, 9)]
        [DataRow(2014, 2014, 5, 29)]
        [DataRow(2015, 2015, 5, 14)]
        [DataRow(2016, 2016, 5, 5)]
        [DataRow(2017, 2017, 5, 25)]
        [DataRow(2018, 2018, 5, 10)]
        [DataRow(2019, 2019, 5, 30)]
        [DataRow(2020, 2020, 5, 21)]
        [DataRow(2021, 2021, 5, 13)]
        [DataRow(2022, 2022, 5, 26)]
        [DataRow(2023, 2023, 5, 18)]
        [DataRow(2024, 2024, 5, 9)]
        [DataRow(2025, 2025, 5, 29)]
        [DataRow(2026, 2026, 5, 14)]
        [DataRow(2027, 2027, 5, 6)]
        [DataRow(2028, 2028, 5, 25)]
        [DataRow(2029, 2029, 5, 10)]
        [DataRow(2030, 2030, 5, 30)]
        [DataRow(2031, 2031, 5, 22)]
        [DataRow(2032, 2032, 5, 6)]
        [DataRow(2033, 2033, 5, 26)]
        [DataRow(2034, 2034, 5, 18)]
        public void TestAscensionDay(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], church holiday [C]
            this.AssertObservedDate(year, "CASCENSIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 5, 2)]
        [DataRow(2009, 2009, 5, 22)]
        [DataRow(2010, 2010, 5, 14)]
        [DataRow(2011, 2011, 6, 3)]
        [DataRow(2012, 2012, 5, 18)]
        [DataRow(2013, 2013, 5, 10)]
        [DataRow(2014, 2014, 5, 30)]
        [DataRow(2015, 2015, 5, 15)]
        [DataRow(2016, 2016, 5, 6)]
        [DataRow(2017, 2017, 5, 26)]
        [DataRow(2018, 2018, 5, 11)]
        [DataRow(2019, 2019, 5, 31)]
        [DataRow(2020, 2020, 5, 22)]
        [DataRow(2021, 2021, 5, 14)]
        [DataRow(2022, 2022, 5, 27)]
        [DataRow(2023, 2023, 5, 19)]
        [DataRow(2024, 2024, 5, 10)]
        [DataRow(2025, 2025, 5, 30)]
        [DataRow(2026, 2026, 5, 15)]
        [DataRow(2027, 2027, 5, 7)]
        [DataRow(2028, 2028, 5, 26)]
        [DataRow(2029, 2029, 5, 11)]
        [DataRow(2030, 2030, 5, 31)]
        [DataRow(2031, 2031, 5, 23)]
        [DataRow(2032, 2032, 5, 7)]
        [DataRow(2033, 2033, 5, 27)]
        [DataRow(2034, 2034, 5, 19)]
        public void TestBankClosingDay(int year, int observedYear, int month, int day)
        {
            //Friday after Ascension Day
            //Bank closing day [H]
            this.AssertObservedDate(year, "BANKCLOSINGDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 5, 11)]
        [DataRow(2009, 2009, 5, 31)]
        [DataRow(2010, 2010, 5, 23)]
        [DataRow(2011, 2011, 6, 12)]
        [DataRow(2012, 2012, 5, 27)]
        [DataRow(2013, 2013, 5, 19)]
        [DataRow(2014, 2014, 6, 8)]
        [DataRow(2015, 2015, 5, 24)]
        [DataRow(2016, 2016, 5, 15)]
        [DataRow(2017, 2017, 6, 4)]
        [DataRow(2018, 2018, 5, 20)]
        [DataRow(2019, 2019, 6, 9)]
        [DataRow(2020, 2020, 5, 31)]
        [DataRow(2021, 2021, 5, 23)]
        [DataRow(2022, 2022, 6, 5)]
        [DataRow(2023, 2023, 5, 28)]
        [DataRow(2024, 2024, 5, 19)]
        [DataRow(2025, 2025, 6, 8)]
        [DataRow(2026, 2026, 5, 24)]
        [DataRow(2027, 2027, 5, 16)]
        [DataRow(2028, 2028, 6, 4)]
        [DataRow(2029, 2029, 5, 20)]
        [DataRow(2030, 2030, 6, 9)]
        [DataRow(2031, 2031, 6, 1)]
        [DataRow(2032, 2032, 5, 16)]
        [DataRow(2033, 2033, 6, 5)]
        [DataRow(2034, 2034, 5, 28)]
        public void TestPentecost(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], church holiday [C]
            this.AssertObservedDate(year, "CPENTECOST-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2008, 2008, 5, 12)]
        [DataRow(2009, 2009, 6, 1)]
        [DataRow(2010, 2010, 5, 24)]
        [DataRow(2011, 2011, 6, 13)]
        [DataRow(2012, 2012, 5, 28)]
        [DataRow(2013, 2013, 5, 20)]
        [DataRow(2014, 2014, 6, 9)]
        [DataRow(2015, 2015, 5, 25)]
        [DataRow(2016, 2016, 5, 16)]
        [DataRow(2017, 2017, 6, 5)]
        [DataRow(2018, 2018, 5, 21)]
        [DataRow(2019, 2019, 6, 10)]
        [DataRow(2020, 2020, 6, 1)]
        [DataRow(2021, 2021, 5, 24)]
        [DataRow(2022, 2022, 6, 6)]
        [DataRow(2023, 2023, 5, 29)]
        [DataRow(2024, 2024, 5, 20)]
        [DataRow(2025, 2025, 6, 9)]
        [DataRow(2026, 2026, 5, 25)]
        [DataRow(2027, 2027, 5, 17)]
        [DataRow(2028, 2028, 6, 5)]
        [DataRow(2029, 2029, 5, 21)]
        [DataRow(2030, 2030, 6, 10)]
        [DataRow(2031, 2031, 6, 2)]
        [DataRow(2032, 2032, 5, 17)]
        [DataRow(2033, 2033, 6, 6)]
        [DataRow(2034, 2034, 5, 29)]
        public void TestWhitMonday(int year, int observedYear, int month, int day)
        {
            //Flag day [A][B], church holiday [C]
            this.AssertObservedDate(year, "CWHITMONDAY-01", observedYear, month, day);
        }

        #endregion

        #region Holiday types

        [TestMethod]
        [DataRow(2008)]
        [DataRow(2019)]
        [DataRow(2025)]
        [DataRow(2026)]
        [DataRow(2027)]
        [DataRow(2034)]
        public void TestEpiphanyIsAnObservanceOnly(int year)
        {
            //Flag day [A][B], half day off for state employees [G]; no church holiday [C] and no bank closing day [H]
            this.AssertHolidayTypes(year, "EPIPHANY-01", HolidayTypes.Observance | HolidayTypes.Authorities);
        }

        [TestMethod]
        [DataRow("BANKCLOSINGDAY-01")]
        [DataRow("CHRISTMASEVE-01")]
        [DataRow("NEWYEARSEVE-01")]
        public void TestBankClosingDaysAreBankHolidays(string holidayId)
        {
            //Bank closing days [H], not church holidays [C]
            foreach (var year in new[] { 2008, 2025, 2026, 2027, 2034 })
            {
                var holiday = HolidaySystem.GetHolidays(year, CountryCode.GL).Single(o => o.Id.EndsWith(holidayId));
                Assert.IsTrue(holiday.HolidayTypes.HasFlag(HolidayTypes.Bank), $"{holidayId} {year}");
                Assert.IsFalse(holiday.HolidayTypes.HasFlag(HolidayTypes.Public), $"{holidayId} {year}");
            }
        }

        [TestMethod]
        [DataRow(2026, 1, 1, true)]
        [DataRow(2026, 1, 6, false)]
        [DataRow(2026, 4, 2, true)]
        [DataRow(2026, 4, 3, true)]
        [DataRow(2026, 4, 5, true)]
        [DataRow(2026, 4, 6, true)]
        [DataRow(2026, 5, 1, true)]
        [DataRow(2026, 5, 14, true)]
        [DataRow(2026, 5, 15, false)]
        [DataRow(2026, 5, 24, true)]
        [DataRow(2026, 5, 25, true)]
        [DataRow(2026, 6, 21, true)]
        [DataRow(2026, 12, 24, false)]
        [DataRow(2026, 12, 25, true)]
        [DataRow(2026, 12, 26, true)]
        [DataRow(2026, 12, 31, false)]
        [DataRow(2027, 1, 1, true)]
        [DataRow(2027, 1, 6, false)]
        [DataRow(2027, 3, 25, true)]
        [DataRow(2027, 3, 26, true)]
        [DataRow(2027, 3, 28, true)]
        [DataRow(2027, 3, 29, true)]
        [DataRow(2027, 4, 23, true)]
        [DataRow(2027, 5, 6, true)]
        [DataRow(2027, 5, 7, false)]
        [DataRow(2027, 5, 16, true)]
        [DataRow(2027, 5, 17, true)]
        [DataRow(2027, 6, 21, true)]
        [DataRow(2027, 12, 24, false)]
        [DataRow(2027, 12, 25, true)]
        [DataRow(2027, 12, 26, true)]
        [DataRow(2027, 12, 31, false)]
        public void ChecksIsPublicHoliday(int year, int month, int day, bool expectedIsPublicHoliday)
        {
            //Church holidays [C][D] and National Day [F] are public holidays,
            //6 January [G], Friday after Ascension Day, 24 and 31 December [H] are not
            var date = new DateTime(year, month, day);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(date, CountryCode.GL);
            Assert.AreEqual(expectedIsPublicHoliday, isPublicHoliday, date.ToString("yyyy-MM-dd"));
        }

        #endregion

        #region Public holidays per year

        [TestMethod]
        [DataRow(2008)]
        [DataRow(2017)]
        [DataRow(2024)]
        [DataRow(2025)]
        [DataRow(2026)]
        [DataRow(2034)]
        public void TestNationwidePublicHolidayCount(int year)
        {
            //11 church holidays [C][D] (New Year's Day, Maundy Thursday, Good Friday, Easter Sunday, Easter Monday,
            //General Prayer Day, Ascension Day, Whit Sunday, Whit Monday, Christmas Day, St. Stephen's Day)
            //plus National Day [F]
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.GL)
                .Where(o => o.HolidayTypes.HasFlag(HolidayTypes.Public) && o.NationalHoliday)
                .ToArray();

            Assert.HasCount(12, publicHolidays);
        }

        [TestMethod]
        [DataRow(2024)]
        [DataRow(2025)]
        [DataRow(2026)]
        public void TestGeneralPrayerDayStillExistsAfterDanishAbolition(int year)
        {
            //Denmark abolished Store Bededag from 2024, the law does not apply to Greenland [E] and it remains a holiday there [D]
            var holiday = HolidaySystem.GetHolidays(year, CountryCode.GL).Single(o => o.Id.EndsWith("GENERALPRAYERDAY-01"));
            Assert.IsTrue(holiday.HolidayTypes.HasFlag(HolidayTypes.Public));
        }

        #endregion

        [TestMethod]
        [DataRow(2026, 11, 23, false)]
        [DataRow(2026, 11, 24, false)]
        [DataRow(2026, 11, 25, false)]
        [DataRow(2026, 11, 26, false)]
        [DataRow(2026, 11, 27, false)]
        [DataRow(2026, 11, 28, true)]
        [DataRow(2026, 11, 29, true)]
        public void ChecksThatUniversalWeekendIsUsed(int year, int month, int day, bool expectedIsWeekend)
        {
            var date = new DateTime(year, month, day);
            var isWeekend = date.IsWeekend(CountryCode.GL);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }

        private void AssertHolidayTypes(int year, string holidayId, HolidayTypes expectedHolidayTypes)
        {
            var holiday = HolidaySystem.GetHolidays(year, CountryCode.GL).Single(o => o.Id.EndsWith(holidayId));
            Assert.AreEqual(expectedHolidayTypes, holiday.HolidayTypes, $"{holidayId} {year}");
        }
    }
}
