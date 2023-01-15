# Final work of Mr. P. Paulaitis

Automatic testing training at Vilnius Coding School (2023-01-16)


:link: Link to the test page: [Tax.lt]( https://tax.lt/)

## :large_blue_circle: 1. Scenario: ["Atlyginimų ir mokesčių skaičiuoklė"](https://tax.lt/skaiciuokles/atlyginimo_ir_mokesciu_skaiciuokle)
### #1 Case. Main functionalities
    
#### Check if all page functionalities work
      - 1 step. Select radio button "į rankas"
      - 2 step. Enter value "Į rankas": 1518,68
      - 3 step. Select radio button "nurodysiu pats"
      - 4 step. Enter value "Taikomas NPD": 500
      - 5 step. Mark checkbox "Kaupiu pensijai papildomai"
      - 6 step. Assert if calculations are made

### #2 Case. Income tax calculations
#### Check if income tax is calculated correctly
      - 1 step. Enter value "Ant popieriaus": 2489,62
      - 2 step. Select radio button "nurodysiu pats"
      - 3 step. Enter value "Taikomas NPD": 695,00
      - 4 step. Select radio button "paskaičiuos sistema"
      - 5 step. Check if income tax is calculated correctly in both options

### #3 Case. Previous year(s) salary calculation
#### Change to previous year and check if values are different
      - 1 step. Enter value "Ant popieriaus": 1234
      - 2 step. Select value in "Metai" dropdown menu to: 2019 (option 1)
      - 3 step. Check the checkbox “Kaupiu pensijai papildomai”
      - 4 step. Change selection of "Metai" dropdown menu to: 2023 (option 2)
      - 5 step. Check the checkbox “Kaupiu pensijai papildomai”
      - 6 step. Assert if calculations in field “Išmokamas atlyginimas "į rankas" 
                in both options is not the same
        
        
## :large_blue_circle: 2. Scenario: ["Valiutų skaičiuoklė"](https://tax.lt/skaiciuokles/valiutu_skaiciuokle)    
### #4 Case. Default Values
#### Check if page default values are correct
      - 1 step. Check if "Valiutos kurso data" date is today
      - 2 step. Check if EUR, USD, GBP, PLN, NOK, SEK, CHF, DKK, AUD, CAD, CNY, 
                CZK, JPY, RON, TRY, UAH currencies are displayed
      - 3 step. Check if "Pridėti valiutą" dropdown menu is set on "pasirink..."
      - 4 step. Check if "skaičiai po kablelio" dropdown menu is set on "2"

### #5 Case. Add/remove currency functionality
#### Remove currencies, add missing currencies, check if works
      - 1 step. Remove EUR, USD, PLN currencies from currency list
      - 2 step. Check if they are removed
      - 3 step. Add removed currencies via "Pridėti valiutą" dropdown menu
      - 4 step. Check if currencies are added to the currency list
      - 5 step. Try to add EUR currency to the list again
      - 6 step. Check if the currency is not double added to the currency list

### #6 Case. Numbers after comma
#### Check if numbers after comma selection functionality works
      - 1 step. Enter value in currency “EUR” field: 100,16
      - 2 step. Check if currency “USD” has default (2) numbers after comma
      - 3 step. Choose selection from dropdown box “skaičiai po kablelio” to: 3
      - 4 step. Change value in currency “EUR” field: 100,16
      - 5 step. Check if currency “USD” has 3 numbers after comma

![This is an image](https://cdn-icons-png.flaticon.com/128/1616/1616487.png)
