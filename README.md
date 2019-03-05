# DatabaseRestore
Used to restore databases where there is no need for SSMS to be installed.
Can also perform operations like, enable SA, switch to mixed mode login and alter SA password.

Just provide the Database name you would like the database to be restored with, choose the instance and click "Importer". 
The program will you a feedback if the import was successfull or if you need to press any additional buttons to enable SA or change to mixed mode.

Made in C# .net with WinForms for the GUI

![Application screenshot](docs\img\dbrestore.PNG)