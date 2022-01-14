# POS
Self-Service POS (Point-Of-Sale) with integration for Economic

## Background
The purpose of this project has been to provide a simple way for members in a club to purchase sodas and beers from a fridge.
Earlier we used a tally chart to register the purchases and once in a while we manually made invoices in Economic and entered the value of the purchases.

With the Self-Service POS, the purchase is booked directly to a CurrentInvoice in Economic. If there is an existing invoice the purchase is added to same invoice.
From Economic we use BS (MasterCard Payment Services) to claim the money. 
Since Mastercard charge by the number of invoice lines, we decided to minimize the lines and simply add the value on a single invoice line.

The UI is made for an industrial PC with a touch screen and without any keyboard.

## User manual
![POSscreen](image\POS-screen-dump1.JPG)
In input field ("Medlemsnummer") the member enters his members number and <Enter>. Use the soft keyboard on the screen. 
The POS will lookup in the Economic Debtor table to verify the account. Members name is shown.

Click on the products you want to purchase. The product is added to to the list and the total value is updated.
When you are done press Purchase ("Køb") and the transaction is comitted to Economic.
The screen is cleared and the system is ready for the next customer.

![POSscreen](image\POS-screen-dump2.JPG)
To see old transactions press the History button ("Historik"). Is will show a list of the last 100 transactions with line details.
Enter a members number in order to filter the list.

To end the program click on the red button ("Luk") and enter the secret exit code (requires a keyboard) or enter the exit code in the members number.

## Installation
* Copy the files to Program files\POS 
* Create the two sub folders; images and sound, including the files
* Install the database on a SQL Server 2019
* Create the products in the database. Key-in or use the script to create the products
* Edit the POS.exe.config

## POS.exe.config
In the POS.exe.config file various settings is available:
* LogoPath - path and file name of the logo in the top left corner of the screen
* ProductPath - folder where the product images are saved
* CashRegSoundPath - path and file name of the sound played when a transaction is succesfully booked in Economic
* EconAgreementGrantToken - the Economic Agreement token made by the Economic Admin, to allow the POS access
* EconAppSecretToken - the Economic App token of the developer
* Exitcode - the secret exitcode - remember to make it unique from any members number
* ConnectionString - provide info on the SQL server that holds the POS Transactions used for the history

