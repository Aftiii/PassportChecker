# Passport Checker
A frontend and API used to verify and check MrzLine2

## Project Info
This is an ASP.NET Core (2.1) project which uses 3 different projects:
* API - Consumable API end points for reference data and MrzLine2 validation
* Common - Validation Library
* Web - HTML, CSS, jQuery, jQuery validate, Bootstrap

It was made using Visual Studio Community 2017

Some parts are unit tested and either use xUnit or MSTest

## Running the project
You'll need to run both PassportChecker.Web and PassportChecker.API. Without the API the front end will not be able to consume anything.

## Reference data
```
Passport number: XS1234567
Nationality: Japan
Gender: Female
DoB: 20/02/1979
Expiry:20/03/2016
XS12345673JPN7902206F1603202<<<<<<<<<<<<<<02
```
```
Passport number: ZE000509
Nationality: Canadian
DoB: 01/01/1985
Gender: Female
Date of expiry:14/01/2023
ZE000509<9CAN8501019F2301147<<<<<<<<<<<<<<08
```
```
Passport number: 925076473
Nationality: GBR
DoB: 11/09/1988
Gender: Female
Date of Expiry: 16/07/2020
9250764733GBR8809117F2007162<<<<<<<<<<<<<<08
```
```
Passport number: J2927175
Nationality: Indian
DoB: 14/02/1965
Gender: Male
Date of Expiry: 08/12/2020
J2927175<8IND6502148M2012087<<<<<<<<<<<<<<<4
```
```
Passport number: C01X00T47
Nationality: Germany
DoB: 12/08/1964
Gender: Female
Date of Expiry: 28/02/2027
C01X00T478D<<6408125F2702283<<<<<<<<<<<<<<<4
```
```
Passport number: AG8148412
Nationality: Bangladeshi
DoB: 25/12/1981
Gender: Female
Date of Expiry: 11/09/2018
AG81484126BGD8112255F1809118<<<<<<<<<<<<<<02
```
```
Passport number: 99003853
Nationality: Czech Republic
DoB: 01/01/1911
Gender: Male
Date of Expiry: 04/07/2012
99003853<1CZE1101018M1207046110101111<<<<<94
```

## Reference Documentation
[ICAO Machine Readable Travel Documents - 9303-3](https://www.icao.int/publications/Documents/9303_p3_cons_en.pdf)

[ICAO Machine Readable Travel Documents - 9303-4](https://www.icao.int/publications/Documents/9303_p4_cons_en.pdf)

[Programmer's reference](http://www.highprogrammer.com/alan/numbers/mrp.html)

[Wiki reference](https://en.wikipedia.org/wiki/Machine-readable_passport)

## Things to improve
* Some items could do with being put into config e.g. where the MrzLine2 splits, the date mask for an Mrz
* The business logic should have a separate layer, however the requirements of the project meant that this had to go into a common library