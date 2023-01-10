using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStatesCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusfilePath = @"E:\Indian-States-Census-Analyser-Problem\Indian-States-Census-Analyser-Problem\CensusAnalyserTest\CSVFiles\IndianStateCensusData.csv";//indianstatecensusdata.csv
        static string wrongHeaderIndianCensusfilePath = @"E:\Indian-States-Census-Analyser-Problem\Indian-States-Census-Analyser-Problem\CensusAnalyserTest\CSVFiles\WrongHeaderIndianStateCensusData.csv";//wrongindianstatecensusdata.csv
        static string delimiterIndianCensusfilePath = @"E:\Indian-States-Census-Analyser-Problem\Indian-States-Census-Analyser-Problem\CensusAnalyserTest\CSVFiles\DelimiterIndianCensusData.csv";//delimiterindianstatecensusdata.csv
        static string wrongIndianStateCensusfilePath = @"E:\Indian States Census Analyser Problem\Indian-States-Census-Analyser-Problem\CensusAnalyserTest\CSVFiles\WrongIndianStateIndiaData.csv";//indiandata.csv
        static string wrongIndianStateCensusfileType = @"E:\Indian-States-Census-Analyser-Problem\Indian-States-Census-Analyser-Problem\CensusAnalyserTest\CSVFiles\IndianStateCensusData.txt";//indianstatecensus.txt
        static string indianStateCodefilePath = @"E:\Indian-States-Census-Analyser-Problem\Indian-States-Census-Analyser-Problem\CensusAnalyserTest\CSVFiles\IndianStateCode.csv";//indianstatecode.csv
        static string wrongIndianStateCodefileType = @"E:\Indian-States-Census-Analyser-Problem\Indian-States-Census-Analyser-Problem\CensusAnalyserTest\CSVFiles\IndianStateCode.txt";//indianstatecode.txt
        static string delimiterIndianStateCodefilePath = @"E:\Indian-States-Census-Analyser-Problem\Indian-States-Census-Analyser-Problem\CensusAnalyserTest\CSVFiles\DelimiterIndianStateCode.csv";//delimiterindianstatecode.csv
        static string wrongHeaderStateCodefilePath = @"E:\Indian-States-Census-Analyser-Problem\Indian-States-Census-Analyser-Problem\CensusAnalyserTest\CSVFiles\WrongHeaderIndianStateCode.csv";//wrongindianstatecode.csv
        static string wrongIndianStateCodefilePath = @"E:\Indian States Census Analyser Problem\Indian-States-Census-Analyser-Problem\CensusAnalyserTest\CSVFiles\WrongIndianStateCodeData.csv";//indiancodedata.csv


        IndianStatesCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStatesCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]//tc1.1
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusfilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]//tc1.2
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        [Test]//tc1.3
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]//tc1.4
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]//tc1.5
        public void GivenWrongIndianCensusDataFileType_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

       
    }
}