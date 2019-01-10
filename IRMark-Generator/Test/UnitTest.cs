using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using HMRC.IRMark.Generator;
using Xunit;

namespace Test
{
    public class UnitTest
    {
        [Fact]
        public async Task CheckIrMark()
        {
            var irMarkGenerator = new IrMarkGenerator();
            var xmlSample = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Body xmlns=\"http://www.govtalk.gov.uk/CM/envelope\"><IRenvelope xmlns=\"http://www.govtalk.gov.uk/taxation/PAYE/RTI/FullPaymentSubmission/18-19/1\"><IRheader><Keys><Key Type=\"TaxOfficeNumber\">635</Key><Key Type=\"TaxOfficeReference\">A635</Key></Keys><PeriodEnd>2019-04-05</PeriodEnd><DefaultCurrency>GBP</DefaultCurrency><Sender>Employer</Sender></IRheader><FullPaymentSubmission><EmpRefs><OfficeNo>635</OfficeNo><PayeRef>A635</PayeRef><AORef>635PC00000000</AORef><COTAXRef>1111111111</COTAXRef></EmpRefs><RelatedTaxYear>18-19</RelatedTaxYear><Employee><EmployeeDetails><NINO>RN000008A</NINO><Name><Ttl>Mr</Ttl><Fore>Alan</Fore><Sur>Example</Sur></Name><Address><Line>1 The Lane</Line><Line>Shipley</Line><Line>Scotland</Line><UKPostcode>AB1 2AD</UKPostcode></Address><BirthDate>1996-10-28</BirthDate><Gender>M</Gender></EmployeeDetails><Employment><PayId>123-A03</PayId><LeavingDate>2018-06-30</LeavingDate><FiguresToDate><TaxablePay>3000.00</TaxablePay><TotalTax>6.65</TotalTax></FiguresToDate><Payment><BacsHashCode>1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef</BacsHashCode><PayFreq>M1</PayFreq><PmtDate>2018-06-30</PmtDate><MonthNo>3</MonthNo><PeriodsCovered>1</PeriodsCovered><HoursWorked>E</HoursWorked><TaxCode BasisNonCumulative=\"yes\" TaxRegime=\"S\">1185L</TaxCode><TaxablePay>1000.00</TaxablePay><PayAfterStatDedns>997.77</PayAfterStatDedns><TaxDeductedOrRefunded>2.25</TaxDeductedOrRefunded></Payment><NIlettersAndValues><NIletter>G</NIletter><GrossEarningsForNICsInPd>1000.00</GrossEarningsForNICsInPd><GrossEarningsForNICsYTD>3000.00</GrossEarningsForNICsYTD><AtLELYTD>1508.00</AtLELYTD><LELtoPTYTD>663.00</LELtoPTYTD><PTtoUELYTD>829.00</PTtoUELYTD><TotalEmpNICInPd>38.13</TotalEmpNICInPd><TotalEmpNICYTD>114.40</TotalEmpNICYTD><EmpeeContribnsInPd>33.16</EmpeeContribnsInPd><EmpeeContribnsYTD>99.48</EmpeeContribnsYTD></NIlettersAndValues></Employment></Employee><Employee><EmployeeDetails><Name><Ttl>Mr</Ttl><Fore>John</Fore><Fore>Edward</Fore><Sur>Surname</Sur></Name><Address><Line>45 High Street</Line><Line>Gosforth</Line><Line>Newcastle upon Tyne</Line><Line>Tyne and Wear</Line><UKPostcode>NE1 7XF</UKPostcode></Address><BirthDate>1954-05-11</BirthDate><Gender>M</Gender></EmployeeDetails><Employment><PayId>123-A02</PayId><IrrEmp>yes</IrrEmp><FiguresToDate><TaxablePay>3750.00</TaxablePay><TotalTax>1687.50</TotalTax></FiguresToDate><Payment><BacsHashCode>ef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcd</BacsHashCode><PayFreq>M1</PayFreq><PmtDate>2018-06-20</PmtDate><MonthNo>3</MonthNo><PeriodsCovered>1</PeriodsCovered><HoursWorked>B</HoursWorked><TaxCode>D1</TaxCode><TaxablePay>1250.00</TaxablePay><PayAfterStatDedns>627.83</PayAfterStatDedns><Benefits><Car><Make>Big Car</Make><CO2>150</CO2><Fuel>D</Fuel><ID>B I6 CAR</ID><Amendment>no</Amendment><Price>25000.00</Price><AvailFrom>2018-06-01</AvailFrom><CashEquiv>250.00</CashEquiv><AvailTo>2018-06-20</AvailTo><FreeFuel><Provided>2018-06-01</Provided><CashEquiv>75.00</CashEquiv><Withdrawn>2018-06-20</Withdrawn></FreeFuel></Car></Benefits><TaxDeductedOrRefunded>562.50</TaxDeductedOrRefunded></Payment></Employment></Employee></FullPaymentSubmission></IRenvelope></Body>";

            var result = await irMarkGenerator.Generate(xmlSample);

            Assert.Equal("j+VBpG6b8EIuz8ldUAjkKboMmU4=", result);
        }
    }
}
